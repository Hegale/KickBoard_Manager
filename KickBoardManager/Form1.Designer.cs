
namespace KickBoardManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.unavailPolygon = new System.Windows.Forms.Button();
            this.UnavailPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.availPolygon = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.AvailPath = new System.Windows.Forms.TextBox();
            this.UserPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userPoints = new System.Windows.Forms.Button();
            this.openUserPoints = new System.Windows.Forms.OpenFileDialog();
            this.openAvailPolys = new System.Windows.Forms.OpenFileDialog();
            this.openUnavailPolys = new System.Windows.Forms.OpenFileDialog();
            this.fineText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.parkingText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.saveName = new System.Windows.Forms.TextBox();
            this.saveFile = new System.Windows.Forms.Button();
            this.savePath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.distanceText = new System.Windows.Forms.TextBox();
            this.velocityText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rmsCheck = new System.Windows.Forms.Button();
            this.velocityLimit = new System.Windows.Forms.ComboBox();
            this.fineMoney = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ecefFile = new System.Windows.Forms.Button();
            this.xyzPath = new System.Windows.Forms.TextBox();
            this.openUserEcef = new System.Windows.Forms.OpenFileDialog();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rms_u = new System.Windows.Forms.TextBox();
            this.rms_n = new System.Windows.Forms.TextBox();
            this.rms_e = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.unavailPolygon);
            this.groupBox1.Controls.Add(this.UnavailPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.availPolygon);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.AvailPath);
            this.groupBox1.Controls.Add(this.UserPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.userPoints);
            this.groupBox1.Location = new System.Drawing.Point(455, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "입력 파일 관리";
            // 
            // unavailPolygon
            // 
            this.unavailPolygon.Location = new System.Drawing.Point(189, 168);
            this.unavailPolygon.Name = "unavailPolygon";
            this.unavailPolygon.Size = new System.Drawing.Size(47, 23);
            this.unavailPolygon.TabIndex = 8;
            this.unavailPolygon.Text = "열기";
            this.unavailPolygon.UseVisualStyleBackColor = true;
            this.unavailPolygon.Click += new System.EventHandler(this.unavailPolygon_Click);
            // 
            // UnavailPath
            // 
            this.UnavailPath.Location = new System.Drawing.Point(16, 168);
            this.UnavailPath.Name = "UnavailPath";
            this.UnavailPath.Size = new System.Drawing.Size(167, 23);
            this.UnavailPath.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "주차 불가능 구역 폴리곤 선택";
            // 
            // availPolygon
            // 
            this.availPolygon.Location = new System.Drawing.Point(189, 108);
            this.availPolygon.Name = "availPolygon";
            this.availPolygon.Size = new System.Drawing.Size(47, 23);
            this.availPolygon.TabIndex = 5;
            this.availPolygon.Text = "열기";
            this.availPolygon.UseVisualStyleBackColor = true;
            this.availPolygon.Click += new System.EventHandler(this.availPolygon_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "주차 가능 구역 폴리곤 선택";
            // 
            // AvailPath
            // 
            this.AvailPath.Location = new System.Drawing.Point(16, 108);
            this.AvailPath.Name = "AvailPath";
            this.AvailPath.Size = new System.Drawing.Size(167, 23);
            this.AvailPath.TabIndex = 3;
            // 
            // UserPath
            // 
            this.UserPath.Location = new System.Drawing.Point(16, 49);
            this.UserPath.Name = "UserPath";
            this.UserPath.Size = new System.Drawing.Size(167, 23);
            this.UserPath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "사용자 위치 파일 선택";
            // 
            // userPoints
            // 
            this.userPoints.Location = new System.Drawing.Point(189, 49);
            this.userPoints.Name = "userPoints";
            this.userPoints.Size = new System.Drawing.Size(47, 23);
            this.userPoints.TabIndex = 0;
            this.userPoints.Text = "열기";
            this.userPoints.UseVisualStyleBackColor = true;
            this.userPoints.Click += new System.EventHandler(this.userPoints_Click);
            // 
            // openUserPoints
            // 
            this.openUserPoints.FileName = "UserPoints";
            // 
            // openAvailPolys
            // 
            this.openAvailPolys.FileName = "openFileDialog1";
            // 
            // openUnavailPolys
            // 
            this.openUnavailPolys.FileName = "openFileDialog2";
            // 
            // fineText
            // 
            this.fineText.Location = new System.Drawing.Point(343, 60);
            this.fineText.Multiline = true;
            this.fineText.Name = "fineText";
            this.fineText.Size = new System.Drawing.Size(103, 204);
            this.fineText.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(343, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "벌금 현황";
            // 
            // parkingText
            // 
            this.parkingText.Location = new System.Drawing.Point(12, 60);
            this.parkingText.Multiline = true;
            this.parkingText.Name = "parkingText";
            this.parkingText.Size = new System.Drawing.Size(325, 204);
            this.parkingText.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "주차 현황";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(527, 420);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(121, 36);
            this.start.TabIndex = 9;
            this.start.Text = "프로그램 실행";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.saveName);
            this.groupBox2.Controls.Add(this.saveFile);
            this.groupBox2.Controls.Add(this.savePath);
            this.groupBox2.Location = new System.Drawing.Point(455, 278);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 87);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "출력 파일 관리";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 15);
            this.label13.TabIndex = 11;
            this.label13.Text = "파일명 :";
            // 
            // saveName
            // 
            this.saveName.Location = new System.Drawing.Point(72, 54);
            this.saveName.Name = "saveName";
            this.saveName.Size = new System.Drawing.Size(164, 23);
            this.saveName.TabIndex = 10;
            // 
            // saveFile
            // 
            this.saveFile.Location = new System.Drawing.Point(189, 22);
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(47, 23);
            this.saveFile.TabIndex = 9;
            this.saveFile.Text = "저장";
            this.saveFile.UseVisualStyleBackColor = true;
            this.saveFile.Click += new System.EventHandler(this.saveFile_Click);
            // 
            // savePath
            // 
            this.savePath.Location = new System.Drawing.Point(16, 22);
            this.savePath.Name = "savePath";
            this.savePath.Size = new System.Drawing.Size(167, 23);
            this.savePath.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.distanceText);
            this.groupBox3.Controls.Add(this.velocityText);
            this.groupBox3.Location = new System.Drawing.Point(157, 272);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(289, 93);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "속도 및 이동거리";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "이동 거리 :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "현재 속도 :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(257, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "m^2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(257, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "m/s";
            // 
            // distanceText
            // 
            this.distanceText.Location = new System.Drawing.Point(78, 61);
            this.distanceText.Name = "distanceText";
            this.distanceText.Size = new System.Drawing.Size(178, 23);
            this.distanceText.TabIndex = 1;
            // 
            // velocityText
            // 
            this.velocityText.Location = new System.Drawing.Point(78, 29);
            this.velocityText.Name = "velocityText";
            this.velocityText.Size = new System.Drawing.Size(178, 23);
            this.velocityText.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(602, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "19011051 김주연";
            // 
            // rmsCheck
            // 
            this.rmsCheck.Location = new System.Drawing.Point(58, 71);
            this.rmsCheck.Name = "rmsCheck";
            this.rmsCheck.Size = new System.Drawing.Size(121, 36);
            this.rmsCheck.TabIndex = 14;
            this.rmsCheck.Text = "rms 확인";
            this.rmsCheck.UseVisualStyleBackColor = true;
            this.rmsCheck.Click += new System.EventHandler(this.rmsCheck_Click);
            // 
            // velocityLimit
            // 
            this.velocityLimit.FormattingEnabled = true;
            this.velocityLimit.Items.AddRange(new object[] {
            "10",
            "15",
            "20",
            "25",
            "30",
            "40",
            "50"});
            this.velocityLimit.Location = new System.Drawing.Point(12, 28);
            this.velocityLimit.Name = "velocityLimit";
            this.velocityLimit.Size = new System.Drawing.Size(79, 23);
            this.velocityLimit.TabIndex = 19;
            // 
            // fineMoney
            // 
            this.fineMoney.FormattingEnabled = true;
            this.fineMoney.Items.AddRange(new object[] {
            "1",
            "2",
            "5",
            "10",
            "20",
            "30",
            "40"});
            this.fineMoney.Location = new System.Drawing.Point(12, 60);
            this.fineMoney.Name = "fineMoney";
            this.fineMoney.Size = new System.Drawing.Size(79, 23);
            this.fineMoney.TabIndex = 20;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.velocityLimit);
            this.groupBox4.Controls.Add(this.fineMoney);
            this.groupBox4.Location = new System.Drawing.Point(12, 272);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(139, 93);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "제한속도/추가금";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(97, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 15);
            this.label12.TabIndex = 22;
            this.label12.Text = "만원";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(97, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 15);
            this.label11.TabIndex = 21;
            this.label11.Text = "km/h";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ecefFile);
            this.groupBox5.Controls.Add(this.xyzPath);
            this.groupBox5.Controls.Add(this.rmsCheck);
            this.groupBox5.Location = new System.Drawing.Point(12, 371);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(262, 129);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "rms 측정";
            // 
            // ecefFile
            // 
            this.ecefFile.Location = new System.Drawing.Point(145, 30);
            this.ecefFile.Name = "ecefFile";
            this.ecefFile.Size = new System.Drawing.Size(94, 23);
            this.ecefFile.TabIndex = 16;
            this.ecefFile.Text = "ecef 파일 입력";
            this.ecefFile.UseVisualStyleBackColor = true;
            this.ecefFile.Click += new System.EventHandler(this.ecefFile_Click);
            // 
            // xyzPath
            // 
            this.xyzPath.Location = new System.Drawing.Point(12, 30);
            this.xyzPath.Name = "xyzPath";
            this.xyzPath.Size = new System.Drawing.Size(127, 23);
            this.xyzPath.TabIndex = 15;
            // 
            // openUserEcef
            // 
            this.openUserEcef.FileName = "openFileDialog1";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rms_u);
            this.groupBox6.Controls.Add(this.rms_n);
            this.groupBox6.Controls.Add(this.rms_e);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Location = new System.Drawing.Point(280, 371);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(167, 129);
            this.groupBox6.TabIndex = 23;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "rms 결과";
            // 
            // rms_u
            // 
            this.rms_u.Location = new System.Drawing.Point(51, 92);
            this.rms_u.Name = "rms_u";
            this.rms_u.Size = new System.Drawing.Size(100, 23);
            this.rms_u.TabIndex = 1;
            // 
            // rms_n
            // 
            this.rms_n.Location = new System.Drawing.Point(51, 60);
            this.rms_n.Name = "rms_n";
            this.rms_n.Size = new System.Drawing.Size(100, 23);
            this.rms_n.TabIndex = 1;
            // 
            // rms_e
            // 
            this.rms_e.Location = new System.Drawing.Point(51, 27);
            this.rms_e.Name = "rms_e";
            this.rms_e.Size = new System.Drawing.Size(100, 23);
            this.rms_e.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 95);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 15);
            this.label16.TabIndex = 0;
            this.label16.Text = "rms_u";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "rms_n";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "rms_e";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 512);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.start);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.parkingText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fineText);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "킥보드 주차 프로그램";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button userPoints;
        private System.Windows.Forms.OpenFileDialog openUserPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button unavailPolygon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button availPolygon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openAvailPolys;
        private System.Windows.Forms.OpenFileDialog openUnavailPolys;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button saveFile;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public System.Windows.Forms.TextBox UserPath;
        public System.Windows.Forms.TextBox UnavailPath;
        public System.Windows.Forms.TextBox AvailPath;
        public System.Windows.Forms.TextBox fineText;
        public System.Windows.Forms.TextBox parkingText;
        public System.Windows.Forms.TextBox savePath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox distance;
        public System.Windows.Forms.TextBox velocityText;
        public System.Windows.Forms.TextBox distanceText;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button rmsCheck;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox saveName;
        private System.Windows.Forms.ComboBox velocityLimit;
        private System.Windows.Forms.ComboBox fineMoney;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button ecefFile;
        public System.Windows.Forms.TextBox xyzPath;
        private System.Windows.Forms.OpenFileDialog openUserEcef;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox rms_u;
        private System.Windows.Forms.TextBox rms_n;
        private System.Windows.Forms.TextBox rms_e;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
    }
}

