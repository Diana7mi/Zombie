using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    class TrainBotanyCommand : ITrainCommand
    {
        CharacterName mBotanyType;
        Point mPosition;
        int RowPos;
        public TrainBotanyCommand(CharacterName st, Point pos,int rowPos)
        {
            mBotanyType = st;
            mPosition = pos;
            RowPos = rowPos;
        }
        public void Execute()//训练初始化
        {
            switch (mBotanyType)
            {
                case CharacterName.nRepeater:
                    FactoryManager.BotanyFactory.CreateCharacter<BotanicRepeater>(mPosition, RowPos, GameFacade.Insance.Currform);
                    break;
                case CharacterName.nWallNut:
                    FactoryManager.BotanyFactory.CreateCharacter<BotanicWallNut>(mPosition, RowPos, GameFacade.Insance.Currform);
                    break;
                case CharacterName.nSnowPea:
                    FactoryManager.BotanyFactory.CreateCharacter<BotanicSnowPea>(mPosition, RowPos, GameFacade.Insance.Currform);
                    break;
                case CharacterName.nTallNut:
                    FactoryManager.BotanyFactory.CreateCharacter<BotanicTallNut>(mPosition, RowPos, GameFacade.Insance.Currform);
                    break;
                case CharacterName.nFumeShroom:
                    FactoryManager.BotanyFactory.CreateCharacter<BotanicFumeShroom>(mPosition, RowPos, GameFacade.Insance.Currform);
                    break;

                default:
                    break;
            }
        }
    }
   

}
