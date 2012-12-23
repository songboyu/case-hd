using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Case05_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '病历信息DataSet1.info' table. You can move, or remove it, as needed.
            
            this.infoTableAdapter.Fill(this.DataSet.info);
            dateTimePicker_起始.ResetText();
            dateTimePicker_终止.ResetText();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            textBox_姓名.Focus();
        }
       
        private void button_删除病历_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要删除病例记录?", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //this.DataSet.info.Rows[this.infoDataGridView.CurrentRow.Index].Delete();
                //this.infoBindingSource.RemoveCurrent();
                //this.infoTableAdapter.Update(this.DataSet);
                DataRowView SelectedRowView = (DataRowView)this.infoBindingSource.Current;
                病历信息DataSet.infoRow selectedRow = (病历信息DataSet.infoRow)SelectedRowView.Row;
                selectedRow.Deleted = 1;
                this.infoTableAdapter.Update(this.DataSet);
                
            }
        }

        private void button_清空_Click(object sender, EventArgs e)
        {
            textBox_姓名.Text = "";
            comboBox_申请科室.Text = "";
            comboBox_检查医师.Text = "";
          
            textBox_姓名.Focus();
            
        }

        private void button_还原_Click(object sender, EventArgs e)
        {
            dateTimePicker_起始.ResetText();
            dateTimePicker_终止.ResetText();
            this.infoTableAdapter.Fill(this.DataSet.info);
        }

        private void button_新建病历_Click(object sender, EventArgs e)
        {
            Form5 info = new Form5();
            info.Show();
            
        }

        private void infoDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow i = infoDataGridView.CurrentRow;
            DataRowView SelectedRowView = (DataRowView)this.infoBindingSource.Current;
            病历信息DataSet.infoRow selectedRow = (病历信息DataSet.infoRow)SelectedRowView.Row;
            
            Form3 f = new Form3(selectedRow.姓名);
            f.Show();
        }

        private void textBox_姓名_TextChanged(object sender, EventArgs e)
        {
            this.infoTableAdapter.FillByInfo(this.DataSet.info, textBox_姓名.Text, comboBox_申请科室.Text, comboBox_检查医师.Text);
        }

        private void textBox_病历号_TextChanged(object sender, EventArgs e)
        {
            if (textBox_病历号.Text=="")
                this.infoTableAdapter.Fill(this.DataSet.info);
            else
                this.infoTableAdapter.FillBy病历号(this.DataSet.info,Int32.Parse( textBox_病历号.Text));
        }

        private void comboBox_申请科室_TextChanged(object sender, EventArgs e)
        {
            this.infoTableAdapter.FillByInfo(this.DataSet.info, textBox_姓名.Text, comboBox_申请科室.Text, comboBox_检查医师.Text);
        }

        private void comboBox_检查医师_TextChanged(object sender, EventArgs e)
        {
            this.infoTableAdapter.FillByInfo(this.DataSet.info, textBox_姓名.Text, comboBox_申请科室.Text, comboBox_检查医师.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.infoTableAdapter.Fill(this.DataSet.info);
        }

        private void textBox_病历号_KeyPress(object sender, KeyPressEventArgs e)
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(e.KeyChar.ToString());

            if (!char.IsDigit(e.KeyChar) || array.LongLength == 2)
                e.Handled = true;

            if (e.KeyChar == '\b' || e.KeyChar == '.')
                e.Handled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_病历号.Text = "";
            textBox_病历号.Focus();

        }

        private void dateTimePicker_起始_CloseUp(object sender, EventArgs e)
        {
            this.infoTableAdapter.FillByTime(this.DataSet.info,
                dateTimePicker_起始.Value.AddDays(-1),
                dateTimePicker_终止.Value);
        }

        private void dateTimePicker_终止_CloseUp(object sender, EventArgs e)
        {
            this.infoTableAdapter.FillByTime(this.DataSet.info,
                dateTimePicker_起始.Value.AddDays(-1),
                dateTimePicker_终止.Value);
        }
    }
}
