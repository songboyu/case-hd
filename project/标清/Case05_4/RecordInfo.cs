using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace Case05_4
{
    public partial class RecordInfo : Form
    {
        public RecordInfo()
        {
            InitializeComponent();

            skinEngine1.SkinFile = "Emerald.ssk";
            skinEngine1.SkinAllForm = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '病历信息DataSet1.info' table. You can move, or remove it, as needed.
            
            this.infoTableAdapter.Fill(this.DataSet.info);
            dateTimePicker_起始.ResetText();
            dateTimePicker_终止.ResetText();

            DataGridViewColumn sortColumn = infoDataGridView.Columns[6];
            ListSortDirection direction =ListSortDirection.Descending;
            infoDataGridView.Sort(sortColumn,direction);
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
            NewSheet info = new NewSheet();
            info.Show();
            
        }

        private void infoDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow i = infoDataGridView.CurrentRow;
            DataRowView SelectedRowView = (DataRowView)this.infoBindingSource.Current;
            病历信息DataSet.infoRow selectedRow = (病历信息DataSet.infoRow)SelectedRowView.Row;
            if (File.Exists(selectedRow._Table))
            {
                //存在文件  
                MyImage form = new MyImage(selectedRow._Table);
                form.Show();
            }
            else
            {
                MessageBox.Show("该病例信息已经被删除或转移，无法打开", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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
                dateTimePicker_起始.Value,
                dateTimePicker_终止.Value.Date.AddDays(1));
        }

        private void dateTimePicker_终止_CloseUp(object sender, EventArgs e)
        {
            this.infoTableAdapter.FillByTime(this.DataSet.info,
                dateTimePicker_起始.Value,
                dateTimePicker_终止.Value.Date.AddDays(1));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView SelectedRowView = (DataRowView)this.infoBindingSource.Current;
                病历信息DataSet.infoRow selectedRow = (病历信息DataSet.infoRow)SelectedRowView.Row;

                DirectoryInfo mydir = new DirectoryInfo(selectedRow.Path);
                FileInfo fi = (FileInfo)mydir.GetFileSystemInfos()[0];
                string name = fi.FullName;
                //MessageBox.Show( name);
                Process.Start("Explorer.exe", "/select," + name);
            }
            catch (Exception ex) {
                MessageBox.Show("未找到镜检资料");
            }
        }
        [DllImport("USER32.DLL")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);  //导入模拟键盘的方法


        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            keybd_event(0x9, 0, 0, 0);

            this.infoTableAdapter.Fill(this.DataSet.info);
            if (e.TabPage == tabPage1)
            {
                textBox_姓名.Focus();

                textBox_检查号.Text = "";
                dateTimePicker_起始.ResetText();
                dateTimePicker_终止.ResetText();
               
            }
            if (e.TabPage == tabPage2)
            {
                textBox_检查号.Focus();

                textBox_姓名.Text = "";
                comboBox_申请科室.Text = "";
                comboBox_检查医师.Text = "";
                dateTimePicker_起始.ResetText();
                dateTimePicker_终止.ResetText();
            }
            if (e.TabPage == tabPage3)
            {
                textBox_姓名.Text = "";
                comboBox_申请科室.Text = "";
                comboBox_检查医师.Text = "";
                textBox_检查号.Text = "";
            }
        }

        private void button_返回_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
