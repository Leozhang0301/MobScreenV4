using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaControl
{
    public partial class Form1 : Form
    {
        #region 变量
        private static Socket udpServer;
        private UdpClient listener;
        private IPEndPoint groupEP;
        private string sourceURL;
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //udpServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //udpServer.Bind(new IPEndPoint(IPAddress.Any, 2020));
            //new Thread(udpReceiveMessage) { IsBackground = true }.Start();
            //Console.WriteLine("服务器启动");
            listener = new UdpClient(2020);
            groupEP = new IPEndPoint(IPAddress.Any, 2020);
            new Thread(udpReceiveMessage) { IsBackground = true }.Start();
            Console.WriteLine("服务器启动");
            string hostname = Dns.GetHostName();
            axWindowsMediaPlayer1.uiMode = "none";
        }

        public void udpReceiveMessage()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref groupEP);
                    string message = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    Console.WriteLine($"Received broadcast from {groupEP} :");
                    //Console.WriteLine($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
                    Console.WriteLine(message);
                    deallingData(message);
                }
            }
            catch(SocketException e)
            {
                Console.WriteLine(e);
            }
        }

        private void deallingData(string message)
        {
            if (message == "pause")
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            else if (message == "play")
                axWindowsMediaPlayer1.Ctlcontrols.play();
            else if (message == "stop")
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            else
            {
                sourceURL = message;
                if (File.Exists(sourceURL))
                {
                    axWindowsMediaPlayer1.URL = sourceURL;
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                }
                else
                    MessageBox.Show("路径不存在或错误");
            }
        }
    }
}
