using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;

namespace Case05_4
{
    public partial class load : Form
    {
        private string Current = AppDomain.CurrentDomain.BaseDirectory;
        ini ini;
        public load()
        {
            verifySignature();
            connectDB();
            InitializeComponent();
            
            ini = new ini(Current + "\\config.ini");
            label1.Text = ini.ReadValue("Setting", "mainTitle");
            label2.Text = ini.ReadValue("Setting", "subTitle");
            pictureBox1.ImageLocation = ini.ReadValue("Setting", "ico");
            this.BackgroundImage = Image.FromFile(ini.ReadValue("Setting", "backImage"));

            try
            {
                this.infoTableAdapter.Fill(this.病历信息DataSet.info);
            }
            catch (Exception ex)
            {
                MessageBox.Show("对不起，数据库连接失败", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process process = Process.GetCurrentProcess();
                process.CloseMainWindow();
                process.Kill();
            }
        }

        private void load_Load(object sender, EventArgs e)
        {

            this.Opacity = 0;
            this.timer1.Interval = 100;
            this.timer1.Enabled = true;
            this.timer1.Start();

            //将配置文件的数据库密码置为空。
            string newName = "Case05_4.Properties.Settings.病历信息ConnectionString";
            string newConString = @"Data Source=|DataDirectory|\病历信息.sdf;Persist Security Info=True";
            string nowpath = "Case05_4.exe.config";

            XmlDocument doc = new XmlDocument();
            doc.Load(nowpath);

            //MessageBox.Show(newConString);

            XmlNode node = doc.SelectSingleNode("//connectionStrings");//获取connectionStrings节点
            try
            {
                XmlElement element = (XmlElement)node.SelectSingleNode("//add[@name='" + newName + "']");
                if (element != null)
                {
                    //存在更新子节点
                    element.SetAttribute("connectionString", newConString);

                }
                doc.Save(nowpath);
            }

            catch (InvalidCastException ex)
            {
                throw ex;
            }
        }
        public Boolean CheckDataPath()
        {
            String dirPath = ini.ReadValue("Setting", "table");
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            Console.WriteLine(GetFreeSpace(dirInfo.Root.Name));
            if (!dirInfo.Exists)
            {
                MessageBox.Show("报告储存路径不存在，请进入系统设置更改路径", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (GetFreeSpace(dirInfo.Root.Name) < 5000000000)
            {
                MessageBox.Show("图片与视频储存磁盘空间不足5G，请进入系统设置更改路径", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;

        }
        public Boolean CheckTablePath()
        {
            String dirPath = ini.ReadValue("Setting", "table");
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            Console.WriteLine(GetFreeSpace(dirInfo.Root.Name));
            if(!dirInfo.Exists)
            {
                MessageBox.Show("报告储存路径不存在，请进入系统设置更改路径", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (GetFreeSpace(dirInfo.Root.Name) < 5000000000)
            {
                MessageBox.Show("报告储存磁盘空间不足5G，请进入系统设置更改路径", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;

        }
        private static ulong GetFreeSpace(string driveDirectoryName)
        {
            ulong freefreeBytesAvailable = 0;

            DriveInfo drive = new DriveInfo(driveDirectoryName);

            freefreeBytesAvailable = (ulong)drive.AvailableFreeSpace;

            return freefreeBytesAvailable;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;//当透明变为不透明
            if (this.Opacity >= 1)//当完全不透明时再由不透明变为透明
            {
                this.timer1.Stop();
                if (!CheckTablePath() || !CheckDataPath())
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button5.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button5.Enabled = true;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewSheet form = new NewSheet();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RecordInfo form = new RecordInfo();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MyPassword form = new MyPassword();
            form.ShowDialog();

            if (!CheckTablePath() || !CheckDataPath())
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button5.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button5.Enabled = true;
            }
            label1.Text = ini.ReadValue("Setting", "mainTitle");
            label2.Text = ini.ReadValue("Setting", "subTitle");
            pictureBox1.ImageLocation = ini.ReadValue("Setting", "ico");
            this.BackgroundImage = Image.FromFile(ini.ReadValue("Setting", "backImage"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // this.Dispose();
            timer2.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DoctorsInfo form = new DoctorsInfo();
            form.ShowDialog();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.05;
            }
            else
            {
                Application.Exit();
            }
        }

        private void buttonMouseEnter(object sender, EventArgs e)
        {
            Button s = (Button)sender;
            s.FlatAppearance.BorderSize = 1;
        }

        private void buttonMouseLeave(object sender, EventArgs e)
        {
            Button s = (Button)sender;
            s.FlatAppearance.BorderSize = 0;
        }

        private void load_Shown(object sender, EventArgs e)
        {
            this.label1.Focus();
        }

        /**
         * 每次启动程序的时候首先验证签名
         **/
        private void verifySignature()
        {
            if (!File.Exists("signature.txt"))
            {
                LockClient lockClient = new LockClient();
                lockClient.ShowDialog();
            }
            else
            {
                byte[] signature;
                using (StreamReader sr = File.OpenText("signature.txt"))
                {
                    try
                    {
                        signature = Convert.FromBase64String(sr.ReadLine());
                    }
                    catch (Exception e)
                    {
                        signature = new byte[64];
                    }
                }
                ECDsaCng dsa = LockClient.getECDsaCng(); 
                /**@function 防止秘钥被人更改后位数不对而程序崩溃的情况出现**/
                bool signatureLength = true;
                try
                {
                    signatureLength = dsa.VerifyData(MachineID.ComputeEasyMachineID(), signature);
                }
                catch (Exception e)
                {
                    signatureLength = false;
                }
                /**@function 防止秘钥被人更改后位数不对而程序崩溃的情况出现**/
                if (signatureLength == false)
                {
                    MessageBox.Show("您的密钥验证失败，请检查是否更改机器或设备后重新验证.","视频采集系统");
                    LockClient lockClient = new LockClient();
                    lockClient.ShowDialog();
                }
                dsa.Clear();
            }
        }

        /**
         * 每次启动程序的时候连接数据库
         **/
        private void connectDB()
        {
            Login login = new Login();
            login.ShowDialog();
        }

        
    }
}
