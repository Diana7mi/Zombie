using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Zombie
{
    public class BaseObject
    {
        public BaseObject() { }
        public BaseObject(Point location)
        {
            this.Cell = 0;
            this.Location = location;
        }
        //位置
        public Point Location { get; set; }
        //id
        protected int ID;

        //某状态下 图像的状态
        public int Cell { get; set; }
        //图像拥有的大小
        public Size Size { get; set; }
        //此对象拥有的二维空间
        //加此属性是为了判断两个对象是否相交
        public Rectangle Rectangle { get; set; }
    }
}
