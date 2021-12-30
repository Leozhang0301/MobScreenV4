
namespace MobScreenV4
{
    partial class StayPointForm
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
            this.stayPointGridView = new System.Windows.Forms.DataGridView();
            this.cnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stayTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.offsides = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_readCtl = new System.Windows.Forms.Button();
            this.btn_writeCtl = new System.Windows.Forms.Button();
            this.btn_clearForm = new System.Windows.Forms.Button();
            this.btn_insertPnt = new System.Windows.Forms.Button();
            this.btn_delPnt = new System.Windows.Forms.Button();
            this.btn_addPnt = new System.Windows.Forms.Button();
            this.text_remarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.text_filePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_time = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.text_dis = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label_posi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_recordposi = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_forward = new System.Windows.Forms.Button();
            this.consoleBox = new System.Windows.Forms.RichTextBox();
            this.timer_refreshUI = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.stayPointGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // stayPointGridView
            // 
            this.stayPointGridView.AllowUserToAddRows = false;
            this.stayPointGridView.AllowUserToDeleteRows = false;
            this.stayPointGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnt,
            this.distance,
            this.stayTime,
            this.filePath,
            this.remarks,
            this.offsides});
            this.stayPointGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.stayPointGridView.Location = new System.Drawing.Point(68, 37);
            this.stayPointGridView.Margin = new System.Windows.Forms.Padding(2);
            this.stayPointGridView.Name = "stayPointGridView";
            this.stayPointGridView.RowHeadersWidth = 51;
            this.stayPointGridView.RowTemplate.Height = 27;
            this.stayPointGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.stayPointGridView.Size = new System.Drawing.Size(732, 149);
            this.stayPointGridView.TabIndex = 0;
            this.stayPointGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.stayPointGridView_CellEndEdit);
            this.stayPointGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.stayPointGridView_CellMouseDoubleClick);
            // 
            // cnt
            // 
            this.cnt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnt.HeaderText = "序号";
            this.cnt.MinimumWidth = 6;
            this.cnt.Name = "cnt";
            this.cnt.Width = 40;
            // 
            // distance
            // 
            this.distance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.distance.HeaderText = "运行距离(MM)";
            this.distance.MinimumWidth = 6;
            this.distance.Name = "distance";
            // 
            // stayTime
            // 
            this.stayTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.stayTime.HeaderText = "停留时间(S)";
            this.stayTime.MinimumWidth = 6;
            this.stayTime.Name = "stayTime";
            // 
            // filePath
            // 
            this.filePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.filePath.HeaderText = "文本路径";
            this.filePath.MinimumWidth = 6;
            this.filePath.Name = "filePath";
            // 
            // remarks
            // 
            this.remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.remarks.HeaderText = "备注";
            this.remarks.MinimumWidth = 6;
            this.remarks.Name = "remarks";
            this.remarks.Width = 60;
            // 
            // offsides
            // 
            this.offsides.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.offsides.HeaderText = "底图偏移";
            this.offsides.MinimumWidth = 6;
            this.offsides.Name = "offsides";
            this.offsides.Width = 70;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_readCtl);
            this.groupBox1.Controls.Add(this.btn_writeCtl);
            this.groupBox1.Controls.Add(this.btn_clearForm);
            this.groupBox1.Controls.Add(this.btn_insertPnt);
            this.groupBox1.Controls.Add(this.btn_delPnt);
            this.groupBox1.Controls.Add(this.btn_addPnt);
            this.groupBox1.Controls.Add(this.text_remarks);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.text_filePath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.text_time);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.text_dis);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(68, 206);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 239);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "填写停留点信息，点击添加按钮添加。添加完成后点击写入控制器";
            // 
            // btn_readCtl
            // 
            this.btn_readCtl.FlatAppearance.BorderSize = 0;
            this.btn_readCtl.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_readCtl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_readCtl.Location = new System.Drawing.Point(438, 141);
            this.btn_readCtl.Name = "btn_readCtl";
            this.btn_readCtl.Size = new System.Drawing.Size(123, 81);
            this.btn_readCtl.TabIndex = 13;
            this.btn_readCtl.Text = "读取控制器";
            this.btn_readCtl.UseVisualStyleBackColor = true;
            this.btn_readCtl.Click += new System.EventHandler(this.btn_readCtl_Click);
            // 
            // btn_writeCtl
            // 
            this.btn_writeCtl.FlatAppearance.BorderSize = 0;
            this.btn_writeCtl.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_writeCtl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_writeCtl.Location = new System.Drawing.Point(438, 43);
            this.btn_writeCtl.Name = "btn_writeCtl";
            this.btn_writeCtl.Size = new System.Drawing.Size(123, 81);
            this.btn_writeCtl.TabIndex = 12;
            this.btn_writeCtl.Text = "写入控制器";
            this.btn_writeCtl.UseVisualStyleBackColor = true;
            this.btn_writeCtl.Click += new System.EventHandler(this.btn_writeCtl_Click);
            // 
            // btn_clearForm
            // 
            this.btn_clearForm.FlatAppearance.BorderSize = 0;
            this.btn_clearForm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_clearForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_clearForm.Location = new System.Drawing.Point(240, 191);
            this.btn_clearForm.Name = "btn_clearForm";
            this.btn_clearForm.Size = new System.Drawing.Size(171, 31);
            this.btn_clearForm.TabIndex = 11;
            this.btn_clearForm.Text = "清空停留点信息";
            this.btn_clearForm.UseVisualStyleBackColor = true;
            this.btn_clearForm.Click += new System.EventHandler(this.btn_clearForm_Click);
            // 
            // btn_insertPnt
            // 
            this.btn_insertPnt.FlatAppearance.BorderSize = 0;
            this.btn_insertPnt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_insertPnt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_insertPnt.Location = new System.Drawing.Point(240, 145);
            this.btn_insertPnt.Name = "btn_insertPnt";
            this.btn_insertPnt.Size = new System.Drawing.Size(171, 31);
            this.btn_insertPnt.TabIndex = 10;
            this.btn_insertPnt.Text = "插入停留点(选中行上方)";
            this.btn_insertPnt.UseVisualStyleBackColor = true;
            this.btn_insertPnt.Click += new System.EventHandler(this.btn_insertPnt_Click);
            // 
            // btn_delPnt
            // 
            this.btn_delPnt.FlatAppearance.BorderSize = 0;
            this.btn_delPnt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_delPnt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_delPnt.Location = new System.Drawing.Point(240, 93);
            this.btn_delPnt.Name = "btn_delPnt";
            this.btn_delPnt.Size = new System.Drawing.Size(171, 31);
            this.btn_delPnt.TabIndex = 9;
            this.btn_delPnt.Text = "删除停留点";
            this.btn_delPnt.UseVisualStyleBackColor = true;
            this.btn_delPnt.Click += new System.EventHandler(this.btn_delPnt_Click);
            // 
            // btn_addPnt
            // 
            this.btn_addPnt.FlatAppearance.BorderSize = 0;
            this.btn_addPnt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_addPnt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_addPnt.Location = new System.Drawing.Point(240, 43);
            this.btn_addPnt.Name = "btn_addPnt";
            this.btn_addPnt.Size = new System.Drawing.Size(171, 31);
            this.btn_addPnt.TabIndex = 8;
            this.btn_addPnt.Text = "添加停留点";
            this.btn_addPnt.UseVisualStyleBackColor = true;
            this.btn_addPnt.Click += new System.EventHandler(this.btn_addPnt_Click);
            // 
            // text_remarks
            // 
            this.text_remarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_remarks.Location = new System.Drawing.Point(11, 203);
            this.text_remarks.Name = "text_remarks";
            this.text_remarks.Size = new System.Drawing.Size(187, 19);
            this.text_remarks.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "备注";
            // 
            // text_filePath
            // 
            this.text_filePath.BackColor = System.Drawing.SystemColors.Info;
            this.text_filePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_filePath.Location = new System.Drawing.Point(11, 151);
            this.text_filePath.Name = "text_filePath";
            this.text_filePath.Size = new System.Drawing.Size(187, 19);
            this.text_filePath.TabIndex = 5;
            this.text_filePath.Text = "点击浏览选择文件路径";
            this.text_filePath.Click += new System.EventHandler(this.text_filePath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "文件路径";
            // 
            // text_time
            // 
            this.text_time.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_time.Location = new System.Drawing.Point(11, 99);
            this.text_time.Name = "text_time";
            this.text_time.Size = new System.Drawing.Size(187, 19);
            this.text_time.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "停留时间";
            // 
            // text_dis
            // 
            this.text_dis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_dis.Location = new System.Drawing.Point(11, 49);
            this.text_dis.Name = "text_dis";
            this.text_dis.Size = new System.Drawing.Size(187, 19);
            this.text_dis.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "运行距离";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label_posi);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btn_recordposi);
            this.groupBox2.Controls.Add(this.btn_back);
            this.groupBox2.Controls.Add(this.btn_forward);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(681, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(119, 239);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "手动控制";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 19);
            this.label7.TabIndex = 18;
            this.label7.Text = "MM";
            // 
            // label_posi
            // 
            this.label_posi.AutoSize = true;
            this.label_posi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label_posi.Location = new System.Drawing.Point(30, 157);
            this.label_posi.Name = "label_posi";
            this.label_posi.Size = new System.Drawing.Size(31, 19);
            this.label_posi.TabIndex = 17;
            this.label_posi.Text = "0.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "距离：";
            // 
            // btn_recordposi
            // 
            this.btn_recordposi.FlatAppearance.BorderSize = 0;
            this.btn_recordposi.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_recordposi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_recordposi.Location = new System.Drawing.Point(15, 191);
            this.btn_recordposi.Name = "btn_recordposi";
            this.btn_recordposi.Size = new System.Drawing.Size(89, 30);
            this.btn_recordposi.TabIndex = 15;
            this.btn_recordposi.Text = "记录位置";
            this.btn_recordposi.UseVisualStyleBackColor = true;
            this.btn_recordposi.Click += new System.EventHandler(this.btn_recordposi_Click);
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_back.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_back.Location = new System.Drawing.Point(15, 88);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(89, 30);
            this.btn_back.TabIndex = 14;
            this.btn_back.Text = "后退";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_forward
            // 
            this.btn_forward.FlatAppearance.BorderSize = 0;
            this.btn_forward.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_forward.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_forward.Location = new System.Drawing.Point(15, 38);
            this.btn_forward.Name = "btn_forward";
            this.btn_forward.Size = new System.Drawing.Size(89, 30);
            this.btn_forward.TabIndex = 13;
            this.btn_forward.Text = "前进";
            this.btn_forward.UseVisualStyleBackColor = true;
            this.btn_forward.Click += new System.EventHandler(this.btn_forward_Click);
            // 
            // consoleBox
            // 
            this.consoleBox.Location = new System.Drawing.Point(68, 465);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.consoleBox.Size = new System.Drawing.Size(732, 55);
            this.consoleBox.TabIndex = 5;
            this.consoleBox.Text = "";
            // 
            // timer_refreshUI
            // 
            this.timer_refreshUI.Tick += new System.EventHandler(this.timer_refreshUI_Tick);
            // 
            // StayPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(871, 558);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.stayPointGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StayPointForm";
            this.Text = "StayPointForm";
            this.Load += new System.EventHandler(this.StayPointForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stayPointGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView stayPointGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_addPnt;
        private System.Windows.Forms.TextBox text_remarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_filePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_dis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_clearForm;
        private System.Windows.Forms.Button btn_insertPnt;
        private System.Windows.Forms.Button btn_delPnt;
        private System.Windows.Forms.Button btn_readCtl;
        private System.Windows.Forms.Button btn_writeCtl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_posi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_recordposi;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_forward;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox consoleBox;
        private System.Windows.Forms.Timer timer_refreshUI;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn distance;
        private System.Windows.Forms.DataGridViewTextBoxColumn stayTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn filePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn offsides;
    }
}