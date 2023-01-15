using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Zombie
{
    class BotanyBuilder: ICharacterBuilder
    {
        public BotanyBuilder(ICharacter character, System.Type t,  Point spawnPosition,int posRow,object fm) : base(character, t, spawnPosition,posRow,fm)
        {

        }

        public override void AddCharacterAnimate()
        {
            AnimateImage image = new AnimateImage(mForm, mCharacter);
            mCharacter.MAnim = image;
        }

        public override void AddCharacterAttr()
        {
            CharacterBaseAttr attr = FactoryManager.AttrFactory.GetCharacterBaseAttr(mT);
            ICharacterAttr iattr = new ICharacterAttr(attr, 100);
            mCharacter.Attr = iattr;
            mCharacter.Position = mSpawnPosition;
            mCharacter.PosRow = mPosRow;
        }

        public override void AddInCharacterSystem()
        {
            GameFacade.Insance.AddBotany (mCharacter as IBotany);
        }

        public override ICharacter GetResult()
        {
            return mCharacter;
        }
    }
}
