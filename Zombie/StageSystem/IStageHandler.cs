using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public abstract class IStageHandler
    {
        protected int mLv;
        private int mCountToFinished;
        protected StageSystem mStageSystem;
        protected IStageHandler mNextHandler;
        public IStageHandler(StageSystem stageSystem, int lv, int countToFinished)
        {
            mStageSystem = stageSystem;
            mLv = lv;
            mCountToFinished = countToFinished;
        }
        public IStageHandler SetNextHandler(IStageHandler handler)
        {
            mNextHandler = handler;
            return mNextHandler;
        }
        public void Handle(int level)
        {
            if (level == mLv)
            {
                UpdateStage();
                CheckIsFinished();//检查关卡是否结束
            }
            else
            {
                mNextHandler.Handle(level);
            }
        }
        protected virtual void UpdateStage() { }
        private void CheckIsFinished()
        {
            if (mStageSystem.GetCountOfEnemyKilled() >= mCountToFinished)
            {
                mStageSystem.EnterNextStage();
            }
        }
    }
}
