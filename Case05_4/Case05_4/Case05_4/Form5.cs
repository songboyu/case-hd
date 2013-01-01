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
    public partial class Form5 : Form
    {
        ImageList imagelist;
        public Form5()
        {
            InitializeComponent();
        }
        private bool validaing(TextBox textbox, int length, string controlName)
        {
            bool result = false;
            if (textbox.TextLength == 0)
            {
                errorProvider1.SetError(textbox, "请输入" + controlName + "内容！");
                textbox.SelectAll();
                textbox.Focus();

            }
            else if (textbox.TextLength > length)
            {
                errorProvider1.SetError(textbox, "请输入小于" + length.ToString() + "个字符的" + controlName + "！");
                textbox.SelectAll();
                textbox.Focus();
            }
            else
            {
                errorProvider1.SetError(textbox, "");
                result = true;
            }
            return result;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validaing(textBox1, 50, "姓名") == false || validaing(textBox3, 50, "年龄") == false)
            {
                MessageBox.Show("病历信息填写有误！", "出错提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Form2 f = new Form2(textBox1.Text);
            if (f.ShowDialog() == DialogResult.Yes)
            {
                imagelist = f.getPath();
                this.button2.Enabled = true;
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (validaing(textBox1, 50, "姓名") == false || validaing(textBox3, 50, "年龄") == false)
            {
                MessageBox.Show("病历信息填写有误！", "出错提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataRowView SelectedRowView = (DataRowView)this.infoBindingSource.Current;
            病历信息DataSet.infoRow selectedRow = (病历信息DataSet.infoRow)SelectedRowView.Row;
            selectedRow.Deleted = 0;
            this.Validate();
            this.infoBindingSource.EndEdit();

            Form4 form = new Form4(this.infoBindingSource,imagelist);
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (validaing(textBox1, 50, "姓名") == false || validaing(textBox3, 50, "年龄") == false)
            {
                MessageBox.Show("病历信息填写有误！", "出错提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                DataRowView SelectedRowView = (DataRowView)this.infoBindingSource.Current;
                病历信息DataSet.infoRow selectedRow = (病历信息DataSet.infoRow)SelectedRowView.Row;
                selectedRow.Deleted = 0;
                selectedRow.tableNum = 0;

                this.Validate();
                this.infoBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.病历信息DataSet);
                MessageBox.Show("保存成功！", "出错提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(e.KeyChar.ToString());

            if (!char.IsDigit(e.KeyChar) || array.LongLength == 2) e.Handled = true;

            if (e.KeyChar == '\b' || e.KeyChar == '.') e.Handled = false;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“病历信息DataSet.doctor”中。您可以根据需要移动或删除它。
            this.doctorTableAdapter.Fill(this.病历信息DataSet.doctor);
            this.infoTableAdapter.Fill(this.病历信息DataSet.info);
            this.infoBindingSource.AddNew();

            comboBox2.DataSource = this.病历信息DataSet.doctor.Copy();
            comboBox2.DisplayMember = "name";
            //comboBox2.SelectedIndex = 0;

            comboBox3.DataSource = this.病历信息DataSet.doctor.Copy();
            comboBox3.DisplayMember = "name";
            //comboBox3.SelectedIndex = 0;
        }

        private void Form5_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
            DateTime dt = DateTime.Now;
            String date = dt.ToString();
            textBox21.Text = date;
            comboBox1.Text = "男";
            textBox8.Text = "" + (this.病历信息DataSet.info.Rows.Count + 1);
            comboBox10.Text = "无";
        }
    }
}
