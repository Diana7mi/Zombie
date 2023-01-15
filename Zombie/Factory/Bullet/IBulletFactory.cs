using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    public class IBulletFactory
    {
        public IBullet CreateBullet<T>( Point position, Point targetPosition, object fm) where T : IBullet, new()
        {
            IBullet bullet = new T();
            BulletBuilder builder = new BulletBuilder(bullet, typeof(T), position, targetPosition, fm);
            return BulletBuilderDirector.Construct(builder);

        }
    }
}
