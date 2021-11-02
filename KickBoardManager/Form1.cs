using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Threading;


namespace KickBoardManager
{
    public partial class MainForm : Form
    {
        public static MainForm mainform;
        public string standardPath;
        public MainForm()
        {
            InitializeComponent();
            mainform = this;
        }

        private void userPoints_Click(object sender, EventArgs e)
        {
            string path = null;
            openUserPoints.InitialDirectory = "C:\\";
            if (openUserPoints.ShowDialog() == DialogResult.OK)
            {
                path = openUserPoints.FileName;
                UserPath.Text = path;
                standardPath = Path.GetDirectoryName(path);
            }
        } // 사용자 위치를 받아와 UserPath.에 저장

        private void availPolygon_Click(object sender, EventArgs e)
        {
            string path = null;
            openAvailPolys.InitialDirectory = "C:\\";
            if (openAvailPolys.ShowDialog() == DialogResult.OK)
            {
                path = openAvailPolys.FileName;
                AvailPath.Text = path;
            }
        } // 주차 가능구역 폴리곤을 받아와 AvailPath.에 저장

        private void unavailPolygon_Click(object sender, EventArgs e)
        {
            string path = null;
            openUnavailPolys.InitialDirectory = "C:\\";
            if (openUnavailPolys.ShowDialog() == DialogResult.OK)
            {
                path = openUnavailPolys.FileName;
                UnavailPath.Text = path;
            }
        } // 주차 불가능구역 폴리곤을 받아와 UnavailPath.에 저장

        private void saveFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            string selected = dialog.SelectedPath;
            savePath.Text = selected;
        }// 저장 위치를 지정, 별도로 지정하지 않는 경우에는 사용자 위치 파일 경로에 저장함

        private void start_Click(object sender, EventArgs e)
        {   //메인 프로그램 실행 버튼

            parkingText.Text = "";
            fineText.Text = "";
            bool Impossible = false;
            if (AvailPath.Text == "" || UserPath.Text == "") Impossible = true;
            // 결과 출력 창과 주차 가능 여부를 나타내는 Impossible을 초기화

            if (Impossible)
            {
                MessageBox.Show("시작 파일을 입력해 주세요!");
                return;
            }
            //최소한으로 필요한 파일이 누락된 경우 프로그램을 시작하지 않음

            Manager M = new Manager(UserPath.Text);
            ParkingArea availA = new ParkingArea(AvailPath.Text);

            ParkingArea unavailA = new ParkingArea(AvailPath.Text);
            int nearbyId_not = 0;
            if (UnavailPath.Text != "")
            {
                unavailA = new ParkingArea(UnavailPath.Text);
                nearbyId_not = M.NearbyPoly(unavailA, M.point[0]); //주차 불가능 폴리곤에 대해 nearbypoly 실행

            }
            //각각 매니저, 주차 가능 폴리곤 생성


            StreamWriter sw = new StreamWriter(standardPath + @"\noname.txt");
            if (savePath.Text != "" && saveName.Text != "")
            {
                sw = new StreamWriter(savePath.Text + @"\" + saveName.Text + ".txt");
            }
            else if (savePath.Text != "")
            {
                sw = new StreamWriter(savePath.Text + @"\noname.txt");
            }
            sw.WriteLine("GPST,Velocity,Distance");

            double[] avg = { 0, 0, 0 }; //누적 좌표, x, y, z순 (즉 경도, 위도, 높이)
            int nearbyId = M.NearbyPoly(availA, M.point[0]); //종료 프로그램 시작 시점에서 가장 가까운 폴리곤의 id 색출
            bool ParkingAvail = false;
            double velocity;
            double distance;
            //속도 계산을 위해 속도와 거리 선언, 가까운 폴리곤 미리 색출

            DateTime startTime = M.point[0].time;  //프로그램 시작 시간
            DateTime endTime;
            string breakType;

            FineManager FM = new FineManager("0", "0");
            if (fineMoney.Text != "" && velocityLimit.Text != "") FM = new FineManager(velocityLimit.Text, fineMoney.Text);
            int finemoney = 0;
            //속도 계산을 위해 datetime선언, 벌금 부여 매니저 객체 선언

            int availCount = 0; //좌표가 실제로 폴리곤 안에 있는 경우 올라감

            for (int i = 0; i < M.userCount; i++) //실시간 좌표추적 상황 가정
            {
                Thread.Sleep(900); //시간지연
                if (i != 0) //속도와 관련된 작업을 수행하는 if문
                {
                    M.velocity(M.point[i - 1], M.point[i], out velocity, out distance);
                    velocityText.Clear();
                    distanceText.Clear();
                    velocityText.AppendText(velocity.ToString());
                    distanceText.AppendText(distance.ToString());
                    velocity = 3.6 * velocity;
                    sw.WriteLine("{0},{1},{2}", M.point[i].time, velocity, distance);

                    if (velocityLimit.Text != "")
                    {
                        bool limitover = FM.LimitOver(velocity);
                        if (limitover) fineText.AppendText("제한 속도 초과\r\n");
                        if (FM.limitNum >= 10)
                        {
                            fineText.AppendText("과속! 벌금 부과됨\n\r");
                            finemoney += FM.FineMoney(velocity);
                            fineText.AppendText(FM.FineMoney(velocity).ToString());
                            fineText.AppendText("\r\n총 벌금 : ");
                            fineText.AppendText(finemoney.ToString());
                            fineText.AppendText("\r\n");
                            FM.limitNum = 0;
                        }
                    }
                }

                if (availCount >= 10)
                {
                    endTime = M.point[i].time;
                    breakType = "주차장 안에 존재함";
                    goto BREAK;
                } //5초 이상 연속해서 주차장 안에 존재하는 경우

                avg[0] += M.point[i].X;
                avg[1] += M.point[i].Y;
                avg[2] += M.point[i].Z;

                UserPoint avgPoint = new UserPoint(avg[0] / (i + 1), avg[1] / (i + 1), avg[2] / (i + 1), 1, M.point[i].time.ToString());
                ParkingAvail = M.PointInPoly(availA.longitude[nearbyId], availA.latitude[nearbyId], avgPoint);
                if (ParkingAvail && i >= 9)
                {
                    endTime = M.point[i].time;
                    breakType = "평균 좌표로 종료";
                    goto BREAK;
                } //10초 이상 누적된 평균좌표가 폴리곤 안에 있는 경우


                ParkingAvail = M.PointInPoly(availA.longitude[nearbyId], availA.latitude[nearbyId], M.point[i]);
                if (ParkingAvail)
                {
                    availCount += 2;
                    parkingText.AppendText("주차 허용 구역 안입니다.\r\n");
                    continue;
                }//i번째 포인트가 주차 허용 구역 안에 들어가 있는 경우
                else
                {   //Q값에 따라 값을 무효화하거나 availCount 조정(Q=2가 더 신뢰성이 높기 때문에, 이 경우 availCount -= 1)
                    if (M.point[i].Q == 5) continue;
                    else if (M.point[i].Q == 2 || availCount >= 2)
                    {
                        availCount -= 1;
                        parkingText.AppendText("주차 허용 구역 안... 일 수도 있습니다.\r\n");
                        continue;
                    } 
                    availCount = 0;
                }
                //좌표가 fix 됐음에도 폴리곤 밖을 벗어난 경우, availCount 초기화

                //주차 불가능 구역에 있는지 확인, 해당하면 평균 좌표 연산을 건너뛰고 재탐색
                if (!UnavailPath.Text.Equals(""))
                {
                    ParkingAvail = M.PointInPoly(unavailA.longitude[nearbyId_not], unavailA.latitude[nearbyId_not], M.point[i]);
                    if (ParkingAvail)
                    {
                        parkingText.AppendText("주차 불가능 지역입니다. 위치를 이동해 주세요.\r\n");
                        availCount -= 2;
                        continue;
                    }
                }

                //주차 가능한 경우가 아니며, 주차 불가능 구역에 있어 바로 재탐색에 들어간 것도 아니고
                //아마도 주차구역 근처인데 측정값이 튀는 경우
            }

            parkingText.AppendText("\r\n=======================================\r\n");
            parkingText.AppendText("주차 구역을 인식할 수 없습니다. 요청 시간을 초과하였습니다. 다시 시도해 주세요.\r\n");
            parkingText.AppendText("=======================================\r\n");
            sw.Close();
            return;

            BREAK:
            TimeSpan timeDif = endTime - startTime;
            parkingText.AppendText("\r\n=======================================\r\n");
            parkingText.AppendText("주차가 완료되었습니다. 프로그램을 종료합니다.\r\n");
            parkingText.AppendText("종료까지 걸린 시간 : ");
            parkingText.AppendText(timeDif.Minutes.ToString());
            parkingText.AppendText("분 ");
            parkingText.AppendText(timeDif.Seconds.ToString());
            parkingText.AppendText("초");
            parkingText.AppendText("\r\n종료 타입 : ");
            parkingText.AppendText(breakType);
            parkingText.AppendText("\r\n=======================================");
            sw.Close();
        }


        private void ecefFile_Click(object sender, EventArgs e)
        {
            string path = null;
            openUserEcef.InitialDirectory = "C:\\";
            if (openUserEcef.ShowDialog() == DialogResult.OK)
            {
                path = openUserEcef.FileName;
                xyzPath.Text = path;
            }
        }
        private void rmsCheck_Click(object sender, EventArgs e)
        {
            bool Impossible = false;
            if (UserPath.Text == "" || xyzPath.Text == "") Impossible = true;

            //최소한으로 필요한 파일이 누락된 경우 프로그램을 시작하지 않음
            if (Impossible)
            {
                MessageBox.Show("시작 파일을 입력해 주세요!");
                return;
            }

            Manager LLH = new Manager(UserPath.Text);
            Manager ECEF = new Manager(xyzPath.Text);
            RMS R = new RMS();

            double[] rms = new double[3];
            double[] true_llh;
            double[] true_ecef;
            List<double> lat = new List<double>();
            List<double> lon = new List<double>();
            List<double> h = new List<double>();
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            List<double> z = new List<double>();
            //평균으로 구한 true 좌표를 좌표계별로 선언, 좌표값을 개별 리스트로 받아오기 위해 선언함


            R.avgFind(LLH.point, out true_llh, out lat, out lon, out h);
            R.avgFind(ECEF.point, out true_ecef, out x, out y, out z);

            rms = R.errFind(x, y, z, true_llh, true_ecef);

            rms_e.Text = rms[0].ToString();
            rms_n.Text = rms[1].ToString();
            rms_u.Text = rms[2].ToString();
        }
    }
    class ParkingArea //폴리곤 파일을 통해 생성하는 객체
    {
        public List<List<double>> latitude = new List<List<double>>();
        public List<List<double>> longitude = new List<List<double>>();
        //위도와 경도를 이중 리스트로 선언.
        //List[][] 의 첫 번째 인덱스는 폴리곤의 순서가 되며, 두번째 인덱스는 폴리곤을 이루는 포인트의 순서가 됨
        public int PolyCount = 0;

        public ParkingArea(string path)  //생성자, geojson 파일을 통해 폴리곤들을 형성
        {
            StreamReader sr = new StreamReader(path);
            string tmpreadline;
            Regex r = new Regex(@"[0-9]*\.*[0-9]+"); //문자열에서 실수만 받아오기 위함
            MainForm mainform = new MainForm();

            for (int i = 0; sr.Peek() >= 0; i++)
            {
                tmpreadline = sr.ReadLine();
                if (i <= 4) continue;

                List<double> lat = new List<double>();
                List<double> lon = new List<double>();
                string[] inputs = tmpreadline.Split(new char[] { ',' });
                double coordinate = 0;
                if (inputs[0] == "]") break;
                PolyCount++;

                for (int j = 3; j < inputs.Length; j++)
                {//폴리곤 경계를 이루는 좌표값이 있는 부분만 훑기, 포인트 개수에 구애받지 않음
                    Match m = r.Match(inputs[j]);
                    try
                    {
                        coordinate = double.Parse(m.Value); 
                        if (j % 2 != 0) lon.Add(coordinate);  //홀수면 경도, 짝수면 위도에 추가
                        else lat.Add(coordinate);
                    }
                    catch (FormatException)
                    {
                        mainform.parkingText.AppendText("폴리곤 객체 생성 중 오류");
                    }
                }//double 좌표 추출하여 latitude와 longitude에 추가
                latitude.Add(lat);
                longitude.Add(lon);
            }
            sr.Close();
        }
    }
    class UserPoint
    {   //모든 좌표는 x=경도, y=위도임에 주의
        private double x;
        private double y;
        private double z;
        private int q;
        public DateTime time;
        public UserPoint(double X, double Y, double Z, int Q, string t)
        {
            this.x = X;
            this.y = Y;
            this.z = Z;
            this.q = Q;
            this.time = Convert.ToDateTime(t);
        }
        public double X { get { return x; } }
        public double Y { get { return y; } }
        public double Q { get { return q; } }
        public double Z { get { return z; } }
    }
    class Manager
    {
        MainForm mainform = new MainForm();
        public int userCount = 0;
        List<UserPoint> points = new List<UserPoint>();
        public List<UserPoint> point { get { return points; } }

        //킥보드매니저 생성과 동시에 Path를 통해 유저포인트 객체를 요소로 가지는 리스트 생성
        //즉 하나의 킥보드매니저는 한 명의 유저에 대해서만 관리함!
        public Manager(string path) //이 path는 유저 포인트 좌표의 path
        {
            StreamReader sr = new StreamReader(path);
            string tmpreadline;

            for (int i = 0; sr.Peek() >= 0; i++)
            {
                tmpreadline = sr.ReadLine();
                string[] inputs = tmpreadline.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (inputs[0] == "%") continue;

                UserPoint p = new UserPoint(double.Parse(inputs[3]), double.Parse(inputs[2]), double.Parse(inputs[4]), int.Parse(inputs[5]), inputs[1]);
                //매 시간마다 유저포인트 생성
                points.Add(p); //포인트 객체를 리스트에 추가
            }
            sr.Close();
            userCount = points.Count;
        }

        //해당 포인트에 대해 가장 가까이 있는 폴리곤의 id를 반환, 경위도 평균을 기준으로 연산 수행
        public int NearbyPoly(ParkingArea pa, UserPoint point)
        {
            int NearbyId = 0;
            double min = 0;
            double distance;
            for (int i = 0; i < pa.PolyCount; i++)
            {   //각 변위의 제곱으로 거리를 판별, 최소거리 구하기
                double xDif = Math.Pow(pa.longitude[i].Average() - point.X, 2); //문제발생부분
                double yDif = Math.Pow(pa.latitude[i].Average() - point.Y, 2);
                distance = xDif + yDif;
                if (i == 0) min = distance;
                if (min > distance)
                {
                    min = distance;
                    NearbyId = i;
                }
            }
            return NearbyId;
        }

        public bool PointInPoly(List<double> polygon_x, List<double> polygon_y, UserPoint point)
        {   // 한 개의 폴리곤에 대해 실행됨에 주의!
            // 인자 : 리스트 두개(이중 리스트가 아님, 즉 latitude[nearbyId] 과 같이 넣어야 함)
            // + 포인트 하나(포인트 리스트가 아님, 즉 리스트의 요소 하나를 넣어야 함)
            bool result = false;
            int j = polygon_x.Count - 1;
            for (int i = 0; i < polygon_x.Count; i++)
            {   //폴리곤을 이루는 외곽 점 중에서 인접한 두 개를 선택. 즉 nC2
                if (polygon_y[i] < point.Y && polygon_y[j] >= point.Y || polygon_y[j] < point.Y && polygon_y[i] >= point.Y)
                {
                    if (polygon_x[i] + (point.Y - polygon_y[i]) / (polygon_y[j] - polygon_y[i]) * (polygon_x[j] - polygon_x[i]) < point.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
        public void velocity(UserPoint p1, UserPoint p2, out double v, out double distance)
        {   //p2가 나중 시간, p1가 이전 시간임에 유의
            double x_dif = Math.Pow(p2.X - p1.X, 2);
            double y_dif = Math.Pow(p2.Y - p1.Y, 2);
            distance = Math.Sqrt(x_dif + y_dif);

            DateTime time1 = p1.time;
            DateTime time2 = p2.time;

            TimeSpan time_Dif = time2 - time1;
            int sec_Dif = time_Dif.Seconds;

            v = distance / sec_Dif;
        }        
    }

    
    class FineManager
    {
        bool userFine = true;
        double limit;
        public int limitNum = 0;
        int Fine;
        public FineManager(string vLimit, string fine)
        {
            if (fine == "0" || fine == "") userFine = false;
            else Fine = int.Parse(fine);
            this.limit = double.Parse(vLimit);
            //생성자, 사용자 지정 추가금의 여부를 판단하고 내부 프로퍼티를 초기화함
        }
        public bool LimitOver(double v)
        {   //true를 반환하면 속도를 줄이라는 안내메시지를 출력
            if (v > limit)
            {
                limitNum++;
                return true;
            }
            else
            {
                limitNum--;
                if (limitNum < 0) limitNum = 0;
                return false;
            }
        }
        //https://moaco.tistory.com/7 과속단속기준 참조
        //이미 일정 시간 이상 과속했을 때 벌금을 부여하는 메소드. 속도를 얼마나 초과했는지에 따라 벌금을 차등 부과
        public int FineMoney(double v)
        {
            if (userFine) return Fine;
            else
            {
                if (v < limit + 10) return 0;
                else if (v < 20) return 3;
                else if (v < 40) return 6;
                else if (v < 60) return 9;
                else return 12;
            }
            
        }
    }

    class RMS
    {
        List<double> err_e = new List<double>();
        List<double> err_n = new List<double>();
        List<double> err_u = new List<double>();
        //ENU 좌표계 방향의 포인트 별 오차를 담을 리스트 선언

        public void avgFind(List<UserPoint> p, out double[] avg, out List<double> x, out List<double> y, out List<double> z)
        {   //평균 좌표를 찾는 메소드

            avg = new double[] { 0, 0, 0 };
            x = new List<double>();
            y = new List<double>();
            z = new List<double>();
            //각 성분별 좌표를 담을 리스트 선언, 최종 평균좌표 초기화

            for (int i = 0; i < p.Count; i++)
            {
                avg[0] += p[i].X;
                avg[1] += p[i].Y;
                avg[2] += p[i].Z;
                List<double> xyz = new List<double>() { p[i].X, p[i].Y, p[i].Z };
                x.Add(p[i].X);
                y.Add(p[i].Y);
                z.Add(p[i].Z);
                //평균을 구하기 위해 각 좌표의 성분별 합을 구하고, 객체 선언 후 이를 좌표에 추가함
            }
            avg[0] = avg[0] / p.Count;
            avg[1] = avg[1] / p.Count;
            avg[2] = avg[2] / p.Count;
            //평균 구하여 반환
        }
        public double[] errFind(List<double> x, List<double> y, List<double> z, double[] true_llh, double[] true_ecef)
        {   //성분별 오차를 찾아 rms로 반환하는 메소드

            double[] total = new double[3];
            double[] err = new double[3];
            double[] rms = new double[3];

            for(int i = 0; i < x.Count; i++)
            {
                ecef2enu(x[i], y[i], z[i], true_llh, true_ecef, out err);
                err_e.Add(err[0]);
                err_n.Add(err[1]);
                err_u.Add(err[2]);
                total[0] += Math.Pow(err[0], 2);
                total[1] += Math.Pow(err[1], 2);
                total[2] += Math.Pow(err[2], 2);
                //제곱한 값을 더하는 연산
            }
            rms[0] = Math.Sqrt(total[0] / err_e.Count());
            rms[1] = Math.Sqrt(total[1] / err_n.Count());
            rms[2] = Math.Sqrt(total[2] / err_u.Count());
            return rms;
            //좌표 성분별 오차를 연산하여 rms값으로 변경함
        }
        private void ecef2enu(double x, double y, double z, double[] true_llh, double[] true_ecef, out double[] err)
        {
            double e = 0.0810820288;
            double pi = Math.PI * true_llh[0] / 180.0;
            double lamb = Math.PI * true_llh[1] / 180.0;

            double k = 1 - Math.Pow(e, 2) * Math.Pow(Math.Sin(pi), 2);
            double pt = 6378000 / (Math.Sqrt(k));
            double pm = pt * (1 - Math.Pow(e, 2));

            double[] m = { x-true_ecef[0], y-true_ecef[1], z-true_ecef[2] };

            err = new double[3];
            err[0] = -Math.Sin(lamb) * m[0] + Math.Cos(lamb) * m[1];
            err[1] = -Math.Sin(pi) * Math.Cos(lamb) * m[0] - Math.Sin(pi) * Math.Sin(lamb) * m[1] + Math.Cos(pi) * m[2];
            err[2] = Math.Cos(pi) * Math.Cos(lamb) * m[0] + Math.Cos(pi) * Math.Sin(lamb) * m[1] + Math.Sin(pi) * m[2];

        }
    }
}
