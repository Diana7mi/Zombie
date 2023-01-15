using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    class BotanicRepeater : IBotany
    {
        private Point des;

        public BotanicRepeater()
        {
            idleimg = "images/Plants/Repeater/Repeater.gif";
            Image t = Image.FromFile(idleimg);
            imgwidth = t.Width;
            imgheight = t.Height;
            des = new Point();
        }
        protected override void PlayEffect()
        {
            throw new NotImplementedException();
        }
        public override void Attack(ICharacter target)
        {
            //System.Diagnostics.Debug.Assert(false, "生产子弹");
            des.X = Position.X + imgwidth / 2;
            des.Y = Position.Y;
            GameFacade.Insance.GetBullet(typeof(DoubleBullet), des, new Point(1300, Position.Y), GameFacade.Insance.Currform);
        }
        protected override void PlaySound()
        {
            throw new NotImplementedException();
        }
    }
    class BotanicWallNut : IBotany
    {

        private Point des;
        public BotanicWallNut()
        {
            idleimg = "images/Plants/WallNut/WallNut.gif";
            Image t = Image.FromFile(idleimg);
            imgwidth = t.Width;
            imgheight = t.Height;

        }
        protected override void PlayEffect()
        {
            throw new NotImplementedException();
        }
        public override void Attack(ICharacter target)
        {
            // System.Diagnostics.Debug.Assert(false, "生产子弹");
            // des.X = Position.X + imgwidth / 2;
            //des.Y = Position.Y;
            // GameFacade.Insance.GetBullet(typeof(SingleBullet), des, new Point(1300, Position.Y), GameFacade.Insance.Currform);
        }

        protected override void PlaySound()
        {
            throw new NotImplementedException();
        }
    }

    class BotanicSnowPea : IBotany
    {
        private Point des;

        public BotanicSnowPea()
        {
            idleimg = "images/Plants/SnowPea/SnowPea.gif";
            Image t = Image.FromFile(idleimg);
            imgwidth = t.Width;
            imgheight = t.Height;
            des = new Point();
        }
        protected override void PlayEffect()
        {
            throw new NotImplementedException();
        }
        public override void Attack(ICharacter target)
        {
            // System.Diagnostics.Debug.Assert(false, "生产子弹");
            des.X = Position.X + imgwidth / 2;
            des.Y = Position.Y;
            GameFacade.Insance.GetBullet(typeof(SingleBullet), des, new Point(1300, Position.Y), GameFacade.Insance.Currform);
        }
        protected override void PlaySound()
        {
            throw new NotImplementedException();
        }
    }

    class BotanicTallNut : IBotany
    {

        private Point des;
        public BotanicTallNut()
        {
            idleimg = "images/Plants/TallNut/TallNut.gif";
            Image t = Image.FromFile(idleimg);
            imgwidth = t.Width;
            imgheight = t.Height;

        }
        protected override void PlayEffect()
        {
            throw new NotImplementedException();
        }
        public override void Attack(ICharacter target)
        {
            // System.Diagnostics.Debug.Assert(false, "生产子弹");
            // des.X = Position.X + imgwidth / 2;
            //des.Y = Position.Y;
            // GameFacade.Insance.GetBullet(typeof(SingleBullet), des, new Point(1300, Position.Y), GameFacade.Insance.Currform);
        }

        protected override void PlaySound()
        {
            throw new NotImplementedException();
        }
    }

    class BotanicFumeShroom : IBotany
    {
        private Point des;

        public BotanicFumeShroom()
        {
            idleimg = "images/Plants/FumeShroom/FumeShroom.gif";
            Image t = Image.FromFile(idleimg);
            imgwidth = t.Width;
            imgheight = t.Height;
            des = new Point();
        }
        protected override void PlayEffect()
        {
            throw new NotImplementedException();
        }
        public override void Attack(ICharacter target)
        {
            // System.Diagnostics.Debug.Assert(false, "生产子弹");
            des.X = Position.X + imgwidth / 2;
            des.Y = Position.Y;
            GameFacade.Insance.GetBullet(typeof(NbBullet), des, new Point(1300, Position.Y), GameFacade.Insance.Currform);
        }
        protected override void PlaySound()
        {
            throw new NotImplementedException();
        }
    }

}
