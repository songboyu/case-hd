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

namespace Case05_4
{
    public partial class Form4 : Form
    {
        string path;
        string fileName;
        public Form4(BindingSource s)
        {
            InitializeComponent();
            //textBox2.DataBindings.Add("Text", s, "就诊时间", true);
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
            comboBox4.DataBindings.Add("Text", s, "申请医师", true);
            comboBox5.DataBindings.Add("Text", s, "检查医师", true);
            comboBox6.DataBindings.Add("Text", s, "检查医师", true);
            DataRowView SelectedRowView = (DataRowView)s.Current;
            病历信息DataSet.infoRow selectedRow = (病历信息DataSet.infoRow)SelectedRowView.Row;
            try
            {
                pictureBox1.ImageLocation = selectedRow.path1;
            }
            catch(Exception e){}
            try
            {
                pictureBox2.ImageLocation = selectedRow.path2;
            }
            catch (Exception e) { }
            try
            {
                pictureBox3.ImageLocation = selectedRow.path3;
            }
            catch (Exception e) { }
            try
            {
                pictureBox4.ImageLocation = selectedRow.path4;
            }
            catch (Exception e) { }
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                               this.panel1.ClientRectangle,
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
            Bitmap g = GetPanel(panel1);
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
           
            Bitmap outBmp = GetPanel(this.panel1);
            e.Graphics.DrawImage(outBmp, 0, 0);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void 取消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
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

        private void toolStripButton2_Click(object sender, EventArgs e)
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



        private void toolStripButton3_Click(object sender, EventArgs e)
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

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                this.printDocument1.Print();
                this.savePic();
            }
            catch (Exception error)
            {//打印出错处理
                MessageBox.Show("打印文件发生错误：   " + error.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
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
                this.savePic();
            }
            catch (Exception error)
            {//打印出错处理
                MessageBox.Show("打印文件发生错误：   " + error.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
