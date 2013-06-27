using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Case05_4
{
    public partial class MyImage : Form
    {
        private string path;
        public MyImage(string ImagePath , int sign = 0)
        {
            InitializeComponent();
            path = ImagePath;
            this.panel1.BackgroundImage = Image.FromFile(path);
            //pictureBox1.ImageLocation = path;
            if (sign == 1)
            {
                this.WindowState = FormWindowState.Maximized;
                this.panel1.Dock = DockStyle.Fill;
                this.button2.Visible = false;
                this.button1.Location = new Point(Screen.PrimaryScreen.Bounds.Width-this.button1.Width,0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void table_Shown(object sender, EventArgs e)
        {
            this.panel1.Focus();
        }

        private void MyMouseEnter(object sender, EventArgs e)
        {
            Control s = (Control)sender;
            s.ForeColor = Color.LightGray;
        }

        private void MyMouseLeave(object sender, EventArgs e)
        {
            Control s = (Control)sender;
            s.ForeColor = Color.Gray;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Image p = Image.FromFile(path);
            //e.Graphics.DrawImage(p, 0, 0);
            int dot = path.IndexOf(".");
            string xmlPath = path.Substring(0,dot)+".bak";
            //MessageBox.Show(xmlPath);
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);



            XmlNodeList list = doc.GetElementsByTagName("panelEx1")[0].ChildNodes;
            // MessageBox.Show(list.Count+"");
            for (int i = 0; i < list.Count; i++)
            {
                Font f;
                string text = list[i].Attributes[0].Value;
                int x = int.Parse(list[i].Attributes[2].Value);
                int y = int.Parse(list[i].Attributes[1].Value);

                /*if (list[i].Attributes[0].Value != "")
                    text = list[i].Attributes[0].Value;
                else
                    text = panelEx1.Controls[i].Text.ToString();*/


                if (list[i].Name == "label1")
                    f = new System.Drawing.Font("宋体", (float)21.75, FontStyle.Regular);
                else if (list[i].Name == "label2")
                    f = new System.Drawing.Font("宋体", 15, FontStyle.Regular);
                else
                    f = new System.Drawing.Font("宋体", 10, FontStyle.Regular);

                e.Graphics.DrawString(text, f, Brushes.Black, x, y);

            }
            for (int i = 1; i < 6; i++)
            {
                string picBox = "pictureBox" + i;
                Image img = Image.FromFile(doc.GetElementsByTagName(picBox)[0].Attributes[5].Value);
                e.Graphics.DrawImage(img,
                    int.Parse(doc.GetElementsByTagName(picBox)[0].Attributes[2].Value),
                    int.Parse(doc.GetElementsByTagName(picBox)[0].Attributes[1].Value),
                    int.Parse(doc.GetElementsByTagName(picBox)[0].Attributes[3].Value),
                    int.Parse(doc.GetElementsByTagName(picBox)[0].Attributes[4].Value));
            }

        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
