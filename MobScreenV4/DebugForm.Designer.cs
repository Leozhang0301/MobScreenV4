
namespace MobScreenV4
{
    partial class DebugForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rightAsStart = new System.Windows.Forms.RadioButton();
            this.leftAsStart = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.setMotorArgBtn = new System.Windows.Forms.Button();
            this.motorDecSpdNum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.motorIncrSpdNum = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.motorSpdNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DisLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.manualForwardBtn = new System.Windows.Forms.Button();
            this.manualBackBtn = new System.Windows.Forms.Button();
            this.timer_refreshUI = new System.Windows.Forms.Timer(this.components);
            this.consoleBox = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_validDisWrite = new System.Windows.Forms.Button();
            this.num_manualDis = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.num_excMove = new System.Windows.Forms.NumericUpDown();
            this.btn_excForward = new System.Windows.Forms.Button();
            this.btn_excBack = new System.Windows.Forms.Button();
            this.lab_validDis = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_CalValidDis = new System.Windows.Forms.Button();
            this.box_stayPoints = new System.Windows.Forms.ComboBox();
            this.btn_runtoPoint = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.motorDecSpdNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.motorIncrSpdNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.motorSpdNum)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_manualDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_excMove)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rightAsStart);
            this.groupBox1.Controls.Add(this.leftAsStart);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(15, 34);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(119, 112);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "起点选择";
            // 
            // rightAsStart
            // 
            this.rightAsStart.AutoSize = true;
            this.rightAsStart.Location = new System.Drawing.Point(21, 68);
            this.rightAsStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rightAsStart.Name = "rightAsStart";
            this.rightAsStart.Size = new System.Drawing.Size(91, 29);
            this.rightAsStart.TabIndex = 1;
            this.rightAsStart.TabStop = true;
            this.rightAsStart.Text = "右起点";
            this.rightAsStart.UseVisualStyleBackColor = true;
            this.rightAsStart.Click += new System.EventHandler(this.rightAsStart_Click);
            // 
            // leftAsStart
            // 
            this.leftAsStart.AutoSize = true;
            this.leftAsStart.Location = new System.Drawing.Point(21, 32);
            this.leftAsStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.leftAsStart.Name = "leftAsStart";
            this.leftAsStart.Size = new System.Drawing.Size(91, 29);
            this.leftAsStart.TabIndex = 0;
            this.leftAsStart.TabStop = true;
            this.leftAsStart.Text = "左起点";
            this.leftAsStart.UseVisualStyleBackColor = true;
            this.leftAsStart.Click += new System.EventHandler(this.leftAsStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.setMotorArgBtn);
            this.groupBox2.Controls.Add(this.motorDecSpdNum);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.motorIncrSpdNum);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.motorSpdNum);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(440, 34);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(388, 208);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "电机参数";
            // 
            // setMotorArgBtn
            // 
            this.setMotorArgBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.setMotorArgBtn.Location = new System.Drawing.Point(252, 155);
            this.setMotorArgBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.setMotorArgBtn.Name = "setMotorArgBtn";
            this.setMotorArgBtn.Size = new System.Drawing.Size(123, 46);
            this.setMotorArgBtn.TabIndex = 8;
            this.setMotorArgBtn.Text = "写入控制器";
            this.setMotorArgBtn.UseVisualStyleBackColor = true;
            this.setMotorArgBtn.Click += new System.EventHandler(this.setMotorArgBtn_Click);
            // 
            // motorDecSpdNum
            // 
            this.motorDecSpdNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.motorDecSpdNum.Location = new System.Drawing.Point(32, 152);
            this.motorDecSpdNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.motorDecSpdNum.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.motorDecSpdNum.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.motorDecSpdNum.Name = "motorDecSpdNum";
            this.motorDecSpdNum.Size = new System.Drawing.Size(97, 27);
            this.motorDecSpdNum.TabIndex = 7;
            this.motorDecSpdNum.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(248, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "范围:100-3000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "减速度(值越小，减速越慢):";
            // 
            // motorIncrSpdNum
            // 
            this.motorIncrSpdNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.motorIncrSpdNum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.motorIncrSpdNum.Location = new System.Drawing.Point(32, 95);
            this.motorIncrSpdNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.motorIncrSpdNum.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.motorIncrSpdNum.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.motorIncrSpdNum.Name = "motorIncrSpdNum";
            this.motorIncrSpdNum.Size = new System.Drawing.Size(97, 27);
            this.motorIncrSpdNum.TabIndex = 4;
            this.motorIncrSpdNum.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(248, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "范围:100-3000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "加速度(值越小，加速越慢):";
            // 
            // motorSpdNum
            // 
            this.motorSpdNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.motorSpdNum.Location = new System.Drawing.Point(280, 28);
            this.motorSpdNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.motorSpdNum.Name = "motorSpdNum";
            this.motorSpdNum.Size = new System.Drawing.Size(68, 27);
            this.motorSpdNum.TabIndex = 1;
            this.motorSpdNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "运行速度(值越大，速度越快):\r\n";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DisLabel);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.manualForwardBtn);
            this.groupBox3.Controls.Add(this.manualBackBtn);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(15, 160);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(280, 167);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "手动控制";
            // 
            // DisLabel
            // 
            this.DisLabel.AutoSize = true;
            this.DisLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.DisLabel.Location = new System.Drawing.Point(68, 113);
            this.DisLabel.Name = "DisLabel";
            this.DisLabel.Size = new System.Drawing.Size(39, 25);
            this.DisLabel.TabIndex = 4;
            this.DisLabel.Text = "0.0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "距离:            MM";
            // 
            // manualForwardBtn
            // 
            this.manualForwardBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.manualForwardBtn.Location = new System.Drawing.Point(138, 37);
            this.manualForwardBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.manualForwardBtn.Name = "manualForwardBtn";
            this.manualForwardBtn.Size = new System.Drawing.Size(90, 59);
            this.manualForwardBtn.TabIndex = 1;
            this.manualForwardBtn.Text = "前进";
            this.manualForwardBtn.UseVisualStyleBackColor = true;
            this.manualForwardBtn.Click += new System.EventHandler(this.manualForwardBtn_Click);
            // 
            // manualBackBtn
            // 
            this.manualBackBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.manualBackBtn.Location = new System.Drawing.Point(16, 37);
            this.manualBackBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.manualBackBtn.Name = "manualBackBtn";
            this.manualBackBtn.Size = new System.Drawing.Size(90, 59);
            this.manualBackBtn.TabIndex = 0;
            this.manualBackBtn.Text = "后退";
            this.manualBackBtn.UseVisualStyleBackColor = true;
            this.manualBackBtn.Click += new System.EventHandler(this.manualBackBtn_Click);
            // 
            // timer_refreshUI
            // 
            this.timer_refreshUI.Tick += new System.EventHandler(this.timer_refreshUI_Tick);
            // 
            // consoleBox
            // 
            this.consoleBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consoleBox.Location = new System.Drawing.Point(14, 649);
            this.consoleBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ReadOnly = true;
            this.consoleBox.Size = new System.Drawing.Size(828, 174);
            this.consoleBox.TabIndex = 4;
            this.consoleBox.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.btn_validDisWrite);
            this.groupBox4.Controls.Add(this.num_manualDis);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.num_excMove);
            this.groupBox4.Controls.Add(this.btn_excForward);
            this.groupBox4.Controls.Add(this.btn_excBack);
            this.groupBox4.Controls.Add(this.lab_validDis);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.btn_CalValidDis);
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(15, 382);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(813, 169);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "调试";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(316, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(316, 22);
            this.label10.TabIndex = 13;
            this.label10.Text = "总距离=有效距离+462MM(限位开关距离)";
            // 
            // btn_validDisWrite
            // 
            this.btn_validDisWrite.FlatAppearance.BorderSize = 0;
            this.btn_validDisWrite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_validDisWrite.Location = new System.Drawing.Point(651, 95);
            this.btn_validDisWrite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_validDisWrite.Name = "btn_validDisWrite";
            this.btn_validDisWrite.Size = new System.Drawing.Size(148, 54);
            this.btn_validDisWrite.TabIndex = 12;
            this.btn_validDisWrite.Text = "写入控制器";
            this.btn_validDisWrite.UseVisualStyleBackColor = true;
            this.btn_validDisWrite.Click += new System.EventHandler(this.btn_validDisWrite_Click);
            // 
            // num_manualDis
            // 
            this.num_manualDis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.num_manualDis.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_manualDis.Location = new System.Drawing.Point(496, 121);
            this.num_manualDis.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.num_manualDis.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.num_manualDis.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_manualDis.Name = "num_manualDis";
            this.num_manualDis.Size = new System.Drawing.Size(89, 27);
            this.num_manualDis.TabIndex = 11;
            this.num_manualDis.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(568, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 31);
            this.label9.TabIndex = 10;
            this.label9.Text = "MM";
            // 
            // num_excMove
            // 
            this.num_excMove.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.num_excMove.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_excMove.Location = new System.Drawing.Point(435, 40);
            this.num_excMove.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.num_excMove.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_excMove.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_excMove.Name = "num_excMove";
            this.num_excMove.Size = new System.Drawing.Size(126, 27);
            this.num_excMove.TabIndex = 9;
            this.num_excMove.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_excForward
            // 
            this.btn_excForward.FlatAppearance.BorderSize = 0;
            this.btn_excForward.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_excForward.Location = new System.Drawing.Point(651, 31);
            this.btn_excForward.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_excForward.Name = "btn_excForward";
            this.btn_excForward.Size = new System.Drawing.Size(122, 41);
            this.btn_excForward.TabIndex = 8;
            this.btn_excForward.Text = "精确前进";
            this.btn_excForward.UseVisualStyleBackColor = true;
            this.btn_excForward.Click += new System.EventHandler(this.btn_excForward_Click);
            // 
            // btn_excBack
            // 
            this.btn_excBack.FlatAppearance.BorderSize = 0;
            this.btn_excBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_excBack.Location = new System.Drawing.Point(307, 31);
            this.btn_excBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_excBack.Name = "btn_excBack";
            this.btn_excBack.Size = new System.Drawing.Size(122, 41);
            this.btn_excBack.TabIndex = 7;
            this.btn_excBack.Text = "精确后退";
            this.btn_excBack.UseVisualStyleBackColor = true;
            this.btn_excBack.Click += new System.EventHandler(this.btn_excBack_Click);
            // 
            // lab_validDis
            // 
            this.lab_validDis.AutoSize = true;
            this.lab_validDis.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_validDis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lab_validDis.Location = new System.Drawing.Point(133, 100);
            this.lab_validDis.Name = "lab_validDis";
            this.lab_validDis.Size = new System.Drawing.Size(51, 31);
            this.lab_validDis.TabIndex = 6;
            this.lab_validDis.Text = "0.0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(17, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(251, 31);
            this.label8.TabIndex = 5;
            this.label8.Text = "有效距离:            MM";
            // 
            // btn_CalValidDis
            // 
            this.btn_CalValidDis.FlatAppearance.BorderSize = 0;
            this.btn_CalValidDis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_CalValidDis.Location = new System.Drawing.Point(21, 31);
            this.btn_CalValidDis.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_CalValidDis.Name = "btn_CalValidDis";
            this.btn_CalValidDis.Size = new System.Drawing.Size(197, 65);
            this.btn_CalValidDis.TabIndex = 0;
            this.btn_CalValidDis.Text = "测量有效距离";
            this.btn_CalValidDis.UseVisualStyleBackColor = true;
            this.btn_CalValidDis.Click += new System.EventHandler(this.btn_CalValidDis_Click);
            // 
            // box_stayPoints
            // 
            this.box_stayPoints.FormattingEnabled = true;
            this.box_stayPoints.Location = new System.Drawing.Point(15, 338);
            this.box_stayPoints.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.box_stayPoints.Name = "box_stayPoints";
            this.box_stayPoints.Size = new System.Drawing.Size(65, 26);
            this.box_stayPoints.TabIndex = 6;
            // 
            // btn_runtoPoint
            // 
            this.btn_runtoPoint.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runtoPoint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_runtoPoint.Location = new System.Drawing.Point(110, 338);
            this.btn_runtoPoint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_runtoPoint.Name = "btn_runtoPoint";
            this.btn_runtoPoint.Size = new System.Drawing.Size(160, 42);
            this.btn_runtoPoint.TabIndex = 7;
            this.btn_runtoPoint.Text = "运行到此停留点";
            this.btn_runtoPoint.UseVisualStyleBackColor = true;
            this.btn_runtoPoint.Click += new System.EventHandler(this.btn_runtoPoint_Click);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1306, 838);
            this.Controls.Add(this.btn_runtoPoint);
            this.Controls.Add(this.box_stayPoints);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.consoleBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DebugForm";
            this.Text = "DebugForm";
            this.Load += new System.EventHandler(this.DebugForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.motorDecSpdNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.motorIncrSpdNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.motorSpdNum)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_manualDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_excMove)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rightAsStart;
        private System.Windows.Forms.RadioButton leftAsStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown motorDecSpdNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown motorIncrSpdNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown motorSpdNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button setMotorArgBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button manualForwardBtn;
        private System.Windows.Forms.Button manualBackBtn;
        private System.Windows.Forms.Label DisLabel;
        private System.Windows.Forms.Timer timer_refreshUI;
        private System.Windows.Forms.RichTextBox consoleBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_validDisWrite;
        private System.Windows.Forms.NumericUpDown num_manualDis;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown num_excMove;
        private System.Windows.Forms.Button btn_excForward;
        private System.Windows.Forms.Button btn_excBack;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_CalValidDis;
        public System.Windows.Forms.Label lab_validDis;
        private System.Windows.Forms.ComboBox box_stayPoints;
        private System.Windows.Forms.Button btn_runtoPoint;
    }
}