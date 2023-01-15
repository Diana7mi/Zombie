using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Zombie.Render
{
    class RepeaterRender:Render
    {
        public RepeaterRender(Form form, BaseObject baseObject)
           : base(form, baseObject, 15)
        {
        }
        protected override void initializeImages()
        {
            Bitmaps = new Bitmap[this.Max_Frame];
            /*Bitmaps[0] = Properties.Resources.Repeater01;
            Bitmaps[1] = Properties.Resources.Repeater02;
            Bitmaps[2] = Properties.Resources.Repeater03;
            Bitmaps[3] = Properties.Resources.Repeater04;
            Bitmaps[4] = Properties.Resources.Repeater05;
            Bitmaps[5] = Properties.Resources.Repeater06;
            Bitmaps[6] = Properties.Resources.Repeater07;
            Bitmaps[7] = Properties.Resources.Repeater08;
            Bitmaps[8] = Properties.Resources.Repeater09;
            Bitmaps[9] = Properties.Resources.Repeater10;
            Bitmaps[10] = Properties.Resources.Repeater11;
            Bitmaps[11] = Properties.Resources.Repeater12;
            Bitmaps[12] = Properties.Resources.Repeater13;
            Bitmaps[13] = Properties.Resources.Repeater14;
            Bitmaps[14] = Properties.Resources.Repeater15;*/

        }
    }
}
