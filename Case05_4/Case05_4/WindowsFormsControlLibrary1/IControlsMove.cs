using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WindowsFormsControlLibrary1
{
    /// <summary>
    /// 用于容器控件，使该容器内的控件可被用户移动和改变大小
    /// </summary>
    public interface IControlsMove
    {
       //  //enum EnumMousePointPosition{}
       //void MyMouseDown(object sender, System.Windows.Forms.MouseEventArgs e);
       //void MyMouseLeave(object sender, EventArgs e);
       //  //EnumMousePointPosition MousePointPosition(Size size, System.Windows.Forms.MouseEventArgs e) { }
       //void MyMouseMove(object sender, System.Windows.Forms.MouseEventArgs e);
       // XmlDocument doc { set; get; }
        /// <summary>
        /// 初始化容器内鼠标事件和加载指定xml文档内的控件外观属性
        /// </summary>
        /// <param name="XmlDoc">存储该容器内的控件的大小和位置属性的XML文件</param>
       void InitMouseAndContolStyle(XmlDocument XmlDoc);
    }
}
