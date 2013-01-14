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

namespace login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newName = "Case05_4.Properties.Settings.病历信息ConnectionString";
            string newConString = "Data Source=localhost;Initial Catalog=" + comboBox1.Text.Trim() + ";User ID=" + comboBox1.Text.Trim() + ";Password=" + textBox1.Text.Trim() + ";";
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
            ProcessStartInfo startInfo = new ProcessStartInfo("Case05_4.exe");
            Process.Start(startInfo);

            this.Dispose();
        }
    }
}
