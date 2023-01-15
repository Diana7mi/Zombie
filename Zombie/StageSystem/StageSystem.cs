using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public class StageSystem: IGameSystem
    {
        int mLv = 1;
        private int mCountOfEnemyKilled=0;
        IStageHandler mRootHandler;
        public int countOfEnemyKilled
        {
            set
            {
                mCountOfEnemyKilled = value;
            }
        }
        public override void Init()//中介者模式
        {
            base.Init();
            InitStageChain();
            mFacade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKilledObserverStageSystem(this));
        }

        public override void Update()
        {
            base.Update();
            mRootHandler.Handle(mLv);
        }

        private void InitStageChain()
        {

            int lv = 1;
            NormalStageHandler handler1 = new NormalStageHandler(this, lv++, 3, CharacterName.nBucketheadZombie, 6, 0.05f);
            NormalStageHandler handler2 = new NormalStageHandler(this, lv++, 6, CharacterName.nFlagZombie, 24, 0.05f);
            NormalStageHandler handler3 = new NormalStageHandler(this, lv++, 100, CharacterName.nZombie, 100, 1f);


            handler1.SetNextHandler(handler2)
                .SetNextHandler(handler3);
            mRootHandler = handler1;
        }
        public int CountOfEnemyKilled
        {
            set
            {
                mCountOfEnemyKilled = value;
            }
        }
        public int GetCountOfEnemyKilled()
        {
            return mCountOfEnemyKilled;
        }
        public void EnterNextStage()
        {
            
            mLv++;
           // mFacade.NotifySubject(GameEventType.NewStage);
        }
    }
}
