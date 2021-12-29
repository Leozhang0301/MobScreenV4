
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
            this.btn_run = new System.Windows.Forms.Button();
            this.btn_stopRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_run
            // 
            this.btn_run.FlatAppearance.BorderSize = 0;
            this.btn_run.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_run.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_run.Location = new System.Drawing.Point(760, 125);
            this.btn_run.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(152, 108);
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
            this.btn_stopRun.Location = new System.Drawing.Point(760, 302);
            this.btn_stopRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_stopRun.Name = "btn_stopRun";
            this.btn_stopRun.Size = new System.Drawing.Size(152, 108);
            this.btn_stopRun.TabIndex = 1;
            this.btn_stopRun.Text = "停止运行";
            this.btn_stopRun.UseVisualStyleBackColor = true;
            // 
            // MainCtrlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1161, 698);
            this.Controls.Add(this.btn_stopRun);
            this.Controls.Add(this.btn_run);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainCtrlForm";
            this.Text = "MainCtrlForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Button btn_stopRun;
    }
}