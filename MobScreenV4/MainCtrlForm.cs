using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobScreenV4
{
    public partial class MainCtrlForm : Form
    {
        private Config config;
        private MainFrom form;
        public MainCtrlForm()
        {
            InitializeComponent();
        }

        public MainCtrlForm(Config config,MainFrom form)
        {
            InitializeComponent();
            this.config = config;
            this.form = form;
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            startRun();
        }

        private void startRun()
        {
            //查询一下当前停留点的信息  防止配置文件内部的停留点跟控制器内的不同
            form.manual_ask = true;
            askStayPointNow();
            Thread.Sleep(200);
            form.manual_ask = false;
        }

        private void askStayPointNow()
        {
            UInt16 crc;
            form.g_SerialSendBuf[0] = 0XAA;
            form.g_SerialSendBuf[1] = 0X01;
            form.g_SerialSendBuf[2] = 0X02;
            form.g_SerialSendBuf[3] = 0X03;
            form.g_SerialSendBuf[4] = 0X12;      //功能码
            form.g_SerialSendBuf[5] = 0X00;      //数据长度
            crc = form.getCRC(6);
            form.g_SerialSendBuf[6] = (byte)(crc);      //crc校验
            form.g_SerialSendBuf[7] = (byte)(crc >> 8);
            PackageCmd(8);
        }

        private void PackageCmd(int byte_count)
        {
            if (form.config.net_or_com == "COM")
            {
                //Console.WriteLine(BitConverter.ToString(form.g_SerialSendBuf.Take(byte_count).ToArray()));
                form.CTRLSerialPort.Write(form.g_SerialSendBuf, 0, byte_count);
                //ShowTipsInfo("串口发送成功", Color.Green, byte_count);
            }
            else if (config.net_or_com == "NET")
            {

            }
            else
            {
                MessageBox.Show("通信配置出错,不是网络串口的其中一个");
            }
        }
    }
}
