using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie
{
    public class ICharacterAttr
    {
        private CharacterBaseAttr mBaseAttr;
        private int mCurrentHP;

        public CharacterBaseAttr MBaseAttr { get => mBaseAttr; }
        public int MCurrentHP { get => mCurrentHP; set => mCurrentHP = value; }

        public ICharacterAttr(CharacterBaseAttr BaseAttr,int CurrentHP)
        {
            mBaseAttr = BaseAttr;
            MCurrentHP = CurrentHP;
        }
        public void TakeDamage(int damage)
        {
            damage -= MBaseAttr.DmgDescValue;
            if (damage < 5) damage = 5;
            MCurrentHP -= damage;
        }
    }
}
