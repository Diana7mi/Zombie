using System;
using System.Collections.Generic;
using System.Text;

namespace Zombie
{
    class EnemyKilledObserverStageSystem : IObserver//僵尸死亡观察者系统
    {
        private EnemyKilledSubjectcs mSubject;
        private StageSystem mStageSystem;
        public EnemyKilledObserverStageSystem(StageSystem ss)
        {
            mStageSystem = ss;
        }

        public  void Update()
        {
            mStageSystem.countOfEnemyKilled = mSubject.killedCount;
            //Debug.Log("Update:" + mSubject.killedCount);
        }

        public  void SetSubject(ISubject sub)
        {
            mSubject = sub as EnemyKilledSubjectcs;
        }
    }
}
