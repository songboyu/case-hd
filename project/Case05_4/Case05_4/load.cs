using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Case05_4
{
    public partial class load : Form
    {

        private string Current = AppDomain.CurrentDomain.BaseDirectory;
        ini ini;
        public load()
        {
            InitializeComponent();
           
            ini = new ini(Current + "\\config.ini");
            label1.Text = ini.ReadValue("Setting", "mainTitle");
            label2.Text = ini.ReadValue("Setting", "subTitle");
            pictureBox1.ImageLocation = ini.ReadValue("Setting", "ico");

            try
            {
                this.infoTableAdapter.Fill(this.病历信息DataSet.info);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }

        private void load_Load(object sender, EventArgs e)
        {
            
            this.Opacity = 0;
            this.timer1.Interval = 100;
            this.timer1.Enabled = true;
            this.timer1.Start();

            string newName = "Case05_4.Properties.Settings.病历信息ConnectionString";
            string newConString = "Data Source=localhost;Initial Catalog= ;User ID= ;Password=  ;";
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;//当透明变为不透明
            if (this.Opacity >= 1)//当完全不透明时再由不透明变为透明
            {
                this.timer1.Stop();
              
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7();
            form.ShowDialog();
            
            label1.Text = ini.ReadValue("Setting", "mainTitle");
            label2.Text = ini.ReadValue("Setting", "subTitle");
            pictureBox1.ImageLocation = ini.ReadValue("Setting", "ico");
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // this.Dispose();
            timer2.Start();
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
    }
}
