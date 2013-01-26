using System;
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
        int imageNum = 0;
        int flag = 0;

        private uint m_uDeviceNum = 0;
      //  private uint m_uDeviceResolution = 1;
        private uint iTempdeviceType = (int)DEVICETYPE.DEVICETYPE_HD;
        private IntPtr m_hCaptureDevice = new IntPtr();
        private static VIDEO_CAPTURE_INFO m_PictureCaptureInfo = new VIDEO_CAPTURE_INFO();
        private static VIDEO_CAPTURE_INFO m_VideoCaptureInfo = new VIDEO_CAPTURE_INFO();
        private static MPEG4_VIDEOENCODER_INFO m_mpegVideoEncoderInfo = new MPEG4_VIDEOENCODER_INFO();
        private RECT RectClient = new RECT();
        private string path = "";
        private string str;
        private string picName;
        private string mpgName;
        private string Current = AppDomain.CurrentDomain.BaseDirectory;

        public Form2(string name, string time)
        {
            InitializeComponent();
            ini ini = new ini(Current + "\\config.ini");
            str = ini.ReadValue("Setting", "data");
            str += "\\"+name + "\\" + time + "\\";
            if (!Directory.Exists(str))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(str); //新建文件夹  
            }
            picName = "";
            mpgName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".mpg";
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
            setMPEGInfo();
            //AVerCapAPI.AVerGetVideoResolution(m_hCaptureDevice, ref m_uDeviceResolution);
            //MessageBox.Show("AVerGetVideoResolution: " + m_uDeviceResolution, "AVer Capture SDK");
        }
        private void setMPEGInfo()
        {
            m_mpegVideoEncoderInfo.dwVersion = 2;
            m_mpegVideoEncoderInfo.dwQuality = (uint)IMAGEQUALITY.IMAGEQUALITY_BEST;
            m_mpegVideoEncoderInfo.dwBitrate = 15000;
            m_mpegVideoEncoderInfo.dwGOPLength = 30;
            AVerCapAPI.AVerSetMpeg4VideoEncoderInfo(m_hCaptureDevice, ref m_mpegVideoEncoderInfo);
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
        public ImageList getPath()
        {
            return imageList1;
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int i = listView1.SelectedItems[0].Index;
            table form = new table(listView1.Items[i].Name, 1);
            form.Show();
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
            try
            {
                imageList1.Images.Add(Image.FromFile(path));
                imageList1.Images.SetKeyName(flag++, path);
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = imageNum++;
                lvi.Name = path;
                this.listView1.Items.Add(lvi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败，请稍候再试", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (str != "")
            {
                path = str + mpgName;
            }
            m_VideoCaptureInfo.dwSaveType = (uint)SAVETYPE.ST_MPG;
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("放弃保存?", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            AVerCapAPI.AVerCaptureVideoSequenceStop(m_hCaptureDevice);
            AVerCapAPI.AVerStopStreaming(m_hCaptureDevice);
            AVerCapAPI.AVerDeleteCaptureObject(m_hCaptureDevice);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}