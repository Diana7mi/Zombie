using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    public class CampSystem:IGameSystem
    {
        private Dictionary<CharacterName, ICamp> mBotanyCamps = new Dictionary<CharacterName, ICamp>();
        public override void Init()
        {
            base.Init();
            InitCamp(CharacterName.nRepeater);
            InitCamp(CharacterName.nWallNut);
            InitCamp(CharacterName.nSnowPea);
            InitCamp(CharacterName.nTallNut);
            InitCamp(CharacterName.nFumeShroom);

        }
        private void InitCamp(CharacterName botanyType)
        {
            float trainTime = 0;
            switch (botanyType)
            {
                case CharacterName.nRepeater:
                    trainTime = 3;
                        break;
                case CharacterName.nWallNut:
                    trainTime = 3;
                    break;
                case CharacterName.nSnowPea:
                    trainTime = 3;
                    break;
                case CharacterName.nTallNut:
                    trainTime = 3;
                    break;
                case CharacterName.nFumeShroom:
                    trainTime = 3;
                    break;

                default:
                    break;
            }
            ICamp camp = new ICamp(botanyType, trainTime);
            mBotanyCamps.Add(botanyType, camp);
        }
        public override void Update()
        {
            //更新所有兵营内部游戏逻辑
            foreach (ICamp camp in mBotanyCamps.Values)
            {
                camp.Update();
            }
        }
        public void SetCampCommand(CharacterName name,Point pt,int row)
        {
            mBotanyCamps[name].Train(pt,row);
        }
    }
}
