
namespace MobScreenV4
{
    partial class MainCtrlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainCtrlForm));
            this.btn_run = new System.Windows.Forms.Button();
            this.btn_stopRun = new System.Windows.Forms.Button();
            this.grpbx_mode = new System.Windows.Forms.GroupBox();
            this.radioBtn_manual = new System.Windows.Forms.RadioButton();
            this.radioBtn_contentCtl = new System.Windows.Forms.RadioButton();
            this.radioBtn_timeCtl = new System.Windows.Forms.RadioButton();
            this.radioBtn_runOnce = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBtn_notReverse = new System.Windows.Forms.RadioButton();
            this.radioBtn_reverse = new System.Windows.Forms.RadioButton();
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.grpbx_mode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_run
            // 
            this.btn_run.FlatAppearance.BorderSize = 0;
            this.btn_run.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_run.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_run.Location = new System.Drawing.Point(570, 100);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(114, 86);
            this.btn_run.TabIndex = 0;
            this.btn_run.Text = "开始运行";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_stopRun
            // 
            this.btn_stopRun.FlatAppearance.BorderSize = 0;
            this.btn_stopRun.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_stopRun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_stopRun.Location = new System.Drawing.Point(570, 242);
            this.btn_stopRun.Name = "btn_stopRun";
            this.btn_stopRun.Size = new System.Drawing.Size(114, 86);
            this.btn_stopRun.TabIndex = 1;
            this.btn_stopRun.Text = "停止运行";
            this.btn_stopRun.UseVisualStyleBackColor = true;
            this.btn_stopRun.Click += new System.EventHandler(this.btn_stopRun_Click);
            // 
            // grpbx_mode
            // 
            this.grpbx_mode.Controls.Add(this.radioBtn_manual);
            this.grpbx_mode.Controls.Add(this.radioBtn_contentCtl);
            this.grpbx_mode.Controls.Add(this.radioBtn_timeCtl);
            this.grpbx_mode.Controls.Add(this.radioBtn_runOnce);
            this.grpbx_mode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpbx_mode.ForeColor = System.Drawing.Color.White;
            this.grpbx_mode.Location = new System.Drawing.Point(85, 100);
            this.grpbx_mode.Name = "grpbx_mode";
            this.grpbx_mode.Size = new System.Drawing.Size(366, 125);
            this.grpbx_mode.TabIndex = 2;
            this.grpbx_mode.TabStop = false;
            this.grpbx_mode.Text = "系统工作模式选择";
            // 
            // radioBtn_manual
            // 
            this.radioBtn_manual.AutoSize = true;
            this.radioBtn_manual.Enabled = false;
            this.radioBtn_manual.Location = new System.Drawing.Point(20, 72);
            this.radioBtn_manual.Name = "radioBtn_manual";
            this.radioBtn_manual.Size = new System.Drawing.Size(153, 31);
            this.radioBtn_manual.TabIndex = 3;
            this.radioBtn_manual.TabStop = true;
            this.radioBtn_manual.Text = "手动控制模式";
            this.radioBtn_manual.UseVisualStyleBackColor = true;
            this.radioBtn_manual.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioBtn_manual_MouseClick);
            // 
            // radioBtn_contentCtl
            // 
            this.radioBtn_contentCtl.AutoSize = true;
            this.radioBtn_contentCtl.Enabled = false;
            this.radioBtn_contentCtl.Location = new System.Drawing.Point(209, 72);
            this.radioBtn_contentCtl.Name = "radioBtn_contentCtl";
            this.radioBtn_contentCtl.Size = new System.Drawing.Size(167, 31);
            this.radioBtn_contentCtl.TabIndex = 2;
            this.radioBtn_contentCtl.TabStop = true;
            this.radioBtn_contentCtl.Text = "自动(节目控制)";
            this.radioBtn_contentCtl.UseVisualStyleBackColor = true;
            this.radioBtn_contentCtl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioBtn_contentCtl_MouseClick);
            // 
            // radioBtn_timeCtl
            // 
            this.radioBtn_timeCtl.AutoSize = true;
            this.radioBtn_timeCtl.Enabled = false;
            this.radioBtn_timeCtl.Location = new System.Drawing.Point(209, 30);
            this.radioBtn_timeCtl.Name = "radioBtn_timeCtl";
            this.radioBtn_timeCtl.Size = new System.Drawing.Size(167, 31);
            this.radioBtn_timeCtl.TabIndex = 1;
            this.radioBtn_timeCtl.TabStop = true;
            this.radioBtn_timeCtl.Text = "自动(时间控制)";
            this.radioBtn_timeCtl.UseVisualStyleBackColor = true;
            this.radioBtn_timeCtl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioBtn_timeCtl_MouseClick);
            // 
            // radioBtn_runOnce
            // 
            this.radioBtn_runOnce.AutoSize = true;
            this.radioBtn_runOnce.Enabled = false;
            this.radioBtn_runOnce.Location = new System.Drawing.Point(20, 30);
            this.radioBtn_runOnce.Name = "radioBtn_runOnce";
            this.radioBtn_runOnce.Size = new System.Drawing.Size(213, 31);
            this.radioBtn_runOnce.TabIndex = 0;
            this.radioBtn_runOnce.TabStop = true;
            this.radioBtn_runOnce.Text = "运行一个循环后待机";
            this.radioBtn_runOnce.UseVisualStyleBackColor = true;
            this.radioBtn_runOnce.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioBtn_runOnce_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtn_notReverse);
            this.groupBox1.Controls.Add(this.radioBtn_reverse);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(85, 258);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 124);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "循环模式";
            // 
            // radioBtn_notReverse
            // 
            this.radioBtn_notReverse.AutoSize = true;
            this.radioBtn_notReverse.Enabled = false;
            this.radioBtn_notReverse.Location = new System.Drawing.Point(20, 69);
            this.radioBtn_notReverse.Name = "radioBtn_notReverse";
            this.radioBtn_notReverse.Size = new System.Drawing.Size(173, 31);
            this.radioBtn_notReverse.TabIndex = 5;
            this.radioBtn_notReverse.TabStop = true;
            this.radioBtn_notReverse.Text = "终点后从头开始";
            this.radioBtn_notReverse.UseVisualStyleBackColor = true;
            this.radioBtn_notReverse.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioBtn_notReverse_MouseClick);
            // 
            // radioBtn_reverse
            // 
            this.radioBtn_reverse.AutoSize = true;
            this.radioBtn_reverse.Enabled = false;
            this.radioBtn_reverse.Location = new System.Drawing.Point(20, 28);
            this.radioBtn_reverse.Name = "radioBtn_reverse";
            this.radioBtn_reverse.Size = new System.Drawing.Size(173, 31);
            this.radioBtn_reverse.TabIndex = 4;
            this.radioBtn_reverse.TabStop = true;
            this.radioBtn_reverse.Text = "终点后倒序返回";
            this.radioBtn_reverse.UseVisualStyleBackColor = true;
            this.radioBtn_reverse.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioBtn_reverse_MouseClick);
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(508, 347);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(255, 169);
            this.mediaPlayer.TabIndex = 4;
            this.mediaPlayer.ClickEvent += new AxWMPLib._WMPOCXEvents_ClickEventHandler(this.axWindowsMediaPlayer1_ClickEvent);
            // 
            // MainCtrlForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(871, 558);
            this.Controls.Add(this.mediaPlayer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpbx_mode);
            this.Controls.Add(this.btn_stopRun);
            this.Controls.Add(this.btn_run);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainCtrlForm";
            this.Text = "MainCtrlForm";
            this.grpbx_mode.ResumeLayout(false);
            this.grpbx_mode.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Button btn_stopRun;
        private System.Windows.Forms.GroupBox grpbx_mode;
        private System.Windows.Forms.RadioButton radioBtn_manual;
        private System.Windows.Forms.RadioButton radioBtn_contentCtl;
        private System.Windows.Forms.RadioButton radioBtn_timeCtl;
        private System.Windows.Forms.RadioButton radioBtn_runOnce;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtn_notReverse;
        private System.Windows.Forms.RadioButton radioBtn_reverse;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
    }
}