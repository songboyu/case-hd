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
        string Current = AppDomain.CurrentDomain.BaseDirectory;//获取当前根目录
        ini ini;
        public Form5()
        {
            InitializeComponent();
            ini = new ini(Current + "\\config.ini");
            textBox1.Text = ini.ReadValue("Setting", "table");
            textBox2.Text = ini.ReadValue("Setting", "data");
            textBox3.Text = ini.ReadValue("Setting", "mainTitle");
            textBox4.Text = ini.ReadValue("Setting", "subTitle");
            textBox5.Text = ini.ReadValue("Setting", "ico");

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
            //string stemp = ini.ReadValue("Setting", "key2");
            ini.Writue("Setting", "table", textBox1.Text);
            ini.Writue("Setting", "data", textBox2.Text);
            ini.Writue("Setting", "mainTitle", textBox3.Text);
            ini.Writue("Setting", "subTitle", textBox4.Text);
            ini.Writue("Setting", "ico", textBox5.Text);

            this.Close();
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
            Form4 form = new Form4(true);
            form.ShowDialog();
        }
    }
}
