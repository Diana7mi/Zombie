using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public class BulletAttrFactory
    {
        private Dictionary<Type, BulletBaseAttr> mBulletBaseAttrDict;
        public BulletAttrFactory()
        {
            InitBulletBaseAttr();
        }
        private void InitBulletBaseAttr()
        {
            mBulletBaseAttrDict = new Dictionary<Type, BulletBaseAttr>();
           mBulletBaseAttrDict.Add(typeof(SingleBullet), new BulletBaseAttr(Bulletype.single,25, 10, 0, "images//Plants//PB-10.gif", "images//Plants//PeaBulletHit.gif"));
     
            mBulletBaseAttrDict.Add(typeof(DoubleBullet), new BulletBaseAttr(Bulletype.Double, 25, 10, 0, "images//Plants//PB00.gif", "images//Plants//PeaBulletHit.gif"));
            mBulletBaseAttrDict.Add(typeof(NbBullet), new BulletBaseAttr(Bulletype.Nb, 25, 10, 0, "images//Plants//ShroomBullet.gif", "images//Plants//ShroomBulletHit.gif"));
        }
        public BulletBaseAttr GetCharacterBaseAttr(Type t)
        {
            if (mBulletBaseAttrDict.ContainsKey(t) == false)
            {
                return null;
            }
            return mBulletBaseAttrDict[t];
        }
    }
}
