using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Zombie.Render
{
    class NbBulletRender : Render
    {
        public NbBulletRender(Form form, BaseObject baseObject)
            : base(form, baseObject, 1)
        {
        }
        protected override void initializeImages()
        {
            Bitmaps = new Bitmap[this.Max_Frame];
            Bitmaps[0] = Properties.Resources.PB00;

        }
    }
}
