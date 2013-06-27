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
    public partial class NewSheet : Form
    {
        private string Current = AppDomain.CurrentDomain.BaseDirectory;
        private string xmlPath = AppDomain.CurrentDomain.BaseDirectory + "App.xml";
        private string time = DateTime.Now.ToString("yyyy年MM月dd日HH时mm分ss秒");
        private string path;
        private string controllName;
        private string imagePath;
        private string model;
        private string fileName;
        private int count = 0;
        private int delete = 0;
        private Control select;
        private Boolean edit = false;
        private Boolean showList = false;
        private Boolean save = false;
        private ini ini = new ini(AppDomain.CurrentDomain.BaseDirectory + "\\config.ini");
        
        public NewSheet(Boolean editable = false)
        {
            InitializeComponent();
            edit = editable;

            panel1.Parent = panel2;
            panelEx1.Parent = panel2;
            listView1.Parent = panel2;

            //this.panel2.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseWheel);
        }
        private void Panel_MouseWheel(object sender, MouseEventArgs e)
        {
            panel2.Focus();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“病历信息DataSet.info”中。您可以根据需要移动或删除它。
            this.doctorTableAdapter.Fill(this.病历信息DataSet.doctor);
            this.infoTableAdapter.Fill(this.病历信息DataSet.info);
            this.infoBindingSource.AddNew();
            pictureBox1.ImageLocation = "image\\16-9.png";
            pictureBox2.ImageLocation = "image\\16-9.png";
            pictureBox3.ImageLocation = "image\\16-9.png";
            pictureBox4.ImageLocation = "image\\16-9.png";

            comboBox4.DataSource = this.病历信息DataSet.doctor.Copy();
            comboBox4.DisplayMember = "name";
            comboBox5.DataSource = this.病历信息DataSet.doctor.Copy();
            comboBox5.DisplayMember = "name";
            comboBox6.DataSource = this.病历信息DataSet.doctor.Copy();
            comboBox6.DisplayMember = "name";

            ini = new ini(Current + "\\config.ini");
            string model = ini.ReadValue("Setting", "model");
            
            if (model.Equals("1"))
            {
                pictureBox1.ImageLocation = "image\\400-225.png";
                   
            }
            else
            {
                
                   pictureBox1.ImageLocation = "image\\16-9.png";
            }
            

            if (edit == false)
            {
                panelEx1.InitMouseAndContolStyle(xmlPath);
                listView1.Visible = false;
                panel1.Visible = false;
                this.Size = new Size(1018, 780);
                保存设置ToolStripMenuItem.Visible = false;

                for (int i = 0; i < panelEx1.Controls.Count; i++)
                {
                    if (panelEx1.Controls[i] is TextBox )
                    {
                        panelEx1.Controls[i].MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseWheel);
                    }

                }

               

            }
            if (edit == true)
            {
                panelEx1.InitMouseAndContolStyle(xmlPath, true);
                采集图像WToolStripMenuItem.Visible = false;
                截图预览ToolStripMenuItem.Visible = false;
                打印ToolStripMenuItem.Visible = false;
                保存SToolStripMenuItem.Visible = false;

                for (int i = 0; i < panelEx1.Controls.Count; i++)
                {
                    if (panelEx1.Controls[i] is TextBox || panelEx1.Controls[i] is ComboBox)
                    {
                        panelEx1.Controls[i].KeyPress += new System.Windows.Forms.KeyPressEventHandler(MyKeyPress);
                    }
                   
                }
                initProperty();
            }

            for (int i = 0; i < panelEx1.Controls.Count; i++)
            {
                if (panelEx1.Controls[i] != label1 && panelEx1.Controls[i] != label2)
                panelEx1.Controls[i].Font = new System.Drawing.Font("宋体",10.5f);
            }
            this.listView1.Visible = true;
            

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
                    }
                }
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
                
            }
            comboBox10.Text = "";
            comboBox6.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
        }

        public Bitmap GetPanel(Panel p_Panel)
        {
            Bitmap _BitMap = new Bitmap(p_Panel.Width, p_Panel.Height);
            for (int i = 0; i < p_Panel.Controls.Count; i++)
            {
                if (p_Panel.Controls[i] is TextBox)
                {
                    TextBox tb = (TextBox)p_Panel.Controls[i];
                    tb.BorderStyle = BorderStyle.None;
                }
                if (p_Panel.Controls[i] is ComboBox)
                {
                    ComboBox tb = (ComboBox)p_Panel.Controls[i];
                    tb.FlatStyle = FlatStyle.Flat;
                }

            }
            p_Panel.DrawToBitmap(_BitMap, new System.Drawing.Rectangle(0, 0, _BitMap.Width, _BitMap.Height));

            int newWidth = 794;
            int newHeight = 1123;
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

           // Bitmap _PrintImage = GetPanel(this.panelEx1);
           // int _X = (e.PageBounds.Width - _PrintImage.Width) / 2;
           // int _Y = (e.PageBounds.Height - _PrintImage.Height) / 2;
           // int _X = -15;
           // int _Y = -5;
           // e.Graphics.DrawImage(_PrintImage, _X, _Y, _PrintImage.Width, _PrintImage.Height);

            XmlDocument doc = new XmlDocument();
            doc.Load(path + "\\" + time + ".bak");


            
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

                
                if(list[i].Name == "label1")
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
            ini = new ini(Current + "\\config.ini");
            ini.Writue("Setting", "model", model); 
            this.Close();
        }

        private void 打印设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.UseEXDialog = true;

            //显示打印窗口
            if (this.printDialog1.ShowDialog() == DialogResult.OK)
            {
                saveInfo();
                
                this.panelEx1.Focus();
                this.printDocument1.Print();
                    
                
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
                //this.printPreviewDialog1.ShowDialog();
                saveInfo();
                
                if (this.printPreviewDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    for (int i = 0; i < panelEx1.Controls.Count; i++)
                    {
                        if (panelEx1.Controls[i] is TextBox)
                        {
                            TextBox tb = (TextBox)panelEx1.Controls[i];
                            tb.BorderStyle = BorderStyle.Fixed3D;
                        }
                        if (panelEx1.Controls[i] is ComboBox)
                        {
                            ComboBox tb = (ComboBox)panelEx1.Controls[i];
                            tb.FlatStyle = FlatStyle.Standard;
                        }
                    }
                }
                
            }
            catch (Exception excep)
            {
                //显示打印出错消息
                MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveInfo();
     
            this.panelEx1.Focus();
            this.printDocument1.Print();

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

        private void 采集图像WToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (validaing(textBox3, 50, "姓名") == false || validaing(textBox23, 50, "科室") == false || validaing(comboBox5, 50, "检查医师") == false || validaing(textBox5, 50, "检查号") == false)
            {
                MessageBox.Show("病历信息填写有误！", "视频采集系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int imageNum = 0;
            int flag = 0;
           
            this.Size = new Size(1018, 780);
            this.showList = true;

            ImageCollecter form = new ImageCollecter(this.textBox3.Text, time);
            if (form.ShowDialog() == DialogResult.Yes)
            {
                list.Images.Clear();
                listView1.Items.Clear();
                DirectoryInfo mydir = new DirectoryInfo(form.getPath());
                foreach (FileSystemInfo fsi in mydir.GetFileSystemInfos())
                {
                    if (fsi is FileInfo)
                    {
                        FileInfo fi = (FileInfo)fsi;
                        string s = Path.GetExtension(fi.FullName);

                        if (s == ".jpg")
                        {
                            list.Images.Add(System.Drawing.Image.FromFile(fi.FullName));
                            list.Images.SetKeyName(flag++, fi.FullName);

                            ListViewItem lvi = new ListViewItem();
                            lvi.ImageIndex = imageNum++;
                            lvi.Name = fi.FullName;
                            this.listView1.Items.Add(lvi);
                        }
                    }
                }
            }
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("报告保存后不可更改，您确定要保存么？", "视频采集系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                saveInfo();
            }
        }

        private void 取消QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (save == false)
            {
                if (MessageBox.Show("您的报告还没有保存，离开后该报告信息将被丢弃，您确定要离开么？", "视频采集系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
                this.Close();

        }

        private bool validaing(Control box, int length, string controlName)
        {
            bool result = false;
            if (box.Text.Length == 0)
            {
                errorProvider1.SetError(box, "请输入" + controlName + "内容！");
               // box.SelectAll();
                box.Focus();

            }
            else if (box.Text.Length > length)
            {
                errorProvider1.SetError(box, "请输入小于" + length.ToString() + "个字符的" + controlName + "！");
               // box.SelectAll();
                box.Focus();
            }
            else
            {
                errorProvider1.SetError(box, "");
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

        private void MyKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.KeyChar = (char)0;
            //MessageBox.Show("aaa");
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

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int i = listView1.SelectedItems[0].Index;
            MyImage form = new MyImage(list.Images.Keys[i],1);
            form.Show();
        }
        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            ini = new ini(Current + "\\config.ini");
            string model = ini.ReadValue("Setting", "model");
            if (e.Button == MouseButtons.Right)
            {
                if (model.Equals("1"))
                {
                    pictureBox1.ImageLocation = "image\\400-300.png";
                    delete = 1;
                }
                else
                {
                    pictureBox1.ImageLocation = "image\\4-3.png";
                    delete = 1;
                }
            }

        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                pictureBox2.ImageLocation = "image\\4-3.png";
                delete = 2;
            }

        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pictureBox3.ImageLocation = "image\\4-3.png";
                delete = 3;
            }

        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pictureBox4.ImageLocation = "image\\4-3.png";
                delete = 4;
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

            Text.Enabled = true;
            Top.Enabled = true;
            Left.Enabled = true;
            Width.Enabled = true;
            Height.Enabled = true;
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

            if (s.Text != "")
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

            XmlElement xn = (XmlElement)doc.GetElementsByTagName("pictureBox5")[0];

            xn.SetAttribute("image", pictureBox5.ImageLocation);

            doc.Save(xmlPath);
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
            for (int i = 0; i < panelEx1.Controls.Count; i++)
            {
                if (panelEx1.Controls[i] is TextBox || panelEx1.Controls[i] is ComboBox)
                {
                    panelEx1.Controls[i].Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveXML(saveFileDialog1.FileName);
            }

        }
        private void saveXML(string path)
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
            saveFileDialog1.FileName = "model_" + xmlNum + ".xml";
            //MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory + "model");
            saveFileDialog1.Filter = "*.xml|";

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
                    XmlElement xxn = (XmlElement)doc.GetElementsByTagName("pictureBox1")[0];
                    xxn.SetAttribute("image", pictureBox1.ImageLocation);
                    xxn = (XmlElement)doc.GetElementsByTagName("pictureBox2")[0];
                    xxn.SetAttribute("image", pictureBox2.ImageLocation);
                    xxn = (XmlElement)doc.GetElementsByTagName("pictureBox3")[0];
                    xxn.SetAttribute("image", pictureBox3.ImageLocation);
                    xxn = (XmlElement)doc.GetElementsByTagName("pictureBox4")[0];
                    xxn.SetAttribute("image", pictureBox4.ImageLocation);
                    xxn = (XmlElement)doc.GetElementsByTagName("pictureBox5")[0];
                    xxn.SetAttribute("image", pictureBox5.ImageLocation);
                    
                    doc.Save(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            panelEx1.initStyle("model\\一幅图.xml");
            pictureBox1.ImageLocation = "image\\400-300.png";
            model = "1";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panelEx1.initStyle("model\\两幅图.xml");
            pictureBox1.ImageLocation = "image\\4-3.png";
            model = "2";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panelEx1.initStyle("model\\四幅图.xml");
            pictureBox1.ImageLocation = "image\\4-3.png";
            model = "4";
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
            l.Name = "customLable" + i;
            l.Text = "请输入内容";
            l.Top = 16;
            l.Left = 650;
            l.Width = 100;
            l.Height = 20;

            TextBox t = new TextBox();
            t.Name = "customTextBox" + i;
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

        private Boolean saveInfo()
        {

            if (validaing(textBox3, 50, "姓名") == false || validaing(textBox23, 50, "科室") == false || validaing(comboBox5, 50, "检查医师") == false || validaing(textBox5, 50, "检查号") == false)
            {
                MessageBox.Show("病历信息填写有误！", "视频采集系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (save == false)
            {
                path = ini.ReadValue("Setting", "table") + "\\" + textBox3.Text + "\\" + time;
                fileName = path + "\\" + time + ".jpg";

                DataRowView SelectedRowView = (DataRowView)this.infoBindingSource.Current;
                病历信息DataSet.infoRow selectedRow = (病历信息DataSet.infoRow)SelectedRowView.Row;
                selectedRow.Deleted = 0;
                selectedRow.病历号 = 0;
                selectedRow._Table = fileName;
                selectedRow.Path = path;

                if (infoBindingSource.SupportsSearching != true)
                {
                    MessageBox.Show("Cannot search the list.");
                    return false;
                }
                else
                {
                    int foundIndex = infoBindingSource.Find("检查号", textBox5.Text);
                    if (foundIndex > -1)
                    {
                        MessageBox.Show("已有相同检查号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else
                    {
                        this.infoBindingSource.EndEdit();
                        this.infoTableAdapter.Update(this.病历信息DataSet.info);
                        this.savePic();
                        this.saveXML(path + "\\" + time + ".bak");
                        //this.DialogResult = DialogResult.Yes;
                        save = true;
                        保存SToolStripMenuItem.Enabled = false;

                        MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
            }
            else
                return false;
        }
    }
}
