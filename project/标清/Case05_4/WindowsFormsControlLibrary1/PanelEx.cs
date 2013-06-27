using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsControlLibrary1
{
    /// <summary>
    /// 该控件用于放置可由用户自己设置大小和位置的控件，继承自Panel,实现了IControlsMove接口
    /// 要使该容器内的控件可移动和改变，需要在程序加载时调用该控件的InitMouseAndContolStyle(XmlDocument XmlDoc)方法
    /// </summary>
    public partial class PanelEx : Panel
    {
        /// <summary>
        /// 光标状态
        /// </summary>
        private enum EnumMousePointPosition
        {
            MouseSizeNone = 0, //'无   
            MouseSizeRight = 1, //'拉伸右边框   
            MouseSizeLeft = 2, //'拉伸左边框   
            MouseSizeBottom = 3, //'拉伸下边框   
            MouseSizeTop = 4, //'拉伸上边框   
            MouseSizeTopLeft = 5, //'拉伸左上角   
            MouseSizeTopRight = 6, //'拉伸右上角   
            MouseSizeBottomLeft = 7, //'拉伸左下角   
            MouseSizeBottomRight = 8, //'拉伸右下角   
            MouseDrag = 9   // '鼠标拖动   
        }
        #region 属性
        private static string xmlDocPath = "";
        private XmlDocument doc;
        private const int Band = 5;
        private const int MinWidth = 10;
        private const int MinHeight = 10;
        private EnumMousePointPosition m_MousePointPosition;
        private Point p, p1;
        #endregion
        public PanelEx()
        {
            InitializeComponent();
        }

        #region 改变控件大小和移动位置用到的方法



        private void MyMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            p.X = e.X;
            p.Y = e.Y;
            p1.X = e.X;
            p1.Y = e.Y;
        }
        /// <summary>
        /// 鼠标离开事件需要改进
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyMouseLeave(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //MessageBox.Show("aaaa");
                m_MousePointPosition = EnumMousePointPosition.MouseSizeNone;
                this.Cursor = Cursors.Arrow;
            }
        }

        private EnumMousePointPosition MousePointPosition(Size size, System.Windows.Forms.MouseEventArgs e)
        {

            if ((e.X >= -1 * Band) | (e.X <= size.Width) | (e.Y >= -1 * Band) | (e.Y <= size.Height))
            {
                if (e.X < Band)
                {
                    if (e.Y < Band) { return EnumMousePointPosition.MouseSizeTopLeft; }
                    else
                    {
                        if (e.Y > -1 * Band + size.Height)
                        { return EnumMousePointPosition.MouseSizeBottomLeft; }
                        else
                        { return EnumMousePointPosition.MouseSizeLeft; }
                    }
                }
                else
                {
                    if (e.X > -1 * Band + size.Width)
                    {
                        if (e.Y < Band)
                        { return EnumMousePointPosition.MouseSizeTopRight; }
                        else
                        {
                            if (e.Y > -1 * Band + size.Height)
                            { return EnumMousePointPosition.MouseSizeBottomRight; }
                            else
                            { return EnumMousePointPosition.MouseSizeRight; }
                        }
                    }
                    else
                    {
                        if (e.Y < Band)
                        { return EnumMousePointPosition.MouseSizeTop; }
                        else
                        {
                            if (e.Y > -1 * Band + size.Height)
                            { return EnumMousePointPosition.MouseSizeBottom; }
                            else
                            { return EnumMousePointPosition.MouseDrag; }
                        }
                    }
                }
            }
            else
            { return EnumMousePointPosition.MouseSizeNone; }
        }
        private void MyMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Control lCtrl = (sender as Control);

            if (e.Button == MouseButtons.Left)
            {
                switch (m_MousePointPosition)
                {
                    case EnumMousePointPosition.MouseDrag:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Top = lCtrl.Top + e.Y - p.Y;
                        break;
                    case EnumMousePointPosition.MouseSizeBottom:
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点   
                        break;
                    case EnumMousePointPosition.MouseSizeBottomRight:
                        lCtrl.Width = lCtrl.Width + e.X - p1.X;
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点   
                        break;
                    case EnumMousePointPosition.MouseSizeRight:
                        lCtrl.Width = lCtrl.Width + e.X - p1.X;
                        //       lCtrl.Height = lCtrl.Height + e.Y - p1.Y;   
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点   
                        break;
                    case EnumMousePointPosition.MouseSizeTop:
                        lCtrl.Top = lCtrl.Top + (e.Y - p.Y);
                        lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
                        break;
                    case EnumMousePointPosition.MouseSizeLeft:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Width = lCtrl.Width - (e.X - p.X);
                        break;
                    case EnumMousePointPosition.MouseSizeBottomLeft:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Width = lCtrl.Width - (e.X - p.X);
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点   
                        break;
                    case EnumMousePointPosition.MouseSizeTopRight:
                        lCtrl.Top = lCtrl.Top + (e.Y - p.Y);
                        lCtrl.Width = lCtrl.Width + (e.X - p1.X);
                        lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点   
                        break;
                    case EnumMousePointPosition.MouseSizeTopLeft:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Top = lCtrl.Top + (e.Y - p.Y);
                        lCtrl.Width = lCtrl.Width - (e.X - p.X);
                        lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
                        break;
                    default:
                        break;
                }
                if (lCtrl.Width < MinWidth) lCtrl.Width = MinWidth;
                if (lCtrl.Height < MinHeight) lCtrl.Height = MinHeight;
            }
            else
            {
                m_MousePointPosition = MousePointPosition(lCtrl.Size, e);   //'判断光标的位置状态   
                switch (m_MousePointPosition)   //'改变光标   
                {
                    case EnumMousePointPosition.MouseSizeNone:
                        this.Cursor = Cursors.Arrow;        //'箭头   
                        break;
                    case EnumMousePointPosition.MouseDrag:
                        this.Cursor = Cursors.SizeAll;      //'四方向   
                        break;
                    case EnumMousePointPosition.MouseSizeBottom:
                        this.Cursor = Cursors.SizeNS;       //'南北   
                        break;
                    case EnumMousePointPosition.MouseSizeTop:
                        this.Cursor = Cursors.SizeNS;       //'南北   
                        break;
                    case EnumMousePointPosition.MouseSizeLeft:
                        this.Cursor = Cursors.SizeWE;       //'东西   
                        break;
                    case EnumMousePointPosition.MouseSizeRight:
                        this.Cursor = Cursors.SizeWE;       //'东西   
                        break;
                    case EnumMousePointPosition.MouseSizeBottomLeft:
                        this.Cursor = Cursors.SizeNESW;     //'东北到南西   
                        break;
                    case EnumMousePointPosition.MouseSizeBottomRight:
                        this.Cursor = Cursors.SizeNWSE;     //'东南到西北   
                        break;
                    case EnumMousePointPosition.MouseSizeTopLeft:
                        this.Cursor = Cursors.SizeNWSE;     //'东南到西北   
                        break;
                    case EnumMousePointPosition.MouseSizeTopRight:
                        this.Cursor = Cursors.SizeNESW;     //'东北到南西   
                        break;
                    default:
                        break;
                }
            }

        }


        #endregion

        #region 初始化鼠标事件委托和控件大小和移动
        public void initProperty()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                this.Controls[i].MouseDown += new System.Windows.Forms.MouseEventHandler(MyMouseDown);
                this.Controls[i].MouseUp += new System.Windows.Forms.MouseEventHandler(MyMouseLeave);
                this.Controls[i].MouseMove += new System.Windows.Forms.MouseEventHandler(MyMouseMove);
            }

        }
        public void initStyle(string XmlDocPath)
        {
            xmlDocPath = XmlDocPath;
            doc = new XmlDocument();
            doc.Load(XmlDocPath);
            Control s;
            XmlNodeList nodes = doc.ChildNodes[1].ChildNodes[0].ChildNodes;
            if (this.Controls.Count < nodes.Count)
            {

                foreach (XmlElement node in nodes)
                {
                    Boolean custom = true;
                    
                    for (int i = 0; i < Controls.Count; i++)
                    {
                        if (Controls[i].Name == node.Name)
                        {
                            custom = false;
                        }
                    }
                    
                    if (custom == true)
                    {
                       // MessageBox.Show(node.Name.Substring(6, 1));
                        if (node.Name.Substring(6, 1) == "T")
                        {
                            
                            TextBox l = new TextBox();
                            l.Name = node.Name;
                            XmlAttributeCollection xac = node.Attributes;
                            foreach (XmlAttribute xa in xac)
                            {

                                if (xa.Value == "")
                                    continue;
                                //MessageBox.Show(xa.Name);
                                switch (xa.Name)
                                {
                                       
                                    case "Top":
                                        l.Top = Convert.ToInt32(xa.Value);

                                        break;
                                    case "Left":
                                        l.Left = Convert.ToInt32(xa.Value);

                                        break;
                                    case "Width":
                                        l.Width = Convert.ToInt32(xa.Value);

                                        break;
                                    case "Height":
                                        l.Height = Convert.ToInt32(xa.Value);

                                        break;
                                    case "Text":
                                        l.Text = xa.Value;

                                        break;
                                    default:
                                        break;
                                }

                            }
                            this.Controls.Add(l);

                        }
                        if (node.Name.Substring(6, 1) == "L")
                        {
                            Label l = new Label();
                            l.Name = node.Name;
                            XmlAttributeCollection xac = node.Attributes;
                            foreach (XmlAttribute xa in xac)
                            {

                                if (xa.Value == "")
                                    continue;
                                switch (xa.Name)
                                {
                                    case "Top":
                                        l.Top = Convert.ToInt32(xa.Value);

                                        break;
                                    case "Left":
                                        l.Left = Convert.ToInt32(xa.Value);

                                        break;
                                    case "Width":
                                        l.Width = Convert.ToInt32(xa.Value);

                                        break;
                                    case "Height":
                                        l.Height = Convert.ToInt32(xa.Value);

                                        break;
                                    case "Text":
                                        l.Text = xa.Value;

                                        break;
                                    default:
                                        break;
                                }

                            }
                            this.Controls.Add(l);

                        }
                    }
                    //initProperty();
                }
            }
            else
            {
                //MessageBox.Show(this.Controls[0].Name);
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    s = this.Controls[i];
                    XmlNodeList node = doc.GetElementsByTagName(s.Name);

                    if (node.Count == 1)
                    {

                        XmlAttributeCollection xac = node[0].Attributes;
                        foreach (XmlAttribute xa in xac)
                        {
                            if (xa.Value == "")
                                continue;
                            switch (xa.Name)
                            {
                                case "Top":
                                    var Top = Convert.ToInt32(xa.Value);
                                    s.Top = Top;
                                    break;
                                case "Left":
                                    var Left = Convert.ToInt32(xa.Value);
                                    s.Left = Left;
                                    break;
                                case "Width":
                                    var Width = Convert.ToInt32(xa.Value);
                                    s.Width = Width;
                                    break;
                                case "Height":
                                    var Height = Convert.ToInt32(xa.Value);
                                    s.Height = Height;
                                    break;
                                case "Text":
                                    var Text = xa.Value;
                                    s.Text = Text;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        this.Controls.Remove(s);
                        i--;
                    }
                }
            }
        }
        #endregion
        /// <summary>
        /// 用于实现容器内控件移动和改变大小的方法
        /// </summary>
        /// <param name="XmlDoc">用于保存控件的属性的XML文档</param>
        public void InitMouseAndContolStyle(string XmlDocPath, Boolean edit = false)
        {
            // xmlDocPath = XmlDocPath;
            doc = new XmlDocument();
            doc.Load(XmlDocPath);
            
            initStyle(XmlDocPath);
            if (edit == true)
            {
                initProperty();
            }
        }
    }
}
