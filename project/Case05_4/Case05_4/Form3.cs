using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Case05_4
{
    public partial class 镜检录像与图片 : Form
    {
        private int imageNum;
        public 镜检录像与图片(string path)
        {
            InitializeComponent();
            axWindowsMediaPlayer1.windowlessVideo = false; 
            DirectoryInfo mydir = new DirectoryInfo(path);  
            foreach (FileSystemInfo fsi in mydir.GetFileSystemInfos())   
            {
                if (fsi is FileInfo)
                {
                    FileInfo fi = (FileInfo)fsi;

                    string s = Path.GetExtension(fi.FullName);
                    
                    if (s == ".png")
                    {
                        imageList1.Images.Add(Image.FromFile(fi.FullName));
                        
                        ListViewItem lvi = new ListViewItem();
                        lvi.ImageIndex = imageNum++;
                        lvi.Name = fi.FullName;
                        this.listView1.Items.Add(lvi);
                    }
                    if (s == ".mpg")
                    { 
                        this.axWindowsMediaPlayer1.URL = fi.FullName;
                        axWindowsMediaPlayer1.Ctlcontrols.stop();       //停止
                    }

                }
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int i = listView1.SelectedItems[0].Index;
            table form = new table(listView1.Items[i].Name, 1);
            form.Show();
        }

    }
}
