using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobScreenV4
{
    public partial class DebugForm : Form
    {
        public static Int32 g_recvCmdAck = 0;//接收指令
        public static byte[] g_SerialSendBuf = new byte[256];//串口发送缓冲区
        public static int g_mov_flg = 0;//正在运行标志位
        public Label validDis;
        private Config config;//保存从父窗口传过来的配置
        private SerialPort port;//保存从父窗口传过来的串口
        private MainFrom form;
        public DebugForm()
        {
            InitializeComponent();
        }

        public DebugForm(Config config)
        {
            InitializeComponent();
            this.config = config;
        }

        public DebugForm(Config config,SerialPort port)
        {
            InitializeComponent();
            this.config = config;
            this.port = port;
        }

        public DebugForm(Config config,MainFrom form)
        {
            InitializeComponent();
            this.config = config;
            this.form = form;
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {
            //停留点下拉框更新
            int y = 0;
            for(int i = 0; i < config.stayPoint_Info.Length; i++)
            {
                if (config.stayPoint_Info[i].used_flg == "Y")
                {
                    box_stayPoints.Items.Add(y + 1);
                    y++;
                }
            }
            box_stayPoints.SelectedIndex = 0;
            validDis = lab_validDis;
            motorSpdNum.Value = config.motor.speed;
            motorIncrSpdNum.Value = config.motor.AccSpeed;
            motorDecSpdNum.Value = config.motor.decSpeed;
            if (config.startPosition == 1)
                rightAsStart.Checked = true;
            else
                leftAsStart.Checked = true;
        }

        private void setMotorArgBtn_Click(object sender, EventArgs e)
        {
            //设置电机运行速度
            UInt16 crc;
            form.g_SerialSendBuf[0] = 0XAA;
            form.g_SerialSendBuf[1] = 0X01;
            form.g_SerialSendBuf[2] = 0X02;
            form.g_SerialSendBuf[3] = 0X03;
            form.g_SerialSendBuf[4] = 0X06;      //功能码
            form.g_SerialSendBuf[5] = 0X03;      //数据长度
            form.g_SerialSendBuf[6] = 0X16;
            form.g_SerialSendBuf[7] = 0X16;
            form.g_SerialSendBuf[8] = (byte)motorSpdNum.Value;
            crc = getCRC(9);
            form.g_SerialSendBuf[9] = (byte)(crc);      //crc校验
            form.g_SerialSendBuf[10] = (byte)(crc >> 8);

            PackageCmd(11);

            bool tmp = WaitOkFromControler(6);
            if (tmp)
            {
                ShowTipsInfo("电机速度写入控制器成功！", Color.Green);
                config.motor.speed = form.g_SerialSendBuf[8];
            }
            else
            {
                ShowTipsInfo("电机速度写入控制器--失败！请重试", Color.Red);

            }

            form.g_SerialSendBuf[0] = 0XAA;
            form.g_SerialSendBuf[1] = 0X01;
            form.g_SerialSendBuf[2] = 0X02;
            form.g_SerialSendBuf[3] = 0X03;
            form.g_SerialSendBuf[4] = 0X06;      //功能码
            form.g_SerialSendBuf[5] = 0X06;      //数据长度
            form.g_SerialSendBuf[6] = 0X1B;
            form.g_SerialSendBuf[7] = 0X1B;

            UInt16 tmp1 = (UInt16)motorIncrSpdNum.Value;

            form.g_SerialSendBuf[8] = (byte)(tmp1 >> 8);
            form.g_SerialSendBuf[9] = (byte)(tmp1);

            tmp1 = (UInt16)motorDecSpdNum.Value;

            form.g_SerialSendBuf[10] = (byte)(tmp1 >> 8);
            form.g_SerialSendBuf[11] = (byte)(tmp1);

            crc = getCRC(12);
            form.g_SerialSendBuf[12] = (byte)(crc);      //crc校验
            form.g_SerialSendBuf[13] = (byte)(crc >> 8);

            PackageCmd(14);

            tmp = WaitOkFromControler(6);
            if (tmp)
            {
                ShowTipsInfo("电机加减速写入控制器成功！", Color.Green,14);
                config.motor.AccSpeed = (UInt16)motorIncrSpdNum.Value;
                config.motor.decSpeed = (UInt16)motorDecSpdNum.Value;

            }
            else
            {
                ShowTipsInfo("电机加减速写入控制器--失败！请重试", Color.Red,14);

            }

            form.saveData();
            
        }

        /// <summary>
        /// 不输出指令的文本输出
        /// </summary>
        /// <param name="v"></param>
        /// <param name="c"></param>
        private void ShowTipsInfo(string v, Color c)
        {
            consoleBox.SelectionStart = consoleBox.TextLength;
            consoleBox.SelectionLength = v.Length;
            consoleBox.SelectionColor = c;
            consoleBox.AppendText("[" + DateTime.Now + "]: " + v + "\r\n");
            
        }
        /// <summary>
        /// 输出指令的文本输出
        /// </summary>
        /// <param name="v"></param>
        /// <param name="c"></param>
        /// <param name="cnt"></param>
        private void ShowTipsInfo(string v, Color c, int cnt)
        {
            consoleBox.SelectionStart = consoleBox.TextLength;
            consoleBox.SelectionLength = v.Length;
            consoleBox.SelectionColor = c;
            consoleBox.AppendText("[" + DateTime.Now
                    + "]: " + BitConverter.ToString(form.g_SerialSendBuf.Take(cnt).ToArray())
                    + v + "\r\n");
        }

        private bool WaitOkFromControler(UInt16 ack)
        {
            form.g_recvCmdAck = 0;
            Thread.Sleep(300);
            if (form.g_recvCmdAck == ack)
                return true;
            return false;
        }
        

        #region 手动控制
        /// <summary>
        /// 手动后退按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void manualBackBtn_Click(object sender, EventArgs e)
        {
            if (g_mov_flg == 0)
            {
                UInt16 crc;
                g_mov_flg = 1;
                form.g_SerialSendBuf[0] = 0XAA;
                form.g_SerialSendBuf[1] = 0X01;
                form.g_SerialSendBuf[2] = 0X02;
                form.g_SerialSendBuf[3] = 0X03;
                form.g_SerialSendBuf[4] = 0X03;      //功能码
                form.g_SerialSendBuf[5] = 0X01;      //数据长度
                form.g_SerialSendBuf[6] = 0X02;
                crc = getCRC(7);
                form.g_SerialSendBuf[7] = (byte)(crc);      //crc校验
                form.g_SerialSendBuf[8] = (byte)(crc >> 8);

                PackageCmd(9);
                manualBackBtn.Text = "停止";
                manualForwardBtn.Enabled = false;
                //新版控制器在运行过程中已经返回位置了
                //不需要开定时器主动查询位置
                ////启动定时器 更新控件
                timer_refreshUI.Enabled = true;
                timer_refreshUI.Interval = 200;
                timer_refreshUI.Start();
            }
            else
            {
                stop_run();
                g_mov_flg = 0;
                manualBackBtn.Text = "后退";
                manualForwardBtn.Enabled = true;
                timer_refreshUI.Enabled = false;
                timer_refreshUI.Stop();
            }
        }

        /// <summary>
        /// 手动前进按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void manualForwardBtn_Click(object sender, EventArgs e)
        {
            //前进按钮
            if (g_mov_flg == 0)
            {
                UInt16 crc;
                form.g_SerialSendBuf[0] = 0XAA;
                form.g_SerialSendBuf[1] = 0X01;
                form.g_SerialSendBuf[2] = 0X02;
                form.g_SerialSendBuf[3] = 0X03;
                form.g_SerialSendBuf[4] = 0X03;      //功能码
                form.g_SerialSendBuf[5] = 0X01;      //数据长度
                form.g_SerialSendBuf[6] = 0X01;
                crc = getCRC(7);
                form.g_SerialSendBuf[7] = (byte)(crc);      //crc校验
                form.g_SerialSendBuf[8] = (byte)(crc >> 8);

                PackageCmd(9);

                manualForwardBtn.Text = "停止";
                manualBackBtn.Enabled = false;
                g_mov_flg = 1;
                //启动定时器  实时更新控件
                timer_refreshUI.Enabled = true;
                timer_refreshUI.Interval = 200;
                timer_refreshUI.Start();
            }
            else
            {
                stop_run();
                g_mov_flg = 0;
                manualForwardBtn.Text = "前进";
                manualBackBtn.Enabled = true;
                timer_refreshUI.Enabled = false;
                timer_refreshUI.Stop();
            }
        }
        #endregion

        #region 发送指令
        private void PackageCmd(Int32 byte_count)
        {
            if (config.net_or_com== "COM")
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
                ShowTipsInfo("通信配置出错,不是网络串口的其中一个", Color.Red, byte_count);
            }
        }

        /// <summary>
        /// 计算校验位
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        private ushort getCRC(int len)
        {
            int CRC = 0x0000ffff;
            int POLYNOMIAL = 0x0000a001;

            int i, j;
            for (i = 0; i < len; i++)
            {
                CRC ^= ((int)form.g_SerialSendBuf[i] & 0x000000ff);
                for (j = 0; j < 8; j++)
                {
                    if ((CRC & 0x00000001) != 0)
                    {
                        CRC >>= 1;
                        CRC ^= POLYNOMIAL;
                    }
                    else
                    {
                        CRC >>= 1;
                    }
                }
            }
            return Convert.ToUInt16(CRC);
        }
        #endregion
        /// <summary>
        /// 停止运行
        /// </summary>
        private void stop_run()
        {
            UInt16 crc;
            form.g_SerialSendBuf[0] = 0XAA;
            form.g_SerialSendBuf[1] = 0X01;
            form.g_SerialSendBuf[2] = 0X02;
            form.g_SerialSendBuf[3] = 0X03;
            form.g_SerialSendBuf[4] = 0X03;      //功能码
            form.g_SerialSendBuf[5] = 0X01;      //数据长度
            form.g_SerialSendBuf[6] = 0X00;
            crc = getCRC(7);
            form.g_SerialSendBuf[7] = (byte)(crc);      //crc校验
            form.g_SerialSendBuf[8] = (byte)(crc >> 8);

            PackageCmd(9);

            //定时查询距离定时器
            timer_refreshUI.Enabled = false;
            timer_refreshUI.Stop();
        }


        /// <summary>
        /// 查询当前位置
        /// </summary>
        private void askScreenPosition()
        {
            UInt16 crc;
            form.g_SerialSendBuf[0] = 0XAA;
            form.g_SerialSendBuf[1] = 0X01;
            form.g_SerialSendBuf[2] = 0X02;
            form.g_SerialSendBuf[3] = 0X03;
            form.g_SerialSendBuf[4] = 0X02;      //功能码
            form.g_SerialSendBuf[5] = 0X00;      //数据长度
            crc = getCRC(6);
            form.g_SerialSendBuf[6] = (byte)(crc);      //crc校验
            form.g_SerialSendBuf[7] = (byte)(crc >> 8);
            PackageCmd(8);
        }

        //测量有效距离
        private void btn_CalValidDis_Click(object sender, EventArgs e)
        {
            lab_validDis.Text = " ";
            autoMesureDistance();
            if (WaitOkFromControler(0x13))
            {
                DialogResult result = MessageBox.Show("正在测距，控制器停止前不要关闭此窗口");
                //if (result == DialogResult.OK)
                //{
                //    lab_validDis.Text = form.total_length.ToString();
                //}
            }

        }
        public void autoMesureDistance()
        {
            UInt16 crc;
            form.g_SerialSendBuf[0] = 0XAA;
            form.g_SerialSendBuf[1] = 0X01;
            form.g_SerialSendBuf[2] = 0X02;
            form.g_SerialSendBuf[3] = 0X03;
            form.g_SerialSendBuf[4] = 0X13;      //功能码
            form.g_SerialSendBuf[5] = 0X00;      //数据长度
            crc = getCRC(6);
            form.g_SerialSendBuf[6] = (byte)(crc);      //crc校验
            form.g_SerialSendBuf[7] = (byte)(crc >> 8);

            PackageCmd(8);

        }

        //精准后退
        private void btn_excBack_Click(object sender, EventArgs e)
        {
            //精确后退
            UInt16 crc;
            form.g_SerialSendBuf[0] = 0XAA;
            form.g_SerialSendBuf[1] = 0X01;
            form.g_SerialSendBuf[2] = 0X02;
            form.g_SerialSendBuf[3] = 0X03;
            form.g_SerialSendBuf[4] = 0X03;      //功能码
            form.g_SerialSendBuf[5] = 0X03;      //数据长度
            form.g_SerialSendBuf[6] = 0X02;
            Int16 tmp = (Int16)num_excMove.Value;

            form.g_SerialSendBuf[7] = (byte)(tmp >> 8);      //距离数值
            form.g_SerialSendBuf[8] = (byte)(tmp);

            crc = getCRC(9);
            form.g_SerialSendBuf[9] = (byte)(crc);      //crc校验
            form.g_SerialSendBuf[10] = (byte)(crc >> 8);

            PackageCmd(11);
        }
        //精准前进
        private void btn_excForward_Click(object sender, EventArgs e)
        {
            //精确前进
            UInt16 crc;
            form.g_SerialSendBuf[0] = 0XAA;
            form.g_SerialSendBuf[1] = 0X01;
            form.g_SerialSendBuf[2] = 0X02;
            form.g_SerialSendBuf[3] = 0X03;
            form.g_SerialSendBuf[4] = 0X03;      //功能码
            form.g_SerialSendBuf[5] = 0X03;      //数据长度
            form.g_SerialSendBuf[6] = 0X01;
            Int16 tmp = (Int16)num_excMove.Value;

            form.g_SerialSendBuf[7] = (byte)(tmp >> 8);      //距离数值
            form.g_SerialSendBuf[8] = (byte)(tmp);

            crc = getCRC(9);
            form.g_SerialSendBuf[9] = (byte)(crc);      //crc校验
            form.g_SerialSendBuf[10] = (byte)(crc >> 8);

            PackageCmd(11);
        }
        //手动输入有效距离
        private void btn_validDisWrite_Click(object sender, EventArgs e)
        {
            //手动写入总距离
            UInt16 crc;
            form.g_SerialSendBuf[0] = 0XAA;
            form.g_SerialSendBuf[1] = 0X01;
            form.g_SerialSendBuf[2] = 0X02;
            form.g_SerialSendBuf[3] = 0X03;
            form.g_SerialSendBuf[4] = 0X09;      //功能码
            form.g_SerialSendBuf[5] = 0X02;      //数据长度

            UInt16 tmp1 = (UInt16)num_manualDis.Value;

            form.g_SerialSendBuf[6] = (byte)(tmp1 >> 8);
            form.g_SerialSendBuf[7] = (byte)(tmp1);

            crc = getCRC(8);
            form.g_SerialSendBuf[8] = (byte)(crc);      //crc校验
            form.g_SerialSendBuf[9] = (byte)(crc >> 8);

            PackageCmd(10);

            bool tmp = WaitOkFromControler(9);
            if (tmp)
            {
                ShowTipsInfo("有效距离写入控制器成功！", Color.Green);
                config.totalLength = (int)num_manualDis.Value;
                form.saveData();
            }
            else
            {
                ShowTipsInfo("有效距离写入控制器--失败！请重试", Color.Red);
            }
        }

        #region 前往指定停留点
        private void btn_runtoPoint_Click(object sender, EventArgs e)
        {
            //运行到此停留点
            byte tmp = (byte)box_stayPoints.SelectedIndex;
            tmp++;
            gotoStayPoint(tmp);
        }

        private void gotoStayPoint(byte point)
        {
            UInt16 crc;
            form.g_SerialSendBuf[0] = 0XAA;
            form.g_SerialSendBuf[1] = 0X01;
            form.g_SerialSendBuf[2] = 0X02;
            form.g_SerialSendBuf[3] = 0X03;
            form.g_SerialSendBuf[4] = 0X14;      //功能码
            form.g_SerialSendBuf[5] = 0X01;      //数据长度
            form.g_SerialSendBuf[6] = point;
            crc = getCRC(7);
            form.g_SerialSendBuf[7] = (byte)(crc);      //crc校验
            form.g_SerialSendBuf[8] = (byte)(crc >> 8);
            PackageCmd(9);
        }
        #endregion

        #region 左右起点
        private void leftAsStart_Click(object sender, EventArgs e)
        {
            DialogResult dr1 = MessageBox.Show("设置滑轨屏左起点，请慎重选择，确认后滑轨屏将重新启动，请重设停留点信息？", "提示信息！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr1 != DialogResult.Yes)
            {
                if (config.startPosition == 0)
                    leftAsStart.Checked = true;
                else if (config.startPosition == 1)
                    rightAsStart.Checked = true;
                return;
            }
            //设置左边为起点
            setLeftRightStart(0);
            bool tmp = WaitOkFromControler(6);
            if (tmp)
            {
                ShowTipsInfo("设置左起点成功！", Color.Green);
                config.startPosition = 0;
                form.saveData();
            }
            else
            {
                ShowTipsInfo("设置左起点--失败！控制器未响应", Color.Red);
            }
        }

        private void rightAsStart_Click(object sender, EventArgs e)
        {
            DialogResult dr1 = MessageBox.Show("设置滑轨屏右起点，请慎重选择，确认后滑轨屏将重新启动，请重设停留点信息？", "提示信息！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr1 != DialogResult.Yes)
            {
                if (config.startPosition == 0)
                    rightAsStart.Checked = true;
                else if (config.startPosition == 1)
                    leftAsStart.Checked = true;
                return;
            }
            setLeftRightStart(1);
            bool tmp = WaitOkFromControler(6);
            if (tmp)
            {
                ShowTipsInfo("设置右起点成功！", Color.Green);
                //设置右边为起点
                config.startPosition = 1;
                form.saveData();
            }
            else
            {
                ShowTipsInfo("设置右起点--失败！控制器未响应", Color.Red);
            }
        }

        private void setLeftRightStart(byte dir)
        {
            UInt16 crc;
            form.g_SerialSendBuf[0] = 0XAA;
            form.g_SerialSendBuf[1] = 0X01;
            form.g_SerialSendBuf[2] = 0X02;
            form.g_SerialSendBuf[3] = 0X03;
            form.g_SerialSendBuf[4] = 0X06;      //功能码
            form.g_SerialSendBuf[5] = 0X03;      //数据长度
            form.g_SerialSendBuf[6] = 0X18;
            form.g_SerialSendBuf[7] = 0X18;
            form.g_SerialSendBuf[8] = dir;
            crc = getCRC(9);
            form.g_SerialSendBuf[9] = (byte)(crc);      //crc校验
            form.g_SerialSendBuf[10] = (byte)(crc >> 8);

            PackageCmd(11);
        }


        #endregion

        private void timer_refreshUI_Tick(object sender, EventArgs e)
        {
            DisLabel.Text = config.motor.currentPosition.ToString();
        }
    }
}
