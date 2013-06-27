using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using System.Configuration;

namespace Case05_4
{
    public partial class Login : Form
    {
        private string Current = AppDomain.CurrentDomain.BaseDirectory;
        
        public Login()
        {
            InitializeComponent();

            ini ini = new ini(Current + "\\config.ini");
            skinEngine1.SkinFile = "Emerald.ssk";
            skinEngine1.SkinAllForm = false;
            pictureBox1.ImageLocation = ini.ReadValue("Setting", "ico");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newName = "Case05_4.Properties.Settings.病历信息ConnectionString";
            string newConString = @"Data Source=|DataDirectory|\病历信息.sdf;Password=" + textBox1.Text;
            string nowpath = "Case05_4.exe.config";
            try
            {
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
            ConfigurationManager.RefreshSection("connectionStrings");
            this.Dispose();
            }
            catch (Exception ex) { MessageBox.Show("抱歉，密码输入错误，请重试！"); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose(); ;
        }
    }
}
