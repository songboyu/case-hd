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
    public partial class DoctorsInfo : Form
    {
        public DoctorsInfo()
        {
            InitializeComponent();

            skinEngine1.SkinFile = "Emerald.ssk";
            skinEngine1.SkinAllForm = false;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“病历信息DataSet.doctor”中。您可以根据需要移动或删除它。
            this.doctorTableAdapter.Fill(this.病历信息DataSet.doctor);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.doctorTableAdapter.Update(this.病历信息DataSet.doctor);
            this.Close();
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                DataRowView SelectedRowView = (DataRowView)this.doctorBindingSource.Current;
                病历信息DataSet.doctorRow selectedRow = (病历信息DataSet.doctorRow)SelectedRowView.Row;
            }
            catch (Exception ex)
            { 
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // this.病历信息DataSet.doctor.Rows[this.dataGridView1.CurrentRow.Index].Delete();
            try
            {
                this.doctorBindingSource.RemoveCurrent();
                //this.doctorTableAdapter.Update(病历信息DataSet.doctor);
            }
            catch (Exception ex) 
            { }
        }

        
    }
}
