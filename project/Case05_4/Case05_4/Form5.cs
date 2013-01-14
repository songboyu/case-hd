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
    public partial class Form5 : Form
    {
        string Current = Directory.GetCurrentDirectory();//获取当前根目录
        
        public Form5()
        {
            InitializeComponent();

            ini ini = new ini(Current + "\\config.ini");
            textBox1.Text = ini.ReadValue("Setting", "table");
            textBox2.Text = ini.ReadValue("Setting", "data");
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
            ini ini = new ini(Current + "\\config.ini");
            //string stemp = ini.ReadValue("Setting", "key2");
            ini.Writue("Setting", "table", textBox1.Text);
            ini.Writue("Setting", "data", textBox2.Text);

            this.Close();
            
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
