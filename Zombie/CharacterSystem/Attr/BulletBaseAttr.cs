using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public enum Bulletype
    {
        single,
        Double,
        Nb,
    }
    public class BulletBaseAttr
    {
        private int moveSpeed;
        private int damage;
        private int range;
        private string flyimg;
        private string boomimg;
        private Bulletype mtype;

        public BulletBaseAttr(Bulletype itype,int speed,int damage,int range,string flyimg,string boomimg)
        {
            this.mtype = itype;
            this.moveSpeed = speed;
            this.damage = damage;
            this.range = range;
            this.flyimg = flyimg;
            this.boomimg = boomimg;
        }

        public string Flyimg
        {
            get
            {
                return flyimg;
            }
        }

        public string Boomimg
        {
            get
            {
                return boomimg;
            }
        }

        public int MoveSpeed
        {
            get
            {
                return moveSpeed;
            }
        }

        public int Damage
        {
            get
            {
                return damage;
            }
        }

        public int Range
        {
            get
            {
                return range;
            }
        }
    }
}
