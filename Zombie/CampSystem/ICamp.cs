using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    public class ICamp
    {
        protected CharacterName mBotanyType;
        protected float mTrainTime;
        protected List<ITrainCommand> mCommands;
        private float mTrainTimer = 0;
        public ICamp(CharacterName soldierType, float trainTime)
        {
            mBotanyType = soldierType;
            mTrainTime = trainTime;
            mTrainTimer = mTrainTime;
            mCommands = new List<ITrainCommand>();
        }
        public virtual void Update()
        {
            UpdateCommand();
        }
        private void UpdateCommand()
        {
            if (mCommands.Count <= 0) return;
            mTrainTimer -= 0.5f;
            if (mTrainTimer <= 0)
            {
                mCommands[0].Execute();
                mCommands.RemoveAt(0);
                mTrainTimer = mTrainTime;
            }
        }
        public virtual void Train(Point mPosition,int row)
        {
            TrainBotanyCommand cmd = new TrainBotanyCommand(mBotanyType, mPosition,row);//加入队列
            mCommands.Add(cmd);
        }
        public void CancelTrainCommand()
        {
            if (mCommands.Count > 0)
            {
                mCommands.RemoveAt(mCommands.Count - 1);
                if (mCommands.Count == 0)
                {
                    mTrainTimer = mTrainTime;
                }
            }
        }
        public int trainCount { get { return mCommands.Count; } }

        public float trainRemainingTime { get { return mTrainTimer; } }
    }
}
