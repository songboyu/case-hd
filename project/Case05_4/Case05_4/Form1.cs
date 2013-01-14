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
            Form4 info = new Form4();
            info.Show();
            
        }

        private void infoDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow i = infoDataGridView.CurrentRow;
            DataRowView SelectedRowView = (DataRowView)this.infoBindingSource.Current;
            病历信息DataSet.infoRow selectedRow = (病历信息DataSet.infoRow)SelectedRowView.Row;

            table form = new table(selectedRow.table);
            form.Show();
        }

        private void textBox_姓名_TextChanged(object sender, EventArgs e)
        {
            this.infoTableAdapter.FillByInfo(this.DataSet.info, textBox_姓名.Text, comboBox_申请科室.Text, comboBox_检查医师.Text);
        }

        private void textBox_检查号_TextChanged(object sender, EventArgs e)
        {
            this.infoTableAdapter.FillBy检查号(this.DataSet.info, textBox_检查号.Text);
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
       
        private void button2_Click(object sender, EventArgs e)
        {
            textBox_检查号.Text = "";
            textBox_检查号.Focus();

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

        private void button3_Click(object sender, EventArgs e)
        {
            DataRowView SelectedRowView = (DataRowView)this.infoBindingSource.Current;
            病历信息DataSet.infoRow selectedRow = (病历信息DataSet.infoRow)SelectedRowView.Row;

            镜检录像与图片 form = new 镜检录像与图片(selectedRow.path);
            form.Show();
        }

       
    }
}
