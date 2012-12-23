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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '病历信息DataSet1.doctor' table. You can move, or remove it, as needed.
            this.doctorTableAdapter.Fill(this.病历信息DataSet1.doctor);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.doctorTableAdapter.Update(this.病历信息DataSet1.doctor);
            this.Close();
        }
    }
}
