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
using System.IO.Ports;
using System.Drawing.Imaging;

namespace Case05_4
{
    public partial class ImageCollecter : Form
    {
        private int flag = 0;
        private int imageNum = 0;//imageList的计数器
        private string path = "";//图片或视频的存储路径
        private bool bCOMPress = true;//控制脚踏开关截图的事件锁，500毫秒/次
        private string serialPortName = "COM1";//脚踏开关连接的COM口，默认为COM1口.
        private string str = ""; //获取 本机镜检资料的文件夹存储路径 + 检查的病人姓名 + 时间
        private int picName =0;//图片的名字
        private string mpgName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".mpg";//高清视频的名字
        //private string wmvNmae = DateTime.Now.ToString("yyyyMMddHHmmss") + ".wmv";//标清视频的名字
        private int iRetVal;//获取采集卡初始化的相关信息
        private int iTempIndex = 0;//索引号，自己给的
        private ini ini;//读取config.ini的配置文件
        private bool pictureFill = false;
        bool twice = true;

        private uint m_uDeviceNum = 0;//获取本机的采集卡数量，初始值为0
        private uint iTempdeviceType = (int)DEVICETYPE.DEVICETYPE_HD;//参数设置为高清
        private uint frameRate;
        private IntPtr m_hCaptureDevice = new IntPtr();//获取设备信息
        private static VIDEO_CAPTURE_INFO m_PictureCaptureInfo = new VIDEO_CAPTURE_INFO();//照片的数据结构体，结构体内有如照片格式等的相关参数
        private static VIDEO_CAPTURE_INFO m_VideoCaptureInfo = new VIDEO_CAPTURE_INFO();//高清MPG视频的数据结构体，结构体内有相关参数
        private static WMV_VIDEOENCODER_INFO m_WMVVideoEncoderInfo = new WMV_VIDEOENCODER_INFO();//标清WMV视频的数据结构体，结构体内有相关参数
        private static MPEG4_VIDEOENCODER_INFO m_mpegVideoEncoderInfo = new MPEG4_VIDEOENCODER_INFO();//MPEG-4制式的数据结构体，结构体内有相关参数
        private RECT RectClient = new RECT();//存放照片的一个矩形
        private string Current = AppDomain.CurrentDomain.BaseDirectory;//当前路径

        /**
         * 构造函数，包含：
         * openSerialPort(serialPortName);
         * fileExitedOrNot(name, name);
         * initAver();
         * serialPortName 从配置文件config.ini中读取选取的COM端口号
         **/
        public ImageCollecter(string name, string time)
        {
            InitializeComponent();
            //openSerialPort(serialPortName);

            skinEngine1.SkinFile = "Emerald.ssk";
            skinEngine1.SkinAllForm = false;

            button3.Enabled = true;
            button4.Enabled = false;
            try
            {
                ini = new ini(Current + "\\config.ini");
                serialPortName = ini.ReadValue("setting", "serialPortName");
                openSerialPort(serialPortName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("脚踏开关启动失败，请检查串口硬件", "视频采集系统");
            }
            fileExitedOrNot(name, time);
            initAver();
        }

        /**
         * 检查该病人的镜检资料文件夹是否存在
         **/
        private void fileExitedOrNot(string name, string time)
        {
            /**获取此病人镜检资料的具体存储路径**/
            ini = new ini(Current + "\\config.ini");
            str = ini.ReadValue("Setting", "data");
            str += "\\" + name + "\\" + time + "\\";
            /**获取此病人镜检资料的具体存储路径**/

            if (!Directory.Exists(str))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(str); //新建文件夹  
            }
        }

        /**
         * 采集卡参数初始化
         **/
        private void initAver()
        {
            if (AVerCapAPI.AVerGetDeviceNum(ref m_uDeviceNum) != (int)ERRORCODE.CAP_EC_SUCCESS)
            {
                MessageBox.Show("抱歉，获取不到本机的采集卡硬件信息", "视频采集系统");
                return;
            }
            iTempIndex = 0;
            iTempdeviceType = (int)DEVICETYPE.DEVICETYPE_HD;
            iRetVal = AVerCapAPI.AVerCreateCaptureObjectEx((uint)iTempIndex, iTempdeviceType, pictureBoxShowMain.Handle, ref m_hCaptureDevice);
            AVerCapAPI.AVerSetVideoResolution(m_hCaptureDevice, (uint)VIDEORESOLUTION.VIDEORESOLUTION_1920X1080P);
            AVerCapAPI.AVerSetVideoSource(m_hCaptureDevice, (uint)VIDEOSOURCE.VIDEOSOURCE_HDMI);
            AVerCapAPI.AVerSetVideoRenderer(m_hCaptureDevice, (uint)VIDEORENDERER.VIDEORENDERER_EVR);
            AVerCapAPI.AVerSetVideoFormat(m_hCaptureDevice, (uint)VIDEOFORMAT.VIDEOFORMAT_PAL);
            setMPEGInfo();

            //iRetVal = AVerCapAPI.AVerCreateCaptureObjectEx((uint)iTempIndex, iTempdeviceType, pictureBoxShowMain.Handle, ref m_hCaptureDevice);
            switch (iRetVal)
            {
                case (int)ERRORCODE.CAP_EC_SUCCESS:
                    break;
                case (int)ERRORCODE.CAP_EC_DEVICE_IN_USE:
                    MessageBox.Show("设备已经被使用", "视频采集系统");
                    return;
                default:
                    MessageBox.Show("设备不能初始化", "视频采集系统");
                    return;
            }
            //AVerCapAPI.AVerSetVideoInputFrameRate(m_hCaptureDevice,(uint)5000);
            //MessageBox.Show(AVerCapAPI.AVerGetVideoInputFrameRate(m_hCaptureDevice, ref frameRate) + "rate" + frameRate);
            //setMPEGInfo();
        }

        /**
         * MPEG格式相关参数初始化
         **/
        private void setMPEGInfo()
        {
            m_mpegVideoEncoderInfo.dwVersion = 2;
            m_mpegVideoEncoderInfo.dwQuality = (uint)IMAGEQUALITY.IMAGEQUALITY_BEST;
            m_mpegVideoEncoderInfo.bHardwareAcceleration = 1;
            m_mpegVideoEncoderInfo.dwBitrate = 15000;
            m_mpegVideoEncoderInfo.dwGOPLength = 30;
            AVerCapAPI.AVerSetMpeg4VideoEncoderInfo(m_hCaptureDevice, ref m_mpegVideoEncoderInfo);
        }

        /**
         * 载入From2时启动函数
         **/
        private void Form2_Load(object sender, EventArgs e)
        {
            //int error = AVerCapAPI.AVerStartStreaming(m_hCaptureDevice);
            if (AVerCapAPI.AVerStartStreaming(m_hCaptureDevice) != (int)ERRORCODE.CAP_EC_SUCCESS)
            {

                MessageBox.Show("对不起，打不开视频采集流", "视频采集系统");
                return;
            }

            RectClient.Left = 0;
            RectClient.Top = 0;
            RectClient.Right = pictureBoxShowMain.Width;
            RectClient.Bottom = pictureBoxShowMain.Height;

            AVerCapAPI.AVerSetVideoWindowPosition(m_hCaptureDevice, RectClient);
            /*存入图像*/
            for (int i = 0; i < imageList1.Images.Count; i++)
            {
                listView1.Items.Add("", i);
                listView1.Items[i].ImageIndex = i;
            }
        }

        /**
         * 获取路径
         */
        public String getPath()
        {
            return str;
        }

        /**
        * 打开COM口
        **/
        private void openSerialPort(string portName)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1.PortName = portName;
            serialPort1.BaudRate = 9600;
            serialPort1.Open();
        }

        /**
        * 截图
        **/
        private void savePicture()
        {
            picName++;
            if (str != "")
            {
                path = str + picName + ".jpg";
            }/*
            m_PictureCaptureInfo.bOverlayMix = 0;
            m_PictureCaptureInfo.dwCaptureType = (uint)CT_SEQUENCE.CT_SEQUENCE_FRAME;
            m_PictureCaptureInfo.dwSaveType = (uint)SAVETYPE.ST_BMP;
            m_PictureCaptureInfo.dwDurationMode = (uint)DURATIONMODE.DURATION_TIME;
            m_PictureCaptureInfo.dwDuration = 100;
            m_PictureCaptureInfo.lpFileName = path;
            //MessageBox.Show("can't stop" + path, "AVer Capture SDK");
            //m_VideoCaptureInfo.lpCallback = m_VideoCaptureCallBack;
            //m_VideoCaptureInfo.lCallbackUserData = (int)m_hHDCaptureDevice;




            if (AVerCapAPI.AVerCaptureVideoSequenceStart(m_hCaptureDevice, m_PictureCaptureInfo) == (uint)ERRORCODE.CAP_EC_SUCCESS)
            {
                
                //this.listView1.Refresh();
            }
            else
            {
                MessageBox.Show("抱歉，无法开始视频录制，请检查设备是否被占用", "视频采集系统");
            }*/
            Image saveImage = ByteArrayToImage();

            imageList1.Images.Add(saveImage);
            imageList1.Images.SetKeyName(flag++, path);
            ListViewItem lvi = new ListViewItem();
            lvi.ImageIndex = imageNum++;
            lvi.Name = path;
            this.listView1.Items.Add(lvi);

            saveImage.Save(path , ImageFormat.Jpeg);
            /* Thread.Sleep(1000);
               path = path + DateTime.Now.AddSeconds(-1).ToString("yyyyMMddHHmmss") + "_0.png";
               try
               {  
                   imageList1.Images.Add(Image.FromFile(path));
                   imageList1.Images.SetKeyName(flag++, path);
                   ListViewItem lvi = new ListViewItem();
                   lvi.ImageIndex = imageNum++;
                   lvi.Name = path;
                   this.listView1.Items.Add(lvi);
                   //this.listView1.Refresh();
               }
               catch (Exception ex)
               {
                   MessageBox.Show("操作过快，请稍候再试", "视频采集系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }*/
        }

        /**
         * 开始录制视频
         **/
        private void saveMovie()
        {
            if (str != "")
            {
                path = str + mpgName;
            }
            m_VideoCaptureInfo.dwCaptureType = (uint)CT_SEQUENCE.CT_SEQUENCE_FRAME;
            m_VideoCaptureInfo.dwSaveType = (uint)SAVETYPE.ST_MPG;
            m_VideoCaptureInfo.lpFileName = path;

            int error = AVerCapAPI.AVerCaptureVideoSequenceStart(m_hCaptureDevice, m_VideoCaptureInfo);
            if (error != (uint)ERRORCODE.CAP_EC_SUCCESS)
            {
                MessageBox.Show("抱歉，无法开始视频录制，请检查设备是否被占用" + error, "视频采集系统");
            }
            AVerCapAPI.AVerSetVideoWindowPosition(m_hCaptureDevice, RectClient);
        }

        /*
         * 抓取脚踏开关信息
         */
        private void serialPort1_PinChanged(object sender, System.IO.Ports.SerialPinChangedEventArgs e)
        {
            switch (e.EventType)
            {
                case SerialPinChange.Break:
                    MessageBox.Show("\t设备已经断开，请检查脚踏开关接口\n", "视频采集系统");
                    break;
                case SerialPinChange.CtsChanged:
                    if (bCOMPress == true)
                    {
                        if (twice)
                        {
                            savePicture();
                            Thread.Sleep(30);
                            this.Refresh();
                            
                            twice = false;
                        }
                        else
                        {
                            twice = true;
                        }
                        bCOMPress = false;
                    }
                    break;
            }
        }

        /*
         * Timer的触发事件
         */
        private void timer1_Tick(object sender, EventArgs e)
        {
            bCOMPress = true;
        }

        /*
         * listView的双击触发事件
         */
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int i = listView1.SelectedItems[0].Index;
            MyImage form = new MyImage(listView1.Items[i].Name, 1);
            form.Show();
        }

        /*
         * 保存图像button的触发事件
         */
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        /*
         * 截图button的触发事件
         */
        private void button2_Click(object sender, EventArgs e)
        {
            savePicture();
        }

        /*
         * 开始录像button的触发事件
         */
        private void button3_Click(object sender, EventArgs e)
        {
            saveMovie();
            button3.Enabled = false;
            button4.Enabled = true;
        }

        /*
         * 停止录像button的触发事件
         */
        private void button4_Click(object sender, EventArgs e)
        {
            int error = AVerCapAPI.AVerCaptureVideoSequenceStop(m_hCaptureDevice);
            if (error != (uint)ERRORCODE.CAP_EC_SUCCESS)
            {
                MessageBox.Show("抱歉，录制无法停止，请检查设备是否被占用" + error, "视频采集系统");
            }
            button3.Enabled = true;
            button4.Enabled = false;
            AVerCapAPI.AVerSetVideoWindowPosition(m_hCaptureDevice, RectClient);
        }

        /*
         * 取消button的触发事件
         */
        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        /*
         * 关闭窗口时的触发事件
         */
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            AVerCapAPI.AVerCaptureVideoSequenceStop(m_hCaptureDevice);
            AVerCapAPI.AVerStopStreaming(m_hCaptureDevice);
            AVerCapAPI.AVerDeleteCaptureObject(m_hCaptureDevice);
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }



        public Image ByteArrayToImage() 
        {
            int nBufferSize = 0;
            byte[] bBuffer = null;
            AVerCapAPI.AVerCaptureSingleImageToBuffer(m_hCaptureDevice, bBuffer, ref nBufferSize, 1, 2000);

            //capture image
            bBuffer = new byte[nBufferSize];
            int iRetVal = 0;
            iRetVal = AVerCapAPI.AVerCaptureSingleImageToBuffer(m_hCaptureDevice, bBuffer, ref nBufferSize, 1, 2000);

            MemoryStream ms = new MemoryStream(bBuffer); 
            Image returnImage = Image.FromStream(ms);
            while (judgeSavedPic(nBufferSize, bBuffer) == false)
            {
               Thread.Sleep(0);
               this.UseWaitCursor = true;
            }
            this.UseWaitCursor = false;

            return returnImage; 
        }
        private void pictureBoxShowMain_DoubleClick(object sender, EventArgs e)
        {
            if (pictureFill == false)
            {
                this.Dock = DockStyle.Fill;
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                listView1.Visible = false;
                pictureBoxShowMain.Dock = DockStyle.Fill;
                RECT Rect = new RECT();//存放照片的一个矩形
                Rect.Left = 0;
                Rect.Top = 0;
                Rect.Right = pictureBoxShowMain.Width;
                Rect.Bottom = pictureBoxShowMain.Height;
                AVerCapAPI.AVerSetVideoWindowPosition(m_hCaptureDevice, Rect);
                pictureFill = true;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                this.Dock = DockStyle.None;
                this.WindowState = FormWindowState.Normal;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                listView1.Visible = true;
                pictureBoxShowMain.Dock = DockStyle.None;
                AVerCapAPI.AVerSetVideoWindowPosition(m_hCaptureDevice, RectClient);
                pictureFill = false;
            }
        }
        private bool judgeSavedPic(int nBufferSize,byte[] bBuffer)
        {
            bool judgeFirst = false;
            bool judge = false;
            bool judgeLast = false;
            int a = 0;
            int b = nBufferSize-1;
            int count = nBufferSize / 2;
            while (a < count)
            {
                if (bBuffer[a].ToString() != "0")
                {
                    judgeFirst = true;
                    break;
                }
                a++;
            }
            while (b > count)
            {
                if (bBuffer[b].ToString() != "0")
                {
                    judgeLast = true;
                    break;
                }
                b--;
            }
            if (judgeFirst == true && judgeLast == true)
            {
                return true;
            }

            return judge;
        }

    }
}