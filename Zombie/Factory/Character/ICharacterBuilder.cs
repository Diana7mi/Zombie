using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zombie
{
    public abstract class ICharacterBuilder
    {
        protected ICharacter mCharacter;
        protected System.Type mT;
        protected Point mSpawnPosition;
        protected int mPosRow;
        protected Form mForm;

        public ICharacterBuilder(ICharacter character, System.Type t, Point spawnPosition,int posRow,object fm)
        {
            mCharacter = character;
            mT = t;
            mSpawnPosition = spawnPosition;
            mForm = (Form)fm;
            mPosRow = posRow;
        }
        public abstract void AddCharacterAttr();
        public abstract void AddCharacterAnimate();
        public abstract void AddInCharacterSystem();
        public abstract ICharacter GetResult();
    }
}
