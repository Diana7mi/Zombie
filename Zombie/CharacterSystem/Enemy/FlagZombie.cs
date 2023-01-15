using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    class FlagZombie : IEnemy
    {

        public FlagZombie()
        {
            AtkRange = 10;
            attackimg = "images/Zombies/FlagZombie/FlagZombieAttack.gif";
            chaseimg = "images/Zombies/FlagZombie/FlagZombie.gif";
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
