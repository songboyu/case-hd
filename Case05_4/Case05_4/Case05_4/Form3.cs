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
        List<string> p = new List<string>();
        ImageList imagelist;
        public Form3(string name)
        {
            InitializeComponent();
            this.infoTableAdapter.FillBy姓名(this.病历信息DataSet.info, name);
            DataRowView SelectedRowView = (DataRowView)this.infoBindingSource.Current;
            病历信息DataSet.infoRow selectedRow = (病历信息DataSet.infoRow)SelectedRowView.Row;
            try
            {
                p.Add(selectedRow.table1);
                p.Add(selectedRow.table2);
                p.Add(selectedRow.table3);
                p.Add(selectedRow.table4);
                p.Add(selectedRow.table5);
                p.Add(selectedRow.table6);
                p.Add(selectedRow.table7);
                p.Add(selectedRow.table8);
                p.Add(selectedRow.table9);
                p.Add(selectedRow.table10);
            }
            catch (Exception e) { }

            for (int i = 0; i < selectedRow.tableNum; i++)
            {
                imageList1.Images.Add(Image.FromFile(p[i]));

                int sign1 = p[i].LastIndexOf("\\");
                int sign2 = p[i].LastIndexOf(".");
                String Name = p[i].Substring(sign1 + 1, sign2 - sign1 - 1);

                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;
                lvi.Text = Name;
                lvi.ToolTipText = Name;
                this.listView1.Items.Add(lvi);

            }
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
                this.infoTableAdapter.Update(this.病历信息DataSet.info);
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
                this.infoTableAdapter.Update(this.病历信息DataSet.info);
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
                imagelist = f.getPath();
                button5.Enabled = true;
            }
           // this.tableAdapterManager.UpdateAll(this.病历信息DataSet);
            this.infoTableAdapter.Update(this.病历信息DataSet.info);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataRowView SelectedRowView = (DataRowView)this.infoBindingSource.Current;
            病历信息DataSet.infoRow selectedRow = (病历信息DataSet.infoRow)SelectedRowView.Row;

            Form4 form = new Form4(this.infoBindingSource,imagelist);
            if (form.ShowDialog() == DialogResult.Yes)
            {
                
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
                this.infoTableAdapter.Update(this.病历信息DataSet.info);
            
            }
            
        }

      
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int i = listView1.SelectedItems[0].Index;
            table form = new table(p[i]);
            form.Show();
        }
       
        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“病历信息DataSet.doctor”中。您可以根据需要移动或删除它。
            this.doctorTableAdapter.Fill(this.病历信息DataSet.doctor);

            申请医师ComboBox.DataSource = this.病历信息DataSet.doctor.Copy();
            申请医师ComboBox.DisplayMember = "name";
            申请医师ComboBox.DataBindings.Add("Text", this.infoBindingSource, "申请医师", true);
          
            检查医师ComboBox.DataSource = this.病历信息DataSet.doctor.Copy();
            检查医师ComboBox.DisplayMember = "name";
            检查医师ComboBox.DataBindings.Add("Text", this.infoBindingSource, "检查医师", true);
        }

    }
}
