﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobScreenV4
{
    public partial class frmBkPicture : Form
    {
        public frmBkPicture()
        {
            InitializeComponent();
        }

        private void frmBkPicture_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Minimized;
        }
    }
}