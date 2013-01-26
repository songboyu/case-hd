using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Case05_4
{
    public partial class table : Form
    {
        public table(string path , int sign = 0)
        {
            InitializeComponent();
            this.panel1.BackgroundImage = Image.FromFile(path);
            //pictureBox1.ImageLocation = path;
            if (sign == 1)
            {
                this.WindowState = FormWindowState.Maximized;
                this.panel1.Dock = DockStyle.Fill;
                this.button1.Location = new Point(Screen.PrimaryScreen.Bounds.Width-this.button1.Width,0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void table_Shown(object sender, EventArgs e)
        {
            this.panel1.Focus();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.LightGray;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Gray;
        }

    }
}
