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
    public partial class ChangePwd : Form
    {
        public ChangePwd()
        {
            InitializeComponent();
            skinEngine1.SkinFile = "Emerald.ssk";
            skinEngine1.SkinAllForm = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(textBox3.Text))
            {
                string sql = "ALTER DATABASE PASSWORD " + textBox1.Text + " " + textBox2.Text;
                string connectionString = "Data Source=D:/病历信息.sdf;Password="+textBox1.Text;
                SqlCeConnection connectionObj = new SqlCeConnection(connectionString);  //建立连接对象
                connectionObj.Open();
                SqlCeCommand cmd = new SqlCeCommand(sql, connectionObj);
                cmd.ExecuteNonQuery();
                SqlCeEngine a = new SqlCeEngine();
                a.Compact(connectionString);
                connectionObj.Close();
                MessageBox.Show("密码修改成功", "视频采集系统");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("新密码前后输入不一致，请重新输入", "视频采集系统");
            }
        }
    }
}
