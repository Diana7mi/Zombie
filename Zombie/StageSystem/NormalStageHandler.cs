using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    public class NormalStageHandler : IStageHandler
    {
        private CharacterName mEnemyType;
        private int mCount;
        private Point mPosition;
        private float speed;
        private int mSpawnTime = 5;
        private float mSpawnTimer = 0;
        private int mCountSpawned = 0;
        public NormalStageHandler(StageSystem stageSystem, int lv, int countToFinished, CharacterName et, int count, float speed)
            : base(stageSystem, lv, countToFinished)
        {
            mEnemyType = et;
            mCount = count;
            mSpawnTimer = mSpawnTime;
            this.speed = speed;
        }
        protected override void UpdateStage()
        {
            base.UpdateStage();
            if (mCountSpawned < mCount)
            {
                mSpawnTimer -= speed;
                if (mSpawnTimer <= 0)
                {
                    SpawnEnemy();
                    mSpawnTimer = mSpawnTime;
                }
            }
        }
        void SpawnEnemy()
        {
            mCountSpawned++;
            int t;
            t=new Random().Next(0, GameFacade.Insance.enyrowPos.Length);
            mPosition = new Point(1300, GameFacade.Insance.enyrowPos[t]);
            switch (mEnemyType)
            {
                case CharacterName.nZombie:
                    FactoryManager.EnemyFactory.CreateCharacter<EnemyZombie>(mPosition,t, GameFacade.Insance.Currform);
                    break;
                case CharacterName.nBucketheadZombie:
                    FactoryManager.EnemyFactory.CreateCharacter<BucketheadZombie>(mPosition, t, GameFacade.Insance.Currform);
                    break;
                case CharacterName.nFlagZombie:
                    FactoryManager.EnemyFactory.CreateCharacter<FlagZombie>(mPosition, t, GameFacade.Insance.Currform);
                    break;
                default:
                    break;
            }
        }
    }
}
