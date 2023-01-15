using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    class EnemyZombie : IEnemy
    {
        
        public EnemyZombie()
        {
            AtkRange = 10;
            attackimg = "images/Zombies/Zombie/ZombieAttack.gif";
            chaseimg = "images/Zombies/Zombie/Zombie.gif";
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
