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
    public partial class Form3 : Form
    {
        public Form3(string name)
        {
            InitializeComponent();
            this.infoTableAdapter.FillBy姓名(this.病历信息DataSet.info, name);
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
            姓名TextBox.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要修改该病例记录?", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Validate();
                this.infoBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.病历信息DataSet);
                this.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要删除病例记录?", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                DataRowView SelectedRowView = (DataRowView)this.infoBindingSource.Current;
                病历信息DataSet.infoRow selectedRow = (病历信息DataSet.infoRow)SelectedRowView.Row;
                selectedRow.Deleted = 1;
                this.tableAdapterManager.UpdateAll(this.病历信息DataSet);
                this.Dispose();
            }
        }

        private void 年龄TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(e.KeyChar.ToString());
            
            if (!char.IsDigit(e.KeyChar) || array.LongLength == 2) 
                e.Handled = true;
            
            if (e.KeyChar == '\b' || e.KeyChar == '.')
                e.Handled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(姓名TextBox.Text);
            if (f.ShowDialog() == DialogResult.Yes)
            {
                DataRowView SelectedRowView = (DataRowView)this.infoBindingSource.Current;
                病历信息DataSet.infoRow selectedRow = (病历信息DataSet.infoRow)SelectedRowView.Row;
                selectedRow.path1 = f.PATH1;
                selectedRow.path2 = f.PATH2;
                selectedRow.path3 = f.PATH3;
                selectedRow.path4 = f.PATH4;
            }
           // this.tableAdapterManager.UpdateAll(this.病历信息DataSet);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataRowView SelectedRowView = (DataRowView)this.infoBindingSource.Current;
            病历信息DataSet.infoRow selectedRow = (病历信息DataSet.infoRow)SelectedRowView.Row;

            Form4 form = new Form4(this.infoBindingSource);
            form.ShowDialog();

            int num = selectedRow.tableNum % 10;
            switch (num)
            {
                case 0:
                    selectedRow.table1 = form.tablePATH;
                    break;
                case 1:
                    selectedRow.table2 = form.tablePATH;
                    break;
                case 2:
                    selectedRow.table3 = form.tablePATH;
                    break;
                case 3:
                    selectedRow.table4 = form.tablePATH;
                    break;
                case 4:
                    selectedRow.table5 = form.tablePATH;
                    break;
                case 5:
                    selectedRow.table6 = form.tablePATH;
                    break;
                case 6:
                    selectedRow.table7 = form.tablePATH;
                    break;
                case 7:
                    selectedRow.table8 = form.tablePATH;
                    break;
                case 8:
                    selectedRow.table9 = form.tablePATH;
                    break;
                case 9:
                    selectedRow.table10 = form.tablePATH;
                    break;
                default:
                    break;
            }
            selectedRow.tableNum++;
            
            this.tableAdapterManager.UpdateAll(this.病历信息DataSet);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tableView view = new tableView(this.infoBindingSource);
            view.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '病历信息DataSet1.doctor' table. You can move, or remove it, as needed.
            this.doctorTableAdapter.Fill(this.病历信息DataSet1.doctor);

        }

    }
}
