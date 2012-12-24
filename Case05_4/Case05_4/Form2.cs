﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Case05_4
{
    public partial class Form2 : Form
    {
        private uint m_uDeviceNum = 0;
        private uint m_uDeviceResolution = 1;
        private uint iTempdeviceType = (int)DEVICETYPE.DEVICETYPE_HD;
        private IntPtr m_hCaptureDevice = new IntPtr();
        private static VIDEO_CAPTURE_INFO m_PictureCaptureInfo = new VIDEO_CAPTURE_INFO();
        private static VIDEO_CAPTURE_INFO m_VideoCaptureInfo = new VIDEO_CAPTURE_INFO();
        private RECT RectClient = new RECT();
        private string path = "";
        private string str = System.Environment.CurrentDirectory+"\\backup\\";
        private string picName = "";
        private string mp4Name = "";
        private int count = 0;
        private int delete = 0;
        private int pr = 0;

        public Form2(string name)
        {
            InitializeComponent();
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            str += name;
            picName = "\\" + name;
            mp4Name = "\\" + name + time + ".AVI";
            if (!Directory.Exists(str))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(str); //新建文件夹   
            }

            if (AVerCapAPI.AVerGetDeviceNum(ref m_uDeviceNum) != (int)ERRORCODE.CAP_EC_SUCCESS)
            {
                MessageBox.Show("Can't get the number of devices.", "AVer Capture SDK");
                return;
            }
            button3.Enabled = true;
            button4.Enabled = false;
            int iRetVal;
            int iTempIndex = 0;//索引号，自己给的
            iRetVal = AVerCapAPI.AVerCreateCaptureObjectEx((uint)iTempIndex, iTempdeviceType, pictureBoxShowMain.Handle, ref m_hCaptureDevice);
            switch (iRetVal)
            {
                case (int)ERRORCODE.CAP_EC_SUCCESS:
                    break;
                case (int)ERRORCODE.CAP_EC_DEVICE_IN_USE:
                    MessageBox.Show("设备已经被使用", "AVer Capture SDK");
                    return;
                default:
                    MessageBox.Show("设备不能初始化", "AVer Capture SDK");
                    return;
            }
            RectClient.Left = 0;
            RectClient.Top = 0;
            RectClient.Right = pictureBoxShowMain.Width;
            RectClient.Bottom = pictureBoxShowMain.Height;
            AVerCapAPI.AVerSetVideoRenderer(m_hCaptureDevice, (uint)VIDEORENDERER.VIDEORENDERER_DEFAULT);
            AVerCapAPI.AVerSetVideoSource(m_hCaptureDevice, (uint)VIDEOSOURCE.VIDEOSOURCE_HDMI);
            AVerCapAPI.AVerSetVideoResolution(m_hCaptureDevice, (uint)VIDEORESOLUTION.VIDEORESOLUTION_1920X1080P);
            AVerCapAPI.AVerGetVideoResolution(m_hCaptureDevice, ref m_uDeviceResolution);
            MessageBox.Show("AVerGetVideoResolution: " + m_uDeviceResolution, "AVer Capture SDK");
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            AVerCapAPI.AVerCaptureVideoSequenceStop(m_hCaptureDevice);
            AVerCapAPI.AVerStopStreaming(m_hCaptureDevice);
            AVerCapAPI.AVerDeleteCaptureObject(m_hCaptureDevice);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (str != "")
            {
                path = str + mp4Name;
            }
            m_VideoCaptureInfo.dwSaveType = (uint)SAVETYPE.ST_AVI;
            m_VideoCaptureInfo.lpFileName = path;
            //MessageBox.Show("can't stop" + path, "AVer Capture SDK");
            //m_MPEG2VideoEncoderInfo.dwVersion = 1;
            //m_MPEG2VideoEncoderInfo.dwBitrate = 10000;
            //AVerCapAPI.AVerSetMpeg2VideoEncoderInfo(m_hCaptureDevice, ref m_MPEG2VideoEncoderInfo);

            if (AVerCapAPI.AVerCaptureVideoSequenceStart(m_hCaptureDevice, m_VideoCaptureInfo) != (uint)ERRORCODE.CAP_EC_SUCCESS)
            {
                MessageBox.Show("can't stop", "AVer Capture SDK");
            }
            AVerCapAPI.AVerSetVideoWindowPosition(m_hCaptureDevice, RectClient);
            button3.Enabled = false;
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (AVerCapAPI.AVerCaptureVideoSequenceStop(m_hCaptureDevice) != (uint)ERRORCODE.CAP_EC_SUCCESS)
            {
                MessageBox.Show("", "AVer Capture SDK");
            }
            button3.Enabled = true;
            button4.Enabled = false;
            AVerCapAPI.AVerSetVideoWindowPosition(m_hCaptureDevice, RectClient);
        }
        public string PATH1
        {
            get { return pictureBox1.ImageLocation; }
        }
        public string PATH2
        {
            get { return pictureBox2.ImageLocation; }
        }
        public string PATH3
        {
            get { return pictureBox3.ImageLocation; }
        }
        public string PATH4
        {
            get { return pictureBox4.ImageLocation; }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (str != "")
            {
                path = str + picName;
            }
            m_PictureCaptureInfo.bOverlayMix = 0;
            m_PictureCaptureInfo.dwCaptureType = (uint)CT_SEQUENCE.CT_SEQUENCE_FRAME;
            m_PictureCaptureInfo.dwSaveType = (uint)SAVETYPE.ST_PNG;
            m_PictureCaptureInfo.dwDurationMode = (uint)DURATIONMODE.DURATION_COUNT;
            m_PictureCaptureInfo.dwDuration = 1;
            m_PictureCaptureInfo.lpFileName = path;
            //MessageBox.Show("can't stop" + path, "AVer Capture SDK");
            //m_VideoCaptureInfo.lpCallback = m_VideoCaptureCallBack;
            //m_VideoCaptureInfo.lCallbackUserData = (int)m_hHDCaptureDevice;
            AVerCapAPI.AVerCaptureVideoSequenceStart(m_hCaptureDevice, m_PictureCaptureInfo);
            
            Thread.Sleep(1000);
            path = path + DateTime.Now.AddSeconds(-1).ToString("yyyyMMddHHmmss") + "_0.png";
            if( delete == 0 )
            {
                if (pr > 3 )
                {
                    int countTemp = count % 4 + 1;
                    if (MessageBox.Show("你确定要覆盖第" + countTemp + "张图片?", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        count = count % 4;
                    }
                    else
                        count = count + 4;
                }
                if (count < 4)
                {
                    switch (count)
                    {
                        case 0:
                            pictureBox1.ImageLocation = path;
                            break;
                        case 1:
                            pictureBox2.ImageLocation = path;
                            break;
                        case 2:
                            pictureBox3.ImageLocation = path;
                            break;
                        case 3:
                            pictureBox4.ImageLocation = path;
                            break;
                        default:
                            break;
                    }
                    count++;
                    pr++;
                }
                
            }
            if (delete == 1)
            {
                pictureBox1.ImageLocation = path;
                delete = 0;
            }
            if (delete == 2)
            {
                pictureBox2.ImageLocation = path;
                delete = 0;
            }
            if (delete == 3)
            {
                pictureBox3.ImageLocation = path;
                delete = 0;
            }
            if (delete == 4)
            {
                pictureBox4.ImageLocation = path;
                delete = 0;
            }
            
            
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            if (AVerCapAPI.AVerStartStreaming(m_hCaptureDevice) != (int)ERRORCODE.CAP_EC_SUCCESS)
            {
                MessageBox.Show("Can't start streaming", "AVer Capture SDK");
                return;
            }
            RECT RectClient = new RECT();
            RectClient.Left = 0;
            RectClient.Top = 0;
            RectClient.Right = pictureBoxShowMain.Width;
            RectClient.Bottom = pictureBoxShowMain.Height;
            AVerCapAPI.AVerSetVideoWindowPosition(m_hCaptureDevice, RectClient);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show("你确定要删除该图片?", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (e.Button == MouseButtons.Right)
                {
                    pictureBox1.ImageLocation = "";
                    delete = 1;
                }
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show("你确定要删除该图片?", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (e.Button == MouseButtons.Right)
                {
                    pictureBox2.ImageLocation = "";
                    delete = 2;
                }
            }
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show("你确定要删除该图片?", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (e.Button == MouseButtons.Right)
                {
                    pictureBox3.ImageLocation = "";
                    delete = 3;
                }
            }
        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show("你确定要删除该图片?", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (e.Button == MouseButtons.Right)
                {
                    pictureBox4.ImageLocation = "";
                    delete = 4;
                }
            }
        }
    }
}