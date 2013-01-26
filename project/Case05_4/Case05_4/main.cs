﻿using System;
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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            try
            {
                this.infoTableAdapter.Fill(this.病历信息DataSet.info);
            }
            catch (Exception ex)
            {
                MessageBox.Show("登录失败！！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 info = new Form4();
            info.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

      
        private void main_Load(object sender, EventArgs e)
        {
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

        private void button6_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.Show();
        }
    }
}
