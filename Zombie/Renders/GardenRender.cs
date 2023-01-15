using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Zombie.Render
{
    class GardenRender:Render
    {
        public GardenRender(Form form, BaseObject obj)
            : base(form, obj, 1)
        {
        }

        protected override void initializeImages()
        {
            Bitmaps = new Bitmap[Max_Frame];
            Bitmaps[0] = Properties.Resources.background1;
        }
    }
}
