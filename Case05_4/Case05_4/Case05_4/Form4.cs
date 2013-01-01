using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Xml;

namespace Case05_4
{
    public partial class Form4 : Form
    {
        private string path;
        private string imagePath;
        private string fileName;
        private int count = 0;
        private int delete = 0;
        private ImageList list;
        private Boolean edit = false;
        private Boolean showList = true;
       
        public Form4(BindingSource s,ImageList imagelist)
        {
            InitializeComponent();
            list = imagelist;
            this.doctorTableAdapter.Fill(this.病历信息DataSet.doctor);
            listView1.LargeImageList = imagelist;
            for (int i = 0; i < imagelist.Images.Count; i++)
            {
                listView1.Items.Add("", i);
                listView1.Items[i].ImageIndex = i;
            }


            DateTime dt = DateTime.Now;
            String date = dt.ToString();
            textBox2.Text = date;
            textBox3.DataBindings.Add("Text", s, "姓名", true);
            comboBox1.DataBindings.Add("Text", s, "性别", true);
            textBox4.DataBindings.Add("Text", s, "年龄", true);
            comboBox3.DataBindings.Add("Text", s, "申请科室", true);
            textBox6.DataBindings.Add("Text", s, "病历号", true);
            textBox7.DataBindings.Add("Text", s, "住院号", true);
            textBox8.DataBindings.Add("Text", s, "病区号", true);
            textBox9.DataBindings.Add("Text", s, "床位号", true);
            textBox11.DataBindings.Add("Text", s, "临床诊断", true);

            comboBox4.DataSource = this.病历信息DataSet.doctor.Copy();
            comboBox4.DisplayMember = "name";
            comboBox4.DataBindings.Add("Text", s, "申请医师", true);

            comboBox5.DataSource = this.病历信息DataSet.doctor.Copy();
            comboBox5.DisplayMember = "name";
            comboBox5.DataBindings.Add("Text", s, "检查医师", true);

            comboBox6.DataSource = this.病历信息DataSet.doctor.Copy();
            comboBox6.DisplayMember = "name";
            comboBox6.DataBindings.Add("Text", s, "检查医师", true);
        }
        public Form4(Boolean E = false)
        {
            InitializeComponent();
            
            edit = E;
        }

        private void panelEx1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                               this.panelEx1.ClientRectangle,
                               Color.Red,         //left
                               5,
                               ButtonBorderStyle.Solid,
                               Color.Red,         //top
                               5,
                               ButtonBorderStyle.Solid,
                               Color.Red,        //right
                               5,
                               ButtonBorderStyle.Solid,
                               Color.Red,        //bottom
                               5,
                               ButtonBorderStyle.Solid);
        }
        public Bitmap GetPanel(Panel p_Panel)
        {
            Bitmap _BitMap = new Bitmap(p_Panel.Width, p_Panel.Height);

            p_Panel.DrawToBitmap(_BitMap, new Rectangle(0, 0, _BitMap.Width, _BitMap.Height));

            int newWidth=0;
            int newHeight=0;
            //你自定义图的长宽如 
            if (this.pageSetupDialog1.PageSettings.PaperSize.PaperName.Equals("A4"))
            {
                newWidth = 794;
                newHeight = 1123;
            }
            Bitmap newBmps = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(newBmps);
            g.DrawImage(_BitMap, 0, 0, newWidth, newHeight);

            return newBmps;
        }
        public string tablePATH
        {
            get { return fileName; }
        }
        private void savePic()
        {
            Bitmap g = GetPanel(panelEx1);
            path = System.Environment.CurrentDirectory+"\\backup\\" + textBox3.Text;

            if (!Directory.Exists(path))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(path); //新建文件夹  
            }
            fileName = path + "\\" + textBox3.Text + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            g.Save(fileName);
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
            Bitmap outBmp = GetPanel(this.panelEx1);
            e.Graphics.DrawImage(outBmp, 0, 0);
        }

        private void 取消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 打印设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.UseEXDialog = true;

            //显示打印窗口
            if (this.printDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    this.printDocument1.Print();
                    this.savePic();
                }
                catch (Exception excep)
                {//显示打印出错消息
                    MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void 页面设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {//显示打印页面设置窗口
                this.pageSetupDialog1.ShowDialog();
            }
            catch (Exception excep)
            {//显示打印出错消息
                MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {//显示打印预览窗口
                this.printPreviewDialog1.ShowDialog();
            }
            catch (Exception excep)
            {
                //显示打印出错消息
                MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 打印ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                this.printDocument1.Print();
                this.DialogResult = DialogResult.Yes;
                this.savePic();
                this.Close();
            }
            catch (Exception error)
            {//打印出错处理
                MessageBox.Show("打印文件发生错误：   " + error.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1018, 780);
            if (edit == false)
            {
                panelEx1.InitMouseAndContolStyle(AppDomain.CurrentDomain.BaseDirectory + "App.xml");

            }
            if (edit == true)
            {
                panelEx1.InitMouseAndContolStyle(AppDomain.CurrentDomain.BaseDirectory + "App.xml",true);
            }
        }

        private void 截图预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showList == true)
            {
                this.listView1.Visible = false;
                this.Size = new Size(814, 780);
                showList = false;
            }
            else if (showList == false)
            {
                this.listView1.Visible = true;
                this.Size = new Size(1018, 780);
                showList = true;
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            int i = listView1.SelectedItems[0].Index;
            imagePath = list.Images.Keys[i];
            if( delete == 0 )
            {
                count = count % 4;
                switch (count)
                    { 
                        case 0:
                            pictureBox1.ImageLocation = imagePath;
                            break;
                        case 1:
                            pictureBox2.ImageLocation = imagePath;
                            break;
                        case 2:
                            pictureBox3.ImageLocation = imagePath;
                            break;
                        case 3:
                            pictureBox4.ImageLocation = imagePath;
                            break;
                        default:
                            break;
                    }
                count++;
                   
             }
            if (delete == 1)
            {
                pictureBox1.ImageLocation = imagePath;
                delete = 0;
            }
            if (delete == 2)
            {
                pictureBox2.ImageLocation = imagePath;
                delete = 0;
            }
            if (delete == 3)
            {
                pictureBox3.ImageLocation = imagePath;
                delete = 0;
            }
            if (delete == 4)
            {
                pictureBox4.ImageLocation = imagePath;
                delete = 0;
            }
          
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
                if (e.Button == MouseButtons.Right)
                {
                    pictureBox1.ImageLocation = "a.jpg";
                    delete = 1;
                }
            
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            
                if (e.Button == MouseButtons.Right)
                {
                    pictureBox2.ImageLocation = "a.jpg";
                    delete = 2;
                }
           
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
                if (e.Button == MouseButtons.Right)
                {
                    pictureBox3.ImageLocation = "a.jpg";
                    delete = 3;
                }
         
        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
              if (e.Button == MouseButtons.Right)
                {
                    pictureBox4.ImageLocation = "a.jpg";
                    delete = 4;
                }
            
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int i = listView1.SelectedItems[0].Index;
            table form = new table(list.Images.Keys[i], 1);
            form.Show();
        }
    }
}
