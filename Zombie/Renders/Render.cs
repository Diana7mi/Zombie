using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Zombie.Render
{
    public abstract class Render : IRender
    {
        protected Bitmap[] Bitmaps;
        protected int cell = 0;
        protected int frame = 0;
        protected int Max_Frame;
        protected BaseObject baseObject;

        public Form Form { get; set; }
        protected abstract void initializeImages();

        public Render(Form form, BaseObject baseObject, int MaxFrame)
        {
            this.Form = form;
            this.baseObject = baseObject;
            this.Max_Frame = MaxFrame;
            initializeImages();
        }
    
        public void PaintObj(Graphics g)
        {
            g.DrawImageUnscaled(Bitmaps[baseObject.Cell],
                                            baseObject.Location.X, baseObject.Location.Y);
        }
        public void Animate()
        {
            frame++;
            if (frame >= Max_Frame)
            {
                frame = 0;
            }
            baseObject.Cell = cell = frame;
            Form.Invalidate();
        }
    }
}
