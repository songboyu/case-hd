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
    public partial class tableView : Form
    {
        List<string> p = new List<string>();
        public tableView(BindingSource s)
        {
            InitializeComponent();

            DataRowView SelectedRowView = (DataRowView)s.Current;
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
                String name = p[i].Substring(sign1+1,sign2-sign1-1);

                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;
                lvi.Text = name;
                lvi.ToolTipText = name;
                this.listView1.Items.Add(lvi);

            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int i = listView1.SelectedItems[0].Index;
            table form = new table(p[i]);
            form.Show();
        }

    }
}
