using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Case05_4
{
    public partial class ChangePassWord : Form
    {
        public ChangePassWord()
        {
            InitializeComponent();

            skinEngine1.SkinFile = "Emerald.ssk";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCeEngine engine = null;
            if (textBox2.Text.Equals(textBox3.Text))
            {
                try
                {
                    engine = new SqlCeEngine("Data Source = 病历信息.sdf; Password =" + textBox1.Text + ";");

                    engine.Compact("Data Source=病历信息.sdf; Password = " + textBox2.Text + ";");
                    MessageBox.Show("密码修改成功，请重新启动程序！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("原密码不正确，请重新输入！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("两次密码输入不同，请重新输入！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox1.Focus();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
