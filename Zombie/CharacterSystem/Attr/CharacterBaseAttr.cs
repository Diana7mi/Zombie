using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie
{
    
    public  class CharacterBaseAttr
    { 
        private int maxHP;
        private int moveSpeed;
        private int dmgDescValue;
        private string name;
        private int damage;

        public CharacterBaseAttr(string name, int maxHP, int moveSpeed,int DmgDescValue,int damage)
        {
            this.name = name;
            this.maxHP = maxHP;
            this.moveSpeed = moveSpeed;
            this.dmgDescValue = DmgDescValue;
            this.damage = damage;
        }
        public int MaxHP { get { return maxHP; } }
        public int MoveSpeed { get { return moveSpeed; } }
        public int DmgDescValue { get { return dmgDescValue; } }
        public string Name { get { return name; } }
        public int Damage { get { return damage; } }
    }
}
