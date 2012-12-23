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
    public partial class table : Form
    {
        public table(string path)
        {
            InitializeComponent();
            pictureBox1.ImageLocation = path;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
