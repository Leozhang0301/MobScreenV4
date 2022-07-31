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
    public partial class StayPointForm : Form
    {
        private Config config;
        private MainFrom form;
        private bool mov_flag=false;
        public StayPointForm()
        {
            InitializeComponent();
        }

        public StayPointForm(Config config, MainFrom form)
        {
            InitializeComponent();
            this.config=config;
            this.form = form;
        }

        private void StayPointForm_Load(object sender, EventArgs e)
        {
            //加载表单
            refreshDataGrid();
        }
        #region 该页面所有按钮接口
        //添加停留点按钮接口
        private void btn_addPnt_Click(object sender, EventArgs e)
        {
            //如果距离/停留时间/文件路径为空
            if (text_dis.Text == "" || text_time.Text == "" || text_filePath.Text == "")
            {
                MessageBox.Show("请填写停留点完整信息");
            }
            else
            {
                //如果备注为空就自动变成空格
                if (text_remarks.Text == "")
                    text_remarks.Text = " ";
                addStayPoint(text_dis.Text, text_time.Text, text_filePath.Text, text_remarks.Text);
                form.saveData();
            }
        }

        //删除停留点按钮接口
        private void btn_delPnt_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("确定要删除选中的数据吗？", "提示信息！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in stayPointGridView.SelectedRows)
                    stayPointGridView.Rows.Remove(row);
                //更新配置文件内存储的停留点信息
                saveDataGridValueToArray();
                //更新表单
                refreshDataGrid();
                form.saveData();
            }
        }

        //插入停留点按钮接口
        private void btn_insertPnt_Click(object sender, EventArgs e)
        {
            //如果距离/停留时间/文件路径为空
            if (text_dis.Text == "" || text_time.Text == "" || text_filePath.Text == "" || text_filePath.Text == "点击浏览选择文件路径")
            {
                MessageBox.Show("请填写停留点完整信息");
            }
            else
            {
                if (text_remarks.Text == "")
                    text_remarks.Text = " ";
                insertStayPoint(text_dis.Text, text_time.Text, text_filePath.Text, text_remarks.Text);
                saveDataGridValueToArray();
                refreshDataGrid();
                form.saveData();
            }
        }

        //清空表单数据按钮接口
        private void btn_clearForm_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("确定要删除选中的数据吗？", "提示信息！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                stayPointGridView.Rows.Clear();
                for (int i = 0; i < 128; i++)
                    config.stayPoint_Info[i].used_flg = "N";
                form.saveData();
            }
        }

        //写入控制器按钮接口
        private void btn_writeCtl_Click(object sender, EventArgs e)
        {
            writeStayPointIntoController();
            form.saveData();
        }

        //从控制器中读取停留点按钮接口
        private void btn_readCtl_Click(object sender, EventArgs e)
        {
            readStayPointInfo();
        }

        //更新当前位置文本
        public void refreshCurPosLab(string cur)
        {
            label_posi.Text = cur;
        }
        //前进按钮接口
        private void btn_forward_Click(object sender, EventArgs e)
        {
            config.running_mode = "debug";
            if (!mov_flag)
            {
                UInt16 crc;
                form.g_SerialSendBuf[0] = 0XAA;
                form.g_SerialSendBuf[1] = 0X01;
                form.g_SerialSendBuf[2] = 0X02;
                form.g_SerialSendBuf[3] = 0X03;
                form.g_SerialSendBuf[4] = 0X03;      //功能码
                form.g_SerialSendBuf[5] = 0X01;      //数据长度
                form.g_SerialSendBuf[6] = 0X01;
                crc = form.getCRC(7);
                form.g_SerialSendBuf[7] = (byte)(crc);      //crc校验
                form.g_SerialSendBuf[8] = (byte)(crc >> 8);
                PackageCmd(9);
                btn_forward.Text = "停止";
                btn_back.Enabled = false;
                mov_flag = true;

                timer_refreshUI.Enabled = true;
                timer_refreshUI.Interval = 500;
                timer_refreshUI.Start();
            }
            else
            {
                stop_run();
                mov_flag = false;
                btn_forward.Text = "前进";
                btn_back.Enabled = true;
                timer_refreshUI.Enabled = false;
                timer_refreshUI.Stop();
            }
        }

        //后退按钮接口
        private void btn_back_Click(object sender, EventArgs e)
        {
            config.running_mode = "debug";
            if (!mov_flag)
            {
                UInt16 crc;
                form.g_SerialSendBuf[0] = 0XAA;
                form.g_SerialSendBuf[1] = 0X01;
                form.g_SerialSendBuf[2] = 0X02;
                form.g_SerialSendBuf[3] = 0X03;
                form.g_SerialSendBuf[4] = 0X03;      //功能码
                form.g_SerialSendBuf[5] = 0X01;      //数据长度
                form.g_SerialSendBuf[6] = 0X02;
                crc = form.getCRC(7);
                form.g_SerialSendBuf[7] = (byte)(crc);      //crc校验
                form.g_SerialSendBuf[8] = (byte)(crc >> 8);
                PackageCmd(9);
                mov_flag = true;
                btn_back.Text = "停止";
                btn_forward.Enabled = false;

                timer_refreshUI.Enabled = true;
                timer_refreshUI.Interval = 500;
                timer_refreshUI.Start();
            }
            else
            {
                stop_run();
                mov_flag = false;
                btn_back.Text = "后退";
                btn_forward.Enabled = true;
                timer_refreshUI.Enabled = false;
                timer_refreshUI.Stop();
            }
        }

        //记录位置按钮接口
        private void btn_recordposi_Click(object sender, EventArgs e)
        {
            //配置文件里面存储的现在位置
            text_dis.Text= config.motor.currentPosition.ToString();
            //text_time.Text = "10";
            //text_filePath.Text = "未设置视频，鼠标双击选择添加！";
            //addStayPoint(text_dis.Text, text_time.Text, text_filePath.Text, " ");
            MessageBox.Show("停留点信息已添加! 位置信息" + config.motor.currentPosition.ToString() + "mm");
        }
        #endregion

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
            crc = form.getCRC(7);
            form.g_SerialSendBuf[7] = (byte)(crc);      //crc校验
            form.g_SerialSendBuf[8] = (byte)(crc >> 8);

            PackageCmd(9);
        }

        //读取停留点指令
        private void readStayPointInfo()
        {
            //最多分5次读取数据，一次20个预置位
            UInt16 crc;
            form.g_SerialSendBuf[0] = 0XAA;
            form.g_SerialSendBuf[1] = 0X01;
            form.g_SerialSendBuf[2] = 0X02;
            form.g_SerialSendBuf[3] = 0X03;
            form.g_SerialSendBuf[4] = 0X11;      //功能码
            form.g_SerialSendBuf[5] = 0X00;      //数据长度
            crc = form.getCRC(6);
            form.g_SerialSendBuf[6] = (byte)(crc);      //crc校验
            form.g_SerialSendBuf[7] = (byte)(crc >> 8);
            PackageCmd(8);
        }

        //写入控制器
        private void writeStayPointIntoController()
        {
            if (stayPointGridView.Rows.Count != 0)
            {
                writeStayPointInfo();
                bool temp = WaitOkFromControler(10);
                if (temp)
                    ShowTipsInfo("停留点信息写入控制器成功！", Color.Green);
                else
                    ShowTipsInfo("停留点信息写入控制器--失败！请尝试重新写入", Color.Red);
            }
            else
                MessageBox.Show("请添加需要写入的数据！");
        }

        private bool WaitOkFromControler(UInt16 ack)
        {
            form.g_recvCmdAck = 0;
            Thread.Sleep(300);
            if (form.g_recvCmdAck == ack)
                return true;
            return false;
        }

        //停留点写入控制器指令
        private void writeStayPointInfo()
        {
            UInt16 crc;
            form.g_SerialSendBuf[0] = 0xAA;
            form.g_SerialSendBuf[1] = 0x01;
            form.g_SerialSendBuf[2] = 0x02;
            form.g_SerialSendBuf[3] = 0x03;//地址码
            form.g_SerialSendBuf[4] = 0x10;//功能码
            UInt16 data_len = (UInt16)stayPointGridView.Rows.Count;
            data_len *= 4;
            if (data_len > 240)
                data_len = 240;
            form.g_SerialSendBuf[5] = (byte)data_len;  //数据长度
            UInt16 tmp = (UInt16)stayPointGridView.Rows.Count;
            UInt16 i = 0;
            UInt16 j = 0;
            UInt16 tmp_data = 0;
            while (tmp > 0)
            {
                tmp_data = Convert.ToUInt16(stayPointGridView.Rows[i].Cells[1].Value);
                form.g_SerialSendBuf[6 + j] = (byte)tmp_data;
                j++;
                form.g_SerialSendBuf[6 + j] = (byte)(tmp_data >> 8);
                j++;
                tmp_data = Convert.ToUInt16(stayPointGridView.Rows[i].Cells[2].Value);
                form.g_SerialSendBuf[6 + j] = (byte)tmp_data;
                j++;
                form.g_SerialSendBuf[6 + j] = (byte)(tmp_data >> 8);
                j++;
                tmp--;
                i++;
            }
            crc = form.getCRC(6 + data_len);
            form.g_SerialSendBuf[6 + data_len] = (byte)(crc);      //crc校验
            form.g_SerialSendBuf[7 + data_len] = (byte)(crc >> 8);
            PackageCmd(8 + data_len);
        }

        //插入停留点
        private void insertStayPoint(string distance, string stayTime, string filePath, string remarks)
        {
            int row = stayPointGridView.Rows.Count;
            stayPointGridView.Rows.Insert(stayPointGridView.CurrentRow.Index, (row + 1).ToString(), distance, stayTime, filePath, remarks);
            config.stayPoint_Info[row].distance = Convert.ToInt32(distance);
            config.stayPoint_Info[row].stay_time = Convert.ToInt32(stayTime);
            config.stayPoint_Info[row].file_path = filePath;
            config.stayPoint_Info[row].remark = remarks;
            config.stayPoint_Info[row].used_flg = "Y";
        }

        //更新表单
        public void refreshDataGrid()
        {
            stayPointGridView.Rows.Clear();
            int tmp = 1;
            //老版本遍历了全部数组
            //能够只遍历标志位是Y的  可以提前break
            for(int i = 0; i < 128; i++)
            {
                if (config.stayPoint_Info[i].used_flg == "Y")
                {
                    //避免同步过来的停留点数量比电脑存储多，文件名为null出错问题
                    if (config.stayPoint_Info[i].file_path == null)
                        config.stayPoint_Info[i].file_path = "未设置视频，鼠标双击选择添加！";
                    if (config.stayPoint_Info[i].remark == null)
                        config.stayPoint_Info[i].remark = " ";
                    stayPointGridView.Rows.Add(tmp.ToString(), config.stayPoint_Info[i].distance.ToString(), config.stayPoint_Info[i].stay_time.ToString(), config.stayPoint_Info[i].file_path, config.stayPoint_Info[i].remark, config.stayPoint_Info[i].bk_pic_cordation);
                    tmp++;
                }
            }
            config.stayPointCnt=tmp-1;
        }

        //删除停留点之后要更新配置文件内部的停留点信息
        private void saveDataGridValueToArray()
        {
            //老版停留点信息使用数组存储
            //删除中间的一个停留点要重新移动整个数组
            //时间复杂度为O(N)
            //加速方法是将时间复杂度以链表形式存储
            //时间复杂度为O(1)

            //目前为了快速开发依然使用老版本
            for(int i = 0; i < 128; i++)
            {
                config.stayPoint_Info[i].used_flg = "N";
            }

            for(int i = 0; i < stayPointGridView.Rows.Count; i++)
            {
                config.stayPoint_Info[i].distance = Convert.ToInt32(stayPointGridView.Rows[i].Cells[1].Value);
                config.stayPoint_Info[i].stay_time = Convert.ToInt32(stayPointGridView.Rows[i].Cells[2].Value);
                config.stayPoint_Info[i].file_path = stayPointGridView.Rows[i].Cells[3].Value.ToString();
                config.stayPoint_Info[i].remark = stayPointGridView.Rows[i].Cells[4].Value.ToString();
                config.stayPoint_Info[i].used_flg = "Y";
            }
        }

        //添加停留点
        private void addStayPoint(string distance, string time, string filePath, string remarks)
        {
            int row = stayPointGridView.Rows.Count;
            stayPointGridView.Rows.Add((row + 1).ToString(), distance, time, filePath, remarks);
            config.stayPoint_Info[row].distance = Convert.ToInt32(distance);
            config.stayPoint_Info[row].stay_time = Convert.ToInt32(time);
            config.stayPoint_Info[row].file_path = filePath;
            config.stayPoint_Info[row].remark = remarks;
            config.stayPoint_Info[row].used_flg = "Y";
        }

        //点击添加文件路径事件
        private void text_filePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                text_filePath.Text = dialog.FileName;
            }
        }

        private void PackageCmd(Int32 byte_count)
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
                ShowTipsInfo("通信配置出错,不是网络串口的其中一个", Color.Red, byte_count);
            }
        }
        //带指令内容的输出
        private void ShowTipsInfo(string v, Color c, int cnt)
        {
            consoleBox.SelectionStart = consoleBox.TextLength;
            consoleBox.SelectionLength = v.Length;
            consoleBox.SelectionColor = c;
            consoleBox.AppendText("[" + DateTime.Now
                    + "]: " + BitConverter.ToString(form.g_SerialSendBuf.Take(cnt).ToArray())
                    + v + "\r\n");
        }
        //不带指令内容的输出
        public void ShowTipsInfo(string v, Color c)
        {
            consoleBox.SelectionStart = consoleBox.TextLength;
            consoleBox.SelectionLength = v.Length;
            consoleBox.SelectionColor = c;
            consoleBox.AppendText("[" + DateTime.Now + "]: " + v + "\r\n");

        }

        //更新UI控件计时器
        private void timer_refreshUI_Tick(object sender, EventArgs e)
        {
            label_posi.Text = config.motor.currentPosition.ToString();
        }

        private void stayPointGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int index = stayPointGridView.CurrentCell.RowIndex;
                    config.stayPoint_Info[index].file_path = dialog.FileName;
                    stayPointGridView.Rows[index].Cells[3].Value = dialog.FileName;
                    form.saveData();
                }
            }
        }

        private void stayPointGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int index = stayPointGridView.CurrentCell.RowIndex;
            //如果编辑的是距离
            if (e.ColumnIndex == 1)
                config.stayPoint_Info[index].distance = Convert.ToInt32(stayPointGridView.Rows[index].Cells[1].Value);
            //如果编辑的是停留时间
            else if (e.ColumnIndex == 2)
                config.stayPoint_Info[index].stay_time = Convert.ToInt32(stayPointGridView.Rows[index].Cells[2].Value);
            //如果编辑的是备注
            else if (e.ColumnIndex == 4)
                config.stayPoint_Info[index].remark = Convert.ToString(stayPointGridView.Rows[index].Cells[4].Value);
            //底图偏移
            else if (e.ColumnIndex == 5)
                config.stayPoint_Info[index].bk_pic_cordation = Convert.ToInt32(stayPointGridView.Rows[index].Cells[5].Value);
            //文件路径更改事件在双击事件内部

            form.saveData();
        }
    }
}
