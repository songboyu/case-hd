using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Case05_4
{
    public partial class MySettings : Form
    {
        string Current = AppDomain.CurrentDomain.BaseDirectory;//获取当前根目录
        ini ini;
        public MySettings()
        {
            InitializeComponent();

            skinEngine1.SkinFile = "Emerald.ssk";
            skinEngine1.SkinAllForm = false;

            ini = new ini(Current + "\\config.ini");
            textBox1.Text = ini.ReadValue("Setting", "table");
            textBox2.Text = ini.ReadValue("Setting", "data");
            textBox3.Text = ini.ReadValue("Setting", "mainTitle");
            textBox4.Text = ini.ReadValue("Setting", "subTitle");
            textBox5.Text = ini.ReadValue("Setting", "ico");
            textBox6.Text = ini.ReadValue("Setting", "backImage");
            textBox6.ReadOnly = true;
            averDeviceType.Text = ini.ReadValue("Setting", "averDeviceType");
            cbxPortName.Text = ini.ReadValue("Setting", "serialPortName");
            AddSerialPort();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) 
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            ini.Writue("Setting", "table", textBox1.Text);
            ini.Writue("Setting", "data", textBox2.Text);
            ini.Writue("Setting", "mainTitle", textBox3.Text);
            ini.Writue("Setting", "subTitle", textBox4.Text);
            ini.Writue("Setting", "ico", textBox5.Text);
            ini.Writue("Setting", "backImage", textBox6.Text);
            if (cbxPortName.SelectedItem != null)
            {
                ini.Writue("Setting", "serialPortName", cbxPortName.SelectedItem.ToString());
                this.Close();
            }
            else
            {
                MessageBox.Show("您没有选择脚踏开关的COM接口,脚踏开关设备可能无法正常使用", "视频采集系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (averDeviceType.SelectedItem != null)
            {
                ini.Writue("Setting", "averDeviceType", averDeviceType.SelectedItem.ToString());
                this.Close();
            }
            else
            {
                MessageBox.Show("您没有选择视频的制式,图像采集设备可能无法正常使用", "视频采集系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "*.jpg|*.jpg|*.bmp|*.bmp|*.png|*.png|*.ico|*.ico|*.*|*.*";
            this.openFileDialog1.InitialDirectory = Current;
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = openFileDialog1.FileName;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NewSheet form = new NewSheet(true);
            form.ShowDialog();
        }

        /**
         * 查询电脑内部的COM口列表，并写入ComboBox中
         **/
        private void AddSerialPort()
        {
            Microsoft.VisualBasic.Devices.Computer pc = new Microsoft.VisualBasic.Devices.Computer();
            foreach (string s in pc.Ports.SerialPortNames)
            {
                this.cbxPortName.Items.Add(s);
            }
        }

        /**
        *  设置视频采集的模式，并写入ComboBox中
         *  @param HD SD
        **/
        private void AddDeviceType()
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {

            this.openFileDialog1.Filter = "*.jpg|*.jpg|*.bmp|*.bmp|*.png|*.png|*.ico|*.ico|*.*|*.*";
            this.openFileDialog1.InitialDirectory = Current;
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox6.Text = openFileDialog1.FileName;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangePassWord form = new ChangePassWord();
            form.ShowDialog();
        }
    }
}
