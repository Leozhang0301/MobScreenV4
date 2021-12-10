using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace MobScreenV4
{
    [Serializable]
    public class Config
    {
        public string version;
        public string net_or_com;
        public Motor motor;
        public byte startPosition=0;//起点方向 1为右起点  0为左起点
        public int totalLength = 1000;
        //内部电机类
        [Serializable]
        public class Motor
        {
            public string Motor_version="V5.19";
            public string versionA="0";//控制器版本高位
            public string versionB="0";//控制器版本低位
            public int speed=1;//电机速度
            public int AccSpeed=3000;//电机加速度
            public int decSpeed=3000;//电机减速度
        }
        public Config()
        {
            net_or_com = "COM";
            version = "V4.0";
            this.motor = new Motor();
        }
    }
}
