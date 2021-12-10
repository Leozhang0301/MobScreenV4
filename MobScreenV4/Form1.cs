using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobScreenV4
{
    public partial class MainFrom : Form
    {
        public Int32 g_recvCmdAck = 0;//接收指令
        public  byte[] g_SerialRxBuf;//串口接收缓存区
        public  byte[] g_SerialSendBuf = new byte[256];//串口发送缓冲区
        public Config config;//保存用户配置信息类
        public static byte g_versionA = 0;          //主版本号
        public static byte g_versionB = 0;          //次版本号
        public static StringBuilder needUpdateForm = new StringBuilder();
        public UInt16 total_length = 0;         //总距离
        #region 拖拽窗口导入外部函数
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );
        #endregion
        public MainFrom()
        {
            InitializeComponent();
            openChildForm(new MainCtrlForm());
            config = new Config();
            //第一次初始化配置文件
            if (File.Exists("UserData.bkpokn") == false)
            {
                using(FileStream fs=new FileStream("UserData.bkpokn", FileMode.Create))
                {
                    BinaryFormatter b = new BinaryFormatter();
                    b.Serialize(fs, config);
                }
            }
            extract();
            #region 导航栏
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            PnlNav.Height = BtnMainCtrl.Height;
            PnlNav.Top = BtnMainCtrl.Top;
            PnlNav.Left = BtnMainCtrl.Left;
            BtnMainCtrl.BackColor = Color.FromArgb(46, 51, 73);
            #endregion
        }

        private void MainFrom_Load(object sender, EventArgs e)
        {
            versionText.Text = config.version;
            CTRLSerialPort.PortName = "COM4";
            CTRLSerialPort.BaudRate = 9600;
            CTRLSerialPort.DataBits = 8;              //8位数据位
            CTRLSerialPort.StopBits = StopBits.One;   //1停止位
            CTRLSerialPort.Parity = Parity.None;      //无校验
            if (!CTRLSerialPort.IsOpen)
            {
                CTRLSerialPort.Open();
            }
            connectControl();
            Thread.Sleep(1000);
            CtrlVerText.Text = "V"+g_versionA.ToString() + "." + g_versionB.ToString();
        }
        #region 序列化反/序列化
        public void saveData()
        {
            using (FileStream fs = new FileStream("UserData.bkpokn", FileMode.Create))
            {
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(fs, config);
            }
        }

        public void extract()
        {
            if (File.Exists("UserData.bkpokn") == false)
            {
                using (FileStream fs = new FileStream("UserData.bkpokn", FileMode.Create))
                {
                    BinaryFormatter b = new BinaryFormatter();
                    b.Serialize(fs, config);
                }
            }
            using (FileStream fs = new FileStream("UserData.bkpokn", FileMode.Open))
            {
                try
                {
                    BinaryFormatter b = new BinaryFormatter();
                    object o = b.Deserialize(fs);
                    config = o as Config;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }
        #endregion

        #region 侧边导航栏点击事件
        private void BtnMainCtrl_Click(object sender, EventArgs e)
        {
            PnlNav.Height = BtnMainCtrl.Height;
            PnlNav.Top = BtnMainCtrl.Top;
            PnlNav.Left = BtnMainCtrl.Left;
            BtnMainCtrl.BackColor = Color.FromArgb(46, 51, 73);
            openChildForm(new MainCtrlForm());
        }

        private void BtnStayPoint_Click(object sender, EventArgs e)
        {
            PnlNav.Height = BtnStayPoint.Height;
            PnlNav.Top = BtnStayPoint.Top;
            BtnStayPoint.BackColor = Color.FromArgb(46, 51, 73);
            openChildForm(new StayPointForm());
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            PnlNav.Height = BtnRegister.Height;
            PnlNav.Top = BtnRegister.Top;
            BtnRegister.BackColor = Color.FromArgb(46, 51, 73);
            openChildForm(new RegistForm());
        }

        private void BtnDebug_Click(object sender, EventArgs e)
        {
            PnlNav.Height = BtnDebug.Height;
            PnlNav.Top = BtnDebug.Top;
            BtnDebug.BackColor = Color.FromArgb(46, 51, 73);
            //openChildForm(new DebugForm(config,CTRLSerialPort));
            openChildForm(new DebugForm(config, this));
        }

        private Form activeForm = null;
        /// <summary>
        /// 显示一个子窗口
        /// </summary>
        /// <param name="childForm"></param>
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            childForm.FormBorderStyle = FormBorderStyle.None;
            pnlChild.Controls.Add(childForm);
            pnlChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion

        #region  无边框窗体移动
        private void minBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Point formPoint;
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            formPoint = new Point(e.X, e.Y);
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - formPoint.X, this.Location.Y + e.Y - formPoint.Y);
            }
        }
        #endregion

        #region 离开侧边导航栏颜色回到正常
        private void BtnMainCtrl_Leave(object sender, EventArgs e)
        {
            BtnMainCtrl.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnStayPoint_Leave(object sender, EventArgs e)
        {
            BtnStayPoint.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnRegister_Leave(object sender, EventArgs e)
        {
            BtnRegister.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnDebug_Leave(object sender, EventArgs e)
        {
            BtnDebug.BackColor = Color.FromArgb(24, 30, 54);
        }

        #endregion

        private void refresh_form_has_return()
        {
            byte cmd = 0;
            Int32 tmp = needUpdateForm.Length;

            Int32 i = 0;
            while (tmp > 0)
            {
                cmd = (byte)needUpdateForm[i];
                switch (cmd)
                {
                    case 0x13:
                        DebugForm.validDis.Text = total_length.ToString();
                        Console.WriteLine(total_length);
                        break;
                    default:
                        break;
                }
            }
        }

        #region 串口接收数据处理
        private void CTRLSerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            #region 测试
            MethodInvoker ManageReturnCmd = new MethodInvoker(this.refresh_form_has_return);  //有返回值的指令，更新窗体
            #region 循环读取缓冲区内部
            int i = 0;
            Queue<byte[]> q_instr = new Queue<byte[]>();
            int LenofBuffer = 0;
            g_SerialRxBuf = new byte[256];
            try
            {
                while (CTRLSerialPort.BytesToRead > 0)
                {
                    Thread.Sleep(10);
                    g_SerialRxBuf[i] = (byte)CTRLSerialPort.ReadByte();
                    i++;
                    LenofBuffer++;
                }
                //把多余长度的数组删除
                g_SerialRxBuf = g_SerialRxBuf.Take(LenofBuffer).ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            #endregion
            //先保证缓冲区是cc开头
            if (g_SerialRxBuf[0] == 0xcc)
            {
                //第6位是数据长度
                int dataLen = g_SerialRxBuf[5];
                int instrLen = dataLen + 8;
                //如果是单独一条指令
                if (instrLen == LenofBuffer)
                    q_instr.Enqueue(g_SerialRxBuf);
                //如果是多条指令
                else
                {
                    //当buffer数组不为空时
                    while (g_SerialRxBuf.Length != 0)
                    {
                        int singleDataLen = g_SerialRxBuf[5];
                        int singleInstrLen = singleDataLen + 8;
                        //按照指令长度截取到instrdata里
                        byte[] instrByte = new byte[singleInstrLen];
                        //buffer.CopyTo(instrByte,instrLen);
                        instrByte = (byte[])g_SerialRxBuf.Take(singleInstrLen).ToArray();
                        //把指令从buffer里面去掉
                        g_SerialRxBuf = g_SerialRxBuf.Skip(singleInstrLen).ToArray();
                        q_instr.Enqueue(instrByte);
                    }
                }
                //遍历队列 每次都是完整的指令
                foreach (byte[] instr in q_instr)
                {
                    Console.WriteLine(BitConverter.ToString(instr));
                    UInt16 crc = 0;
                    crc = getCRC_Rx(instr.Length, instr);
                    UInt16 crc_rx = instr[instr.Length - 1];
                    crc_rx <<= 8;
                    crc_rx |= instr[instr.Length - 2];
                    //通过检验
                    if (crc == crc_rx)
                    {
                        if (instr[4] == 0x06)
                        {
                            findOkChar(6);
                        }
                        else if (instr[4] == 0x13)
                        {
                            g_recvCmdAck = 0;
                            findOkChar(0x13);
                            if (g_recvCmdAck != 0x13)
                            {
                                needUpdateForm.Append(0x13);
                                //更新调试页面滑轨屏的位置
                                total_length = g_SerialRxBuf[7];
                                total_length <<= 8;
                                total_length |= g_SerialRxBuf[6];
                                this.BeginInvoke(ManageReturnCmd);
                            }
                        }
                        else if (instr[4] == 0x15)
                        {
                            g_versionA = instr[6];
                            g_versionB = instr[7];
                            config.motor.versionA = g_versionA.ToString();
                            config.motor.versionB = g_versionB.ToString();
                            saveData();
                        }
                    }
                    else
                        MessageBox.Show("校验位不对");
                }
            }
            #endregion

        }
        //计算校验位
        public static UInt16 getCRC_Rx(int len, byte[] g_SerialRxBuf)
        {
            int CRC = 0x0000ffff;
            int POLYNOMIAL = 0x0000a001;

            int i, j;
            for (i = 0; i < len-2; i++)
            {
                CRC ^= ((int)g_SerialRxBuf[i] & 0x000000ff);
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
        private ushort getCRC(int len)
        {
            int CRC = 0x0000ffff;
            int POLYNOMIAL = 0x0000a001;

            int i, j;
            for (i = 0; i < len; i++)
            {
                CRC ^= ((int)g_SerialSendBuf[i] & 0x000000ff);
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
        //只适合没有返回值的指令，判定指令是否返回ok
        private void findOkChar(UInt16 cmd)
        {
            if ((g_SerialRxBuf[6] == 'O') && (g_SerialRxBuf[7] == 'K'))
            {
                g_recvCmdAck = cmd;
            }
            else
            {
               g_recvCmdAck = g_SerialRxBuf[6];
               g_recvCmdAck += 100;        //错误代码都大于100
            }
        }
        #endregion
        //询问控制器版本号
        private void connectControl()
        {
            UInt16 crc;
            g_SerialSendBuf[0] = 0XAA;
            g_SerialSendBuf[1] = 0X01;
            g_SerialSendBuf[2] = 0X02;
            g_SerialSendBuf[3] = 0X03;
            g_SerialSendBuf[4] = 0X15;      //功能码
            g_SerialSendBuf[5] = 0X00;      //数据长度
            crc = getCRC(6);
            g_SerialSendBuf[6] = (byte)(crc);      //crc校验
            g_SerialSendBuf[7] = (byte)(crc >> 8);

            CTRLSerialPort.Write(g_SerialSendBuf, 0, 8);
        }
    }
}
