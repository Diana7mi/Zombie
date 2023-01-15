using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace Zombie
{
    public abstract class ICharacter
    {
        protected ICharacterAttr attr;
        protected bool mIsKilled = false;
        protected bool mCanDestroy = false;
        protected float mDestroyTimer = 2f;
        private Point position;
        private int  posRow;
        private int atkRange;
        private AnimateImage mAnim;
        private string stateImage;
        protected string attackimg;
        protected string chaseimg;
        protected string idleimg;
        protected int imgheight;
        protected int imgwidth;

        public ICharacterAttr Attr { set { attr = value; } get { return attr; } }
        public bool canDestroy { get { return mCanDestroy; } }
        public bool isKilled { get { return mIsKilled; } }
        public Point Position { get => position; set => position = value; }
        public int AtkRange { get => atkRange; set => atkRange = value; }
        public string StateImage { get => stateImage; set => stateImage = value; }
        public AnimateImage MAnim { get => mAnim; set => mAnim = value; }
        public int PosRow {
            get { return posRow; }
            set {posRow = value;}
        }

        public int Imgheight
        {
            get
            {
                return imgheight;
            }

        }

        public int Imgwidth
        {
            get
            {
                return imgwidth;
            }
        }

        public ICharacter()
        {
        }
        public void Update()
        {
            if (mIsKilled)
            {
                mDestroyTimer -= 0.5f;
                if (mDestroyTimer <= 0)
                {
                    mCanDestroy = true;
                }
            }
        }
        public abstract void UpdateFSMAI(List<ICharacter> targets);
        public virtual void Attack(ICharacter target)
        {
            PlayAnim(attackimg);//播放动画
            target.UnderAttack(attr.MBaseAttr.Damage);
        }
        public virtual void UnderAttack(int damage)
        {
            attr.TakeDamage(damage);
        }
        public virtual void Killed()
        {
            mIsKilled = true;
        }
        public void Release()
        {
            //GameObject.Destroy(mGameObject);
        }
        public void PlayAnim(string animName)
        {
            if (StateImage != animName)
            {
                StateImage = animName;
                MAnim.changeImage(animName);
            }  
        }
        public int GetSpeed()
        {
            return attr.MBaseAttr.MoveSpeed;
        } 
        public void MoveTo(int targetPosition)
        {
            if (position.X > targetPosition)
            {
                position.X=position.X - GetSpeed();
            }
            PlayAnim(chaseimg);
        }
        public void Idle()
        {
            PlayAnim(idleimg);
        }
    }
}
