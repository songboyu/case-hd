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
    public partial class load : Form
    {
       
        public load()
        {
            
            InitializeComponent();
            // TODO: 这行代码将数据加载到表“病历信息DataSet.info”中。您可以根据需要移动或删除它。
            try
            {
                this.infoTableAdapter.Fill(this.病历信息DataSet.info);
            }
            catch (Exception ex)
            {
                MessageBox.Show("密码输入错误！！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }

        private void load_Load(object sender, EventArgs e)
        {
            
            this.Opacity = 0;
            this.timer1.Interval = 100;
            this.timer1.Enabled = true;
            this.timer1.Start();
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
            Form5 info = new Form5();
            info.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
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

        private void button1_MouseEnter(object sender, EventArgs e)
        {
           
            this.button1.FlatAppearance.BorderSize = 1;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.button1.FlatAppearance.BorderSize = 0;
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {

            this.button2.FlatAppearance.BorderSize = 1;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.button2.FlatAppearance.BorderSize = 0;
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {

            this.button3.FlatAppearance.BorderSize = 1;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            this.button3.FlatAppearance.BorderSize = 0;
        }
        private void button4_MouseEnter(object sender, EventArgs e)
        {

            this.button4.FlatAppearance.BorderSize = 1;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.button4.FlatAppearance.BorderSize = 0;
        }

        private void infoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.infoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.病历信息DataSet);

        }

        private void infoBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.infoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.病历信息DataSet);

        }
    }
}
