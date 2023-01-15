using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    
    public abstract class IBullet
    {
        protected BulletBaseAttr attr;
        private bool activa;
        private Point position;
        private Point targetPosition;
        private Rectangle area;
        private int imgheight;
        private int imgwidth;
        private int directionX;
        private int directionY;
        private AnimateImage mAnim;
        private string currimg;
        protected float mDestroyTimer;
        private bool mCanDestroy;
        public AnimateImage MAnim
        {
            get {
                return mAnim;
            }
            set
            {
                mAnim = value;
            }
        }
        public bool Activa
        {
            get
            {
                return activa;
            }

            set
            {
                activa = value;
            }
        }

        public BulletBaseAttr Attr
        {
            get
            {
                return attr;
            }

            set
            {
                attr = value;
            }
        }

        public bool MCanDestroy
        {
            get
            {
                return mCanDestroy;
            }
        }

        public Point Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public IBullet()
        {
            /*this.attr = ar;
            SetActive(position,targetPosition);
            Image bm=Image.FromFile(attr.Flyimg);
            this.imgheight = bm.Height;
            this.imgwidth = bm.Width;
            bm.Dispose();*/
        }
        public void SetActive(Point position, Point targetPosition)
        {
            mDestroyTimer = 1f;
            mCanDestroy = false;

            this.position = position;
            this.targetPosition = targetPosition;
            if (position.X - targetPosition.X > 0)
                directionX = -1;
            else if (position.X - targetPosition.X < 0)
                directionX = 1;
            else
                directionX = 0;

            if (position.Y - targetPosition.Y > 0)
                directionY = -1;
            else if (position.Y - targetPosition.Y < 0)
                directionY = 1;
            else
                directionY = 0;

            if (directionX == -1)
                area = new Rectangle(targetPosition.X, targetPosition.Y, position.X - targetPosition.X, position.Y - targetPosition.Y);
            else
                area = new Rectangle(position.X-1, position.Y-1, targetPosition.X - position.X, targetPosition.Y - position.Y+2);
            Image bm = Image.FromFile(attr.Flyimg);
            this.imgheight = bm.Height;
            this.imgwidth = bm.Width;
            bm.Dispose();
            Activa = true;
            
        }

        public virtual void Attack(ICharacter target)
        {
            PlayAnim(attr.Boomimg);//播放动画
            target.UnderAttack(attr.Damage);
        }
        public void PlayAnim(string animName)
        {
            if (currimg != animName)
            {
                currimg = animName;
                mAnim.changeImage(animName);
            }
        }
        public virtual void FlyTo()
        {
            position.X = position.X + attr.MoveSpeed*directionX;
            position.Y = position.Y + attr.MoveSpeed * directionY;
            PlayAnim(attr.Flyimg);
        }
        public bool  CheckCross(Rectangle r1, Rectangle r2)
        {
            PointF c1 = new PointF(r1.Left + r1.Width / 2.0f, r1.Top + r1.Height / 2.0f);
            PointF c2 = new PointF(r2.Left + r2.Width / 2.0f, r2.Top + r2.Height / 2.0f);
            return (Math.Abs(c1.X - c2.X) <= r1.Width / 2.0 + r2.Width / 2.0 && Math.Abs(c2.Y - c1.Y) <= r1.Height / 2.0 + r2.Height / 2.0);
        }
        public virtual void UpdateCollsion(List<ICharacter> targets)
        {
            if (!activa) return;
            Rectangle rc = new Rectangle(position.X+imgwidth/2, position.Y+imgheight/2, imgwidth/2, imgheight/2);
            foreach (ICharacter item in targets)
            {
                if(CheckCross(rc, new Rectangle(item.Position.X+ item.Imgwidth / 2+10, item.Position.Y,item.Imgwidth/2,item.Imgheight)))
                {
                    Attack(item);
                    activa = false;
                    //GameFacade.Insance.RemoveBullet(this);
                    break;
                }
            }
        }
        public void Update()
        {
            if (!activa)
            {
                mDestroyTimer -= 0.5f;
                if (mDestroyTimer <= 0)
                {
                    mCanDestroy = true;
                }
                return;
            }
            if (area.Contains(position))
            {
                FlyTo();
            }
            else
            {
                activa = false;
            }
        }
    }
}
