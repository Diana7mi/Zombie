using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Zombie.Render
{
    public class Zombie1Render : Render
    {
        public Zombie1Render(Form form, BaseObject baseObject)
            : base(form, baseObject, 22)
        {
        }

        protected override void initializeImages()
        {
            Bitmaps = new Bitmap[this.Max_Frame];
            /*Bitmaps[0] = Properties.Resources.Zombie01;
            Bitmaps[1] = Properties.Resources.Zombie02;
            Bitmaps[2] = Properties.Resources.Zombie03;
            Bitmaps[3] = Properties.Resources.Zombie04;
            Bitmaps[4] = Properties.Resources.Zombie05;
            Bitmaps[5] = Properties.Resources.Zombie06;
            Bitmaps[6] = Properties.Resources.Zombie07;
            Bitmaps[7] = Properties.Resources.Zombie08;
            Bitmaps[8] = Properties.Resources.Zombie09;
            Bitmaps[9] = Properties.Resources.Zombie10;
            Bitmaps[10] = Properties.Resources.Zombie11;
            Bitmaps[11] = Properties.Resources.Zombie12;
            Bitmaps[12] = Properties.Resources.Zombie13;
            Bitmaps[13] = Properties.Resources.Zombie14;
            Bitmaps[14] = Properties.Resources.Zombie15;
            Bitmaps[15] = Properties.Resources.Zombie16;
            Bitmaps[16] = Properties.Resources.Zombie17;
            Bitmaps[17] = Properties.Resources.Zombie18;
            Bitmaps[18] = Properties.Resources.Zombie19;
            Bitmaps[19] = Properties.Resources.Zombie20;
            Bitmaps[20] = Properties.Resources.Zombie21;
            Bitmaps[21] = Properties.Resources.Zombie22;*/
        }
    }
}
