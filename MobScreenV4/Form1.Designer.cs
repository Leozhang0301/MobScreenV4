
namespace MobScreenV4
{
    partial class MainFrom
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CtrlVerText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.versionText = new System.Windows.Forms.Label();
            this.BtnDebug = new System.Windows.Forms.Button();
            this.BtnRegister = new System.Windows.Forms.Button();
            this.BtnStayPoint = new System.Windows.Forms.Button();
            this.BtnMainCtrl = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PnlNav = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.minBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.pnlChild = new System.Windows.Forms.Panel();
            this.CTRLSerialPort = new System.IO.Ports.SerialPort(this.components);
            this.timer_timeControl = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.CtrlVerText);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.versionText);
            this.panel1.Controls.Add(this.BtnDebug);
            this.panel1.Controls.Add(this.BtnRegister);
            this.panel1.Controls.Add(this.BtnStayPoint);
            this.panel1.Controls.Add(this.BtnMainCtrl);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(139, 611);
            this.panel1.TabIndex = 0;
            // 
            // CtrlVerText
            // 
            this.CtrlVerText.AutoSize = true;
            this.CtrlVerText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CtrlVerText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.CtrlVerText.Location = new System.Drawing.Point(79, 576);
            this.CtrlVerText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CtrlVerText.Name = "CtrlVerText";
            this.CtrlVerText.Size = new System.Drawing.Size(59, 22);
            this.CtrlVerText.TabIndex = 8;
            this.CtrlVerText.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label2.Location = new System.Drawing.Point(10, 582);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "控制器版本:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(10, 546);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "上位机版本:";
            // 
            // versionText
            // 
            this.versionText.AutoSize = true;
            this.versionText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.versionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.versionText.Location = new System.Drawing.Point(80, 542);
            this.versionText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.versionText.Name = "versionText";
            this.versionText.Size = new System.Drawing.Size(59, 22);
            this.versionText.TabIndex = 5;
            this.versionText.Text = "label1";
            // 
            // BtnDebug
            // 
            this.BtnDebug.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnDebug.FlatAppearance.BorderSize = 0;
            this.BtnDebug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDebug.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnDebug.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.BtnDebug.Image = global::MobScreenV4.Properties.Resources.bianji;
            this.BtnDebug.Location = new System.Drawing.Point(0, 155);
            this.BtnDebug.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDebug.Name = "BtnDebug";
            this.BtnDebug.Size = new System.Drawing.Size(139, 35);
            this.BtnDebug.TabIndex = 4;
            this.BtnDebug.Text = "调试";
            this.BtnDebug.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnDebug.UseVisualStyleBackColor = true;
            this.BtnDebug.Click += new System.EventHandler(this.BtnDebug_Click);
            this.BtnDebug.Leave += new System.EventHandler(this.BtnDebug_Leave);
            // 
            // BtnRegister
            // 
            this.BtnRegister.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnRegister.FlatAppearance.BorderSize = 0;
            this.BtnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRegister.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.BtnRegister.Image = global::MobScreenV4.Properties.Resources.jinggao;
            this.BtnRegister.Location = new System.Drawing.Point(0, 120);
            this.BtnRegister.Margin = new System.Windows.Forms.Padding(2);
            this.BtnRegister.Name = "BtnRegister";
            this.BtnRegister.Size = new System.Drawing.Size(139, 35);
            this.BtnRegister.TabIndex = 3;
            this.BtnRegister.Text = "注册";
            this.BtnRegister.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnRegister.UseVisualStyleBackColor = true;
            this.BtnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            this.BtnRegister.Leave += new System.EventHandler(this.BtnRegister_Leave);
            // 
            // BtnStayPoint
            // 
            this.BtnStayPoint.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnStayPoint.FlatAppearance.BorderSize = 0;
            this.BtnStayPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStayPoint.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnStayPoint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.BtnStayPoint.Image = global::MobScreenV4.Properties.Resources.staypoint;
            this.BtnStayPoint.Location = new System.Drawing.Point(0, 85);
            this.BtnStayPoint.Margin = new System.Windows.Forms.Padding(2);
            this.BtnStayPoint.Name = "BtnStayPoint";
            this.BtnStayPoint.Size = new System.Drawing.Size(139, 35);
            this.BtnStayPoint.TabIndex = 2;
            this.BtnStayPoint.Text = "停留点";
            this.BtnStayPoint.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnStayPoint.UseVisualStyleBackColor = true;
            this.BtnStayPoint.Click += new System.EventHandler(this.BtnStayPoint_Click);
            this.BtnStayPoint.Leave += new System.EventHandler(this.BtnStayPoint_Leave);
            // 
            // BtnMainCtrl
            // 
            this.BtnMainCtrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnMainCtrl.FlatAppearance.BorderSize = 0;
            this.BtnMainCtrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMainCtrl.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnMainCtrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.BtnMainCtrl.Image = global::MobScreenV4.Properties.Resources.tiaoshi;
            this.BtnMainCtrl.Location = new System.Drawing.Point(0, 50);
            this.BtnMainCtrl.Margin = new System.Windows.Forms.Padding(2);
            this.BtnMainCtrl.Name = "BtnMainCtrl";
            this.BtnMainCtrl.Size = new System.Drawing.Size(139, 35);
            this.BtnMainCtrl.TabIndex = 1;
            this.BtnMainCtrl.Text = "主控制";
            this.BtnMainCtrl.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnMainCtrl.UseVisualStyleBackColor = true;
            this.BtnMainCtrl.Click += new System.EventHandler(this.BtnMainCtrl_Click);
            this.BtnMainCtrl.Leave += new System.EventHandler(this.BtnMainCtrl_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.PnlNav);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(139, 50);
            this.panel2.TabIndex = 0;
            // 
            // PnlNav
            // 
            this.PnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.PnlNav.Location = new System.Drawing.Point(0, 111);
            this.PnlNav.Margin = new System.Windows.Forms.Padding(2);
            this.PnlNav.Name = "PnlNav";
            this.PnlNav.Size = new System.Drawing.Size(2, 80);
            this.PnlNav.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.minBtn);
            this.panel3.Controls.Add(this.closeBtn);
            this.panel3.Location = new System.Drawing.Point(139, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(874, 50);
            this.panel3.TabIndex = 1;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseMove);
            // 
            // minBtn
            // 
            this.minBtn.BackColor = System.Drawing.Color.Transparent;
            this.minBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.minBtn.FlatAppearance.BorderSize = 0;
            this.minBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.minBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.minBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minBtn.Image = global::MobScreenV4.Properties.Resources.min;
            this.minBtn.Location = new System.Drawing.Point(806, 0);
            this.minBtn.Margin = new System.Windows.Forms.Padding(2);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(34, 50);
            this.minBtn.TabIndex = 1;
            this.minBtn.UseVisualStyleBackColor = false;
            this.minBtn.Click += new System.EventHandler(this.minBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.closeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Image = global::MobScreenV4.Properties.Resources.close;
            this.closeBtn.Location = new System.Drawing.Point(840, 0);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(34, 50);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // pnlChild
            // 
            this.pnlChild.Location = new System.Drawing.Point(139, 50);
            this.pnlChild.Margin = new System.Windows.Forms.Padding(2);
            this.pnlChild.Name = "pnlChild";
            this.pnlChild.Size = new System.Drawing.Size(870, 558);
            this.pnlChild.TabIndex = 2;
            // 
            // CTRLSerialPort
            // 
            this.CTRLSerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.CTRLSerialPort_DataReceived);
            // 
            // timer_timeControl
            // 
            this.timer_timeControl.Interval = 1000;
            this.timer_timeControl.Tick += new System.EventHandler(this.timer_timeControl_Tick);
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1012, 611);
            this.Controls.Add(this.pnlChild);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainFrom_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnDebug;
        private System.Windows.Forms.Button BtnRegister;
        private System.Windows.Forms.Button BtnStayPoint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel PnlNav;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlChild;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button minBtn;
        private System.Windows.Forms.Label versionText;
        public System.IO.Ports.SerialPort CTRLSerialPort;
        private System.Windows.Forms.Button BtnMainCtrl;
        private System.Windows.Forms.Label CtrlVerText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer_timeControl;
    }
}

