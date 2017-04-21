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
    public partial class MyPassword : Form
    {
        public MyPassword()
        {
            InitializeComponent();

            skinEngine1.SkinFile = "Emerald.ssk";
            skinEngine1.SkinAllForm = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "963157117")
            {
                MySettings form = new MySettings();
                this.Close();
                form.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("密码错误");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MyPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
