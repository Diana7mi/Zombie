using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zombie
{
    class BulletBuilder
    {
        protected IBullet mBullet;
        protected System.Type mT;
        protected Point position;
        protected Point targetPosition;
        protected Form mForm;
        public BulletBuilder(IBullet bullet ,Type t, Point position, Point targetPosition, object fm)
        {
            this.mBullet = bullet;
            this.mT = t;
            this.position = position;
            this.targetPosition = targetPosition;
            this.mForm = (Form)fm;
        }
        public  void AddBulletAnimate()
        {
            AnimateImage anmin = new AnimateImage(mForm, mBullet);
            mBullet.MAnim = anmin;
            anmin.changeImage(mBullet.Attr.Flyimg);

        }
        public  void AddBulletAtrr()
        {
            BulletBaseAttr attr = FactoryManager.BulletAttrFactory.GetCharacterBaseAttr(mT);
            mBullet.Attr = attr;
            mBullet.SetActive(position, targetPosition);
        }
        public  void AddInCharacterSystem()
        {
            GameFacade.Insance.AddBullet(mBullet as IBullet);
        }
        public IBullet GetResult()
        {
            return mBullet;
        }
    }
}
