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
        public string version="V4.0";
        public string net_or_com="COM";
        public Motor motor;
        public byte startPosition=0;//起点方向 1为右起点  0为左起点
        public int totalLength = 1000;//全长
        public string portName = "COM5";
        public stayPointInfo[] stayPoint_Info;
        public string running_mode = "time_con";//time_con 定时模式/film_con 节目模式/run_once 只运行一遍
        public int stayPointCnt = 0;//记录停留点的个数
        //停留点信息结构体
        [Serializable]
        public struct stayPointInfo
        {
            //为啥要加internal关键词才能用呢,否则提示受保护
            internal string used_flg;             //是否使用标志
            internal Int32 distance;            //距离
            internal Int32 stay_time;           //停留时间
            internal string file_path;          //播放视频文件路径及名称
            internal string remark;               //注释
            internal string bk_used_flg;             //底图校准坐标是否使用
            internal double bk_pic_cordation;             //底图坐标
        }
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
            public UInt16 currentPosition;//当前位置  这是距远点的距离
            public byte stayPointact = 0;//当前在的停留点
            public bool inPosiFlag = false;
        }
        public Config()
        {
            this.motor = new Motor();
            stayPoint_Info = new stayPointInfo[128];
        }
    }
}
