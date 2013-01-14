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
using System.Data.SqlClient;

namespace Case05_4
{
    public partial class Form4 : Form
    {
        private string xmlPath = AppDomain.CurrentDomain.BaseDirectory + "App.xml";
        private string time = DateTime.Now.ToString("yyyyMMddHHmmss");
        private string path;
        private string controllName;
        private string imagePath;
        private string fileName;
        private ImageList list;
        private int count = 0;
        private int delete = 0;
        private Control select;
        private Boolean edit = false;
        private Boolean showList = false;
        //  private Boolean move = false;

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

            int newWidth = 0;
            int newHeight = 0;
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

        private void savePic()
        {
            Bitmap g = GetPanel(panelEx1);


            if (!Directory.Exists(path))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(path); //新建文件夹  
            }

            g.Save(fileName);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Bitmap outBmp = GetPanel(this.panelEx1);
            e.Graphics.DrawImage(outBmp, 0, 0);
        }

        private void 保存设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", null));
            XmlElement xmlelem = doc.CreateElement("", "Form1", "");
            doc.AppendChild(xmlelem);
            // doc.Load(path);

            for (int i = 0; i < panelEx1.Controls.Count; i++)
            {

                XmlElement xn = doc.CreateElement(panelEx1.Controls[i].Name);


                xn.SetAttribute("Text", panelEx1.Controls[i].Text.ToString());
                xn.SetAttribute("Top", panelEx1.Controls[i].Top.ToString());
                xn.SetAttribute("Left", panelEx1.Controls[i].Left.ToString());
                xn.SetAttribute("Width", panelEx1.Controls[i].Width.ToString());
                xn.SetAttribute("Height", panelEx1.Controls[i].Height.ToString());



                // XmlElement xnp = doc.CreateElement("panelEx1");
                XmlNodeList xnl = doc.GetElementsByTagName("panelEx1");
                XmlElement xnp;
                if (xnl.Count < 1)
                {
                    xnp = doc.CreateElement("panelEx1");
                }
                else
                {
                    xnp = (XmlElement)xnl[0];
                }
                xnp.AppendChild((XmlNode)xn);
                doc.DocumentElement.AppendChild((XmlNode)xnp);


            }
            doc.Save(xmlPath);

            this.Close();
        }

        private void 打印设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.UseEXDialog = true;

            //显示打印窗口
            if (this.printDialog1.ShowDialog() == DialogResult.OK)
            {
                if (validaing(textBox3, 50, "姓名") == false || validaing(textBox5, 50, "检查号") == false)
                {
                    MessageBox.Show("病历信息填写有误！", "出错提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    path = System.Environment.CurrentDirectory + "\\data\\" + textBox3.Text + "\\" + time;
                    fileName = path + "\\" + time + ".jpg";

                    DataRowView SelectedRowView = (DataRowView)this.infoBindingSource.Current;
                    病历信息DataSet.infoRow selectedRow = (病历信息DataSet.infoRow)SelectedRowView.Row;
                    selectedRow.Deleted = 0;
                    selectedRow.病历号 = 0;
                    selectedRow.table = fileName;
                    selectedRow.path = path;
                    this.infoBindingSource.EndEdit();
                    this.infoTableAdapter.Update(this.病历信息DataSet.info);

                    this.printDocument1.Print();

                    this.panelEx1.Focus();
                    this.savePic();

                    this.Close();
                }
                catch (SqlException error)
                {
                    MessageBox.Show("已有相同检查号！", "出错提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

            if (validaing(textBox3, 50, "姓名") == false || validaing(textBox5, 50, "检查号") == false)
            {
                MessageBox.Show("病历信息填写有误！", "出错提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ini ini = new ini(Directory.GetCurrentDirectory() + "\\config.ini");

                path = ini.ReadValue("Setting", "table") + "\\" + textBox3.Text + "\\" + time;
                fileName = path + "\\" + time + ".jpg";

                DataRowView SelectedRowView = (DataRowView)this.infoBindingSource.Current;
                病历信息DataSet.infoRow selectedRow = (病历信息DataSet.infoRow)SelectedRowView.Row;
                selectedRow.Deleted = 0;
                selectedRow.病历号 = 0;
                selectedRow.table = fileName;
                selectedRow.path = path;
                this.infoBindingSource.EndEdit();
                this.infoTableAdapter.Update(this.病历信息DataSet.info);

                this.printDocument1.Print();

                this.panelEx1.Focus();
                this.savePic();

                this.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show("已有相同检查号！", "出错提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private bool validaing(TextBox textbox, int length, string controlName)
        {
            bool result = false;
            if (textbox.TextLength == 0)
            {
                errorProvider1.SetError(textbox, "请输入" + controlName + "内容！");
                textbox.SelectAll();
                textbox.Focus();

            }
            else if (textbox.TextLength > length)
            {
                errorProvider1.SetError(textbox, "请输入小于" + length.ToString() + "个字符的" + controlName + "！");
                textbox.SelectAll();
                textbox.Focus();
            }
            else
            {
                errorProvider1.SetError(textbox, "");
                result = true;
            }
            return result;

        }

        private void initProperty()
        {
            
            for (int i = 0; i < panelEx1.Controls.Count; i++)
            {
                panelEx1.Controls[i].MouseDown += new System.Windows.Forms.MouseEventHandler(MyMouseClick);
                panelEx1.Controls[i].MouseMove += new System.Windows.Forms.MouseEventHandler(MyMouseMove);
                
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“病历信息DataSet.info”中。您可以根据需要移动或删除它。
            this.doctorTableAdapter.Fill(this.病历信息DataSet.doctor);
            this.infoTableAdapter.Fill(this.病历信息DataSet.info);
            this.infoBindingSource.AddNew();

            comboBox4.DataSource = this.病历信息DataSet.doctor.Copy();
            comboBox4.DisplayMember = "name";
            comboBox5.DataSource = this.病历信息DataSet.doctor.Copy();
            comboBox5.DisplayMember = "name";
            comboBox6.DataSource = this.病历信息DataSet.doctor.Copy();
            comboBox6.DisplayMember = "name";


            if (edit == false)
            {
                panelEx1.InitMouseAndContolStyle(xmlPath);
                listView1.Visible = false;
                panel1.Visible = false;
                this.Size = new Size(814, 780);
                保存设置ToolStripMenuItem.Visible = false;

            }
            if (edit == true)
            {
                panelEx1.InitMouseAndContolStyle(xmlPath, true);
                采集图像WToolStripMenuItem.Visible = false;
                截图预览ToolStripMenuItem.Visible = false;
                打印ToolStripMenuItem.Visible = false;
                this.Size = new Size(1100, 780);
            }
           // MessageBox.Show(panelEx1.Controls.Count+"");
            initProperty();

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);


            XmlNodeList nodes = doc.GetElementsByTagName("pictureBox5");
            if (nodes.Count == 1)
            {
                XmlAttributeCollection xac = nodes[0].Attributes;
                foreach (XmlAttribute xa in xac)
                {
                    if (xa.Value == "")
                        continue;
                    if (xa.Name == "image")
                    {
                        pictureBox5.ImageLocation = xa.Value;
                        // MessageBox.Show(xa.Name);
                    }
                }
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
            if (delete == 0)
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
                pictureBox1.ImageLocation = "image\\a.jpg";
                delete = 1;
            }

        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                pictureBox2.ImageLocation = "image\\a.jpg";
                delete = 2;
            }

        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pictureBox3.ImageLocation = "image\\a.jpg";
                delete = 3;
            }

        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pictureBox4.ImageLocation = "image\\a.jpg";
                delete = 4;
            }

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int i = listView1.SelectedItems[0].Index;
            table form = new table(list.Images.Keys[i]);
            form.Show();
        }

        private void 采集图像WToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (validaing(textBox3, 50, "姓名") == false || validaing(textBox5, 50, "检查号") == false)
            {
                MessageBox.Show("病历信息填写有误！", "出错提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Form2 form = new Form2(this.textBox3.Text, time);
            if (form.ShowDialog() == DialogResult.Yes)
            {
                this.list = form.getPath();
                listView1.Clear();
                this.listView1.LargeImageList = list;
                for (int i = 0; i < list.Images.Count; i++)
                {
                    listView1.Items.Add("", i);
                    listView1.Items[i].ImageIndex = i;
                }
                this.Size = new Size(1018, 780);
                this.edit = true;
            }
        }

        private void Form4_Shown(object sender, EventArgs e)
        {
            textBox3.Focus();
            if (edit == false)
            {
                DateTime dt = DateTime.Now;
                String date = dt.ToString();
                textBox2.Text = date;
                comboBox1.Text = "男";
                comboBox3.Text = "a";
                comboBox10.Text = "无";
            }
        }

        private void MyMouseClick(object sender, EventArgs e)
        {
            select = (Control)sender;
            this.controllName = select.Name;
            Text.Text = select.Text;
            Top.Text = select.Top + "";
            Left.Text = select.Left + "";
            Width.Text = select.Width + "";
            Height.Text = select.Height + "";
        }

        private void MyMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control s = (Control)sender;
                // this.controllName = s.Name;
                Text.Text = s.Text;
                Top.Text = s.Top + "";
                Left.Text = s.Left + "";
                Width.Text = s.Width + "";
                Height.Text = s.Height + "";
            }
        }

        private void MyTextChanged(object sender, EventArgs e)
        {
            Control s = (Control)sender;
           /* XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            XmlNodeList nodes = doc.GetElementsByTagName(controllName);
            //   MessageBox.Show(controllName);
            XmlElement xn;
            if (nodes.Count != 1)
            {
                xn = doc.CreateElement(controllName);
            }
            else
            {
                xn = (XmlElement)doc.GetElementsByTagName(controllName)[0];
            }
            xn.SetAttribute(s.Name, s.Text);
            XmlNodeList xnl = doc.GetElementsByTagName("panelEx1");
            XmlElement xnp;
            if (xnl.Count < 1)
            {
                xnp = doc.CreateElement("panelEx1");
            }
            else
            {
                xnp = (XmlElement)xnl[0];
            }
            xnp.AppendChild((XmlNode)xn);

            doc.DocumentElement.AppendChild((XmlNode)xnp);
            doc.Save(xmlPath);

            // panelEx1.InitMouseAndContolStyle(xmlPath, true);
            panelEx1.initStyle(xmlPath);*/
            if(s.Text!="")
            switch (s.Name)
            { 
                case "Top":
                    select.Top = Int32.Parse(s.Text);
                    break;
                case "Left":
                    select.Left = Int32.Parse(s.Text);
                    break;
                case "Width":
                    select.Width = Int32.Parse(s.Text);
                    break;
                case "Height":
                    select.Height = Int32.Parse(s.Text);
                    break;
                case "Text":
                    select.Text = s.Text;
                    break;
                default:
                    break;
            }
        }

        private void pictureBox5_DoubleClick(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "*.jpg|*.jpg|*.bmp|*.bmp|*.png|*.png|*.ico|*.ico|*.*|*.*";
            this.openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox5.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            // doc.Load("aaa.xml");

            XmlNodeList nodes = doc.GetElementsByTagName("pictureBox5");

            XmlElement xn;
            if (nodes.Count != 1)
            {
                xn = doc.CreateElement("pictureBox5");
            }
            else
            {
                xn = (XmlElement)doc.GetElementsByTagName("pictureBox5")[0];
            }

            xn.SetAttribute("image", pictureBox5.ImageLocation);

            XmlNodeList xnl = doc.GetElementsByTagName("panelEx1");
            XmlElement xnp;

            if (xnl.Count < 1)
            {
                xnp = doc.CreateElement("panelEx1");
            }
            else
            {
                xnp = (XmlElement)xnl[0];
            }
            xnp.AppendChild((XmlNode)xn);

            doc.DocumentElement.AppendChild((XmlNode)xnp);

            doc.Save(xmlPath);
            // MessageBox.Show(xmlPath);
            //doc.Save("aaa.xml");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelEx1.Controls.Remove(select);
            Text.Text = "";
            Top.Text = "0";
            Left.Text = "0";
            Width.Text = "0";
            Height.Text = "0";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelEx1.initStyle("original.xml");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int xmlNum = 0;
            string dir = AppDomain.CurrentDomain.BaseDirectory + "model";
            saveFileDialog1.InitialDirectory = dir;

            DirectoryInfo mydir = new DirectoryInfo(dir);
            foreach (FileInfo fi in mydir.GetFiles())
            {
                string s = Path.GetExtension(fi.FullName);

                if (s == ".xml")
                {
                    xmlNum++;
                }
            }
            xmlNum -= 2;
            saveFileDialog1.FileName = "model_"+xmlNum+".xml";
            //MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory + "model");
            saveFileDialog1.Filter = "*.xml|";
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                if (File.Exists(path) == true)
                {
                    MessageBox.Show("存在此文件!");
                }
                else
                {
                    XmlDocument doc = new XmlDocument();
                    doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", null));
                    XmlElement xmlelem = doc.CreateElement("", "Form1", "");
                    doc.AppendChild(xmlelem);
                    // doc.Load(path);
                    try
                    {
                        for (int i = 0; i < panelEx1.Controls.Count; i++)
                        {

                            XmlElement xn = doc.CreateElement(panelEx1.Controls[i].Name);


                            xn.SetAttribute("Text", panelEx1.Controls[i].Text.ToString());
                            xn.SetAttribute("Top", panelEx1.Controls[i].Top.ToString());
                            xn.SetAttribute("Left", panelEx1.Controls[i].Left.ToString());
                            xn.SetAttribute("Width", panelEx1.Controls[i].Width.ToString());
                            xn.SetAttribute("Height", panelEx1.Controls[i].Height.ToString());



                            // XmlElement xnp = doc.CreateElement("panelEx1");
                            XmlNodeList xnl = doc.GetElementsByTagName("panelEx1");
                            XmlElement xnp;
                            if (xnl.Count < 1)
                            {
                                xnp = doc.CreateElement("panelEx1");
                            }
                            else
                            {
                                xnp = (XmlElement)xnl[0];
                            }
                            xnp.AppendChild((XmlNode)xn);
                            doc.DocumentElement.AppendChild((XmlNode)xnp);


                        }
                        doc.Save(path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }


        }

        private void 取消QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panelEx1.initStyle("model\\一幅图.xml");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panelEx1.initStyle("model\\两幅图.xml");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panelEx1.initStyle("model\\四幅图.xml");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.xml|";
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "model";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                panelEx1.initStyle(openFileDialog1.FileName);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int i = panelEx1.Controls.Count;
            Label l = new Label();
            l.Name = "customLable"+i;
            l.Text = "请输入内容";
            l.Top = 16;
            l.Left = 650;
            l.Width = 100;
            l.Height = 20;

            TextBox t = new TextBox();
            t.Name = "customTextBox"+i;
            t.Text = "";
            t.Top = 50;
            t.Left = 650;
            t.Width = 100;
            t.Height = 20;
            t.Multiline = true;

            panelEx1.Controls.Add(l);
            panelEx1.Controls.Add(t);
            panelEx1.initProperty();
            this.initProperty();
            //panelEx1.CreateControl();

        }

    }
}
