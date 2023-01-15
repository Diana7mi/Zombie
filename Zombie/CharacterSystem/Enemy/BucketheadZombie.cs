using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    class BucketheadZombie : IEnemy
    {

        public BucketheadZombie()
        {
            AtkRange = 10;
            attackimg = "images/Zombies/BucketheadZombie/BucketheadZombieAttack.gif";
            chaseimg = "images/Zombies/BucketheadZombie/BucketheadZombie.gif";
            Image bm = Image.FromFile(chaseimg);
            base.imgheight = bm.Height;
            base.imgwidth = bm.Width;
            bm.Dispose();
        }
        public override void PlayEffect()
        {
            throw new NotImplementedException();
        }
    }
}
