using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
        #region 全局变量
        public Int32 g_recvCmdAck = 0;//接收指令
        public  byte[] g_SerialRxBuf;//串口接收缓存区
        public  byte[] g_SerialSendBuf = new byte[256];//串口发送缓冲区
        public Config config;//保存用户配置信息类
        public static byte g_versionA = 0;          //主版本号
        public static byte g_versionB = 0;          //次版本号
        public static StringBuilder needUpdateForm = new StringBuilder();
        public UInt16 total_length = 0;         //总距离
        public static string[] szPorts;         //机器上全部串口列表
        public DebugForm debugForm;
        public StayPointForm stayPointForm;
        public bool manual_ask = false;  //手动查询控制器位置标志位
        private static byte moveDirection=0;  //0为向左移动   1为向右移动  3为停止状态
        #endregion
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
            openChildForm(new MainCtrlForm(config,this));
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
            //读取配置文件信息
            extract();
            #region 导航栏
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            PnlNav.Height = BtnMainCtrl.Height;
            PnlNav.Top = BtnMainCtrl.Top;
            PnlNav.Left = BtnMainCtrl.Left;
            BtnMainCtrl.BackColor = Color.FromArgb(46, 51, 73);
            #endregion
            //获取本机所有端口号
            szPorts = SerialPort.GetPortNames();
            //应该查询一下控制器内部存储的信息 跟配置文件保持同步
        }

        private void MainFrom_Load(object sender, EventArgs e)
        {
            versionText.Text = config.version;
            if (config.net_or_com == "COM")
            {
                if (openPort(config.portName))
                {
                    connectControl();
                    Thread.Sleep(1000);
                    CtrlVerText.Text = "V" + g_versionA.ToString() + "." + g_versionB.ToString();
                }
            }
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
            openChildForm(new MainCtrlForm(config,this));
        }

        private void BtnStayPoint_Click(object sender, EventArgs e)
        {
            PnlNav.Height = BtnStayPoint.Height;
            PnlNav.Top = BtnStayPoint.Top;
            BtnStayPoint.BackColor = Color.FromArgb(46, 51, 73);
            stayPointForm = new StayPointForm(config, this);
            openChildForm(stayPointForm);
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
            debugForm = new DebugForm(config, this);
            openChildForm(debugForm);
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

        //更新其他控件
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
                    case 0x11:
                        stayPointForm.ShowTipsInfo("停留点信息读取成功！", Color.Green);
                        stayPointForm.refreshDataGrid();
                        saveData();
                        break;
                    case 0x13:
                        debugForm.validDis.Text = total_length.ToString();
                        Console.WriteLine(total_length);
                        break;
                    default:
                        break;
                }
                i++;
                tmp--;
            }
            needUpdateForm.Clear();
        }

        #region 串口接收数据处理
        private void CTRLSerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            #region 测试
            MethodInvoker ManageReturnCmd = new MethodInvoker(this.refresh_form_has_return);  //有返回值的指令，更新窗体
            MethodInvoker AckAfterInPosition = new MethodInvoker(this.actAfterInPosition);
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
            try
            {
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
                            //写入控制器参数
                            if (instr[4] == 0x06)
                            {
                                findOkChar(6);
                            }
                            //写入有效距离
                            else if (instr[4] == 0x09)
                            {
                                findOkChar(9);
                            }
                            //写入停留点信息
                            else if (instr[4] == 0x10)
                            {
                                findOkChar(10);
                            }
                            //读取停留点信息
                            else if (instr[4] == 0x11)
                            {
                                needUpdateForm.Append((char)0x11);
                                ParsePointInfo();
                                this.BeginInvoke(ManageReturnCmd);
                            }
                            //返回停留点位置信息
                            //到达停留点后主动上传/查询读取
                            else if (instr[4] == 0x12)
                            {
                                //向控制器发送OK
                                //不然控制器到位后会连续发送三条12指令
                                sendOkAck(0x12);
                                //如果是主动查询的话不执行到位动作
                                //可能会在两个停留点之间
                                byte head = instr[6];
                                byte tail = instr[7];
                                if (manual_ask)
                                {
                                    manual_ask = false;
                                    config.motor.stayPointact = head;
                                    return;
                                }
                                //位于停留点
                                if (head == tail)
                                {
                                    config.motor.inPosiFlag = true;
                                    config.motor.stayPointact = head;
                                    string play_url = config.stayPoint_Info[head].file_path;
                                    //如果视频路径为空
                                    if (play_url == "" || !File.Exists(play_url))
                                    {
                                        MessageBox.Show("视频路径为空或者路径不存在，请先添加正确路径！");
                                        return;
                                    }
                                    //如果head合法
                                    if (head <= config.stayPointCnt)
                                    {
                                        //这里应该执行控制器到位之后的操作  播图片或者视频
                                        this.BeginInvoke(AckAfterInPosition);
                                    }
                                    else
                                        MessageBox.Show("返回的停留点信息不合法");
                                }
                            }
                            //测量有效距离
                            else if (instr[4] == 0x13)
                            {
                                g_recvCmdAck = 0;
                                findOkChar(0x13);
                                if (g_recvCmdAck != 0x13)
                                {
                                    needUpdateForm.Append((char)0X13);
                                    total_length = g_SerialRxBuf[7];
                                    total_length <<= 8;
                                    total_length |= g_SerialRxBuf[6];
                                    this.BeginInvoke(ManageReturnCmd);
                                }
                            }
                            //查询版本号/连接控制器
                            else if (instr[4] == 0x15)
                            {
                                g_versionA = instr[6];
                                g_versionB = instr[7];
                                config.motor.versionA = g_versionA.ToString();
                                config.motor.versionB = g_versionB.ToString();
                                saveData();
                            }
                            //控制器正在运行返回当前位置
                            else if (instr[4] == 0x16)
                            {
                                config.motor.currentPosition = instr[6];
                                config.motor.currentPosition <<= 8;
                                config.motor.currentPosition |= instr[7];
                                //判断指令内部方向
                                if (instr[8] == 1)
                                {
                                    //如果配置文件里为左起点
                                    if (config.startPosition == 0)
                                        moveDirection = 0;
                                    else
                                        moveDirection = 1;
                                }
                                else
                                {
                                    if (config.startPosition == 0)
                                        moveDirection = 1;
                                    else
                                        moveDirection = 0;
                                }
                            }
                        }
                        else
                            MessageBox.Show("校验位不对");
                    }
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            #endregion

        }

        //向控制器发送ok指令防止控制器重复发送指令
        private void sendOkAck(byte cmd)
        {
            UInt16 crc;
            g_SerialSendBuf[0] = 0XAA;
            g_SerialSendBuf[1] = 0X01;
            g_SerialSendBuf[2] = 0X02;
            g_SerialSendBuf[3] = 0X03;
            g_SerialSendBuf[4] = 0X12;      //功能码
            g_SerialSendBuf[5] = 0X02;      //数据长度
            g_SerialSendBuf[6] = (byte)'O';
            g_SerialSendBuf[7] = (byte)'K';
            crc = getCRC(8);
            g_SerialSendBuf[8] = (byte)(crc);      //crc校验
            g_SerialSendBuf[9] = (byte)(crc >> 8);

            PackageCmd(10);

        }

        //到位之后根据不同模式进行不同操作
        private void actAfterInPosition()
        {
            //定时模式
            if (config.running_mode == "time_con")
            {
                //播放视频
                play(config.stayPoint_Info[config.motor.stayPointact].file_path);
                //读取当前停留点所需要的停留时间
                if (!timer_timeControl.Enabled)
                    timer_timeControl.Enabled = true;
                timer_timeControl.Interval = config.stayPoint_Info[config.motor.stayPointact].stay_time*1000;
                timer_timeControl.Stop();
                timer_timeControl.Start();
            }
        }

        //向播控软件发送UDP数据包
        private void play(string file_path)
        {
            sendUDPPackage(file_path);
        }

        private void sendUDPPackage(string content)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress endPoint = IPAddress.Parse("192.168.0.119");
            byte[] sendbuf = Encoding.ASCII.GetBytes(content);
            IPEndPoint ep = new IPEndPoint(endPoint, 2020);
            socket.SendTo(sendbuf, ep);
        }

        //解析停留点信息
        private void ParsePointInfo()
        {
            UInt16 data_len = g_SerialRxBuf[5];
            byte start = 0;
            if (data_len >= 256)
            {
                MessageBox.Show("接收数据长度超限！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            for (int j = 0; j < 128; j++)
            {
                config.stayPoint_Info[j].used_flg = "N";
            }

            UInt16 i = 0;
            while (data_len > 0)
            {
                config.stayPoint_Info[start].distance = g_SerialRxBuf[7 + i];
                config.stayPoint_Info[start].distance <<= 8;
                config.stayPoint_Info[start].distance |= g_SerialRxBuf[6 + i];
                config.stayPoint_Info[start].used_flg = "Y";
                data_len -= 4;
                i += 4;
                start++;
            }
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
        public ushort getCRC(int len)
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

        //打开串口
        private bool openPort(string portName)
        {
            CTRLSerialPort.PortName = portName;
            CTRLSerialPort.BaudRate = 9600;
            CTRLSerialPort.DataBits = 8;              //8位数据位
            CTRLSerialPort.StopBits = StopBits.One;   //1停止位
            CTRLSerialPort.Parity = Parity.None;      //无校验
            if (!CTRLSerialPort.IsOpen)
            {
                try
                {
                    CTRLSerialPort.Open();
                    return true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("串口打开失败!!!"+ex.ToString());
                    return false;
                }
            }
            return true;
        }

        //定时模式下的定时器
        //每隔停留点保存的停留时间之后运行一次
        private void timer_timeControl_Tick(object sender, EventArgs e)
        {
            //定时器停止等待到达下一个停留点之后触发
            timer_timeControl.Stop();
            //运行到下一个停留点
            goToNextPoint();
            //Console.WriteLine("123");
        }

        //根据巡航模式计算下一个停留点
        public void goToNextPoint()
        {
            if (config.motor.stayPointact == config.stayPointCnt)
                config.motor.stayPointact = 0;
            config.motor.stayPointact++;
            gotoStayPoint(config.motor.stayPointact);
            //视频关掉
            sendUDPPackage("stop");
        }

        //运行到指定停留点
        private void gotoStayPoint(byte point)
        {
            UInt16 crc;
            g_SerialSendBuf[0] = 0XAA;
            g_SerialSendBuf[1] = 0X01;
            g_SerialSendBuf[2] = 0X02;
            g_SerialSendBuf[3] = 0X03;
            g_SerialSendBuf[4] = 0X14;      //功能码
            g_SerialSendBuf[5] = 0X01;      //数据长度
            g_SerialSendBuf[6] = point;
            crc = getCRC(7);
            g_SerialSendBuf[7] = (byte)(crc);      //crc校验
            g_SerialSendBuf[8] = (byte)(crc >> 8);
            PackageCmd(9);
        }

        private void PackageCmd(Int32 byte_count)
        {
            if (config.net_or_com == "COM")
            {
                //Console.WriteLine(BitConverter.ToString(form.g_SerialSendBuf.Take(byte_count).ToArray()));
                CTRLSerialPort.Write(g_SerialSendBuf, 0, byte_count);
                //ShowTipsInfo("串口发送成功", Color.Green, byte_count);
            }
            else if (config.net_or_com == "NET")
            {

            }
            else
            {
                //ShowTipsInfo("通信配置出错,不是网络串口的其中一个", Color.Red, byte_count);
                MessageBox.Show("通信配置出错,不是网络串口的其中一个");
            }
        }
    }
}
