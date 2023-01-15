using System;
using System.Collections.Generic;
using System.Text;

namespace Zombie
{
    class BulletBuilderDirector
    {
        public static IBullet Construct(BulletBuilder builder)
        {
            builder.AddBulletAtrr();
            builder.AddBulletAnimate();
            builder.AddInCharacterSystem();
            return builder.GetResult();
        }
    }
}
