using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    class EnemyKilledSubjectcs:ISubject//观察僵尸被杀数量  主题角色  抽象目标
    {
        private int mKilledCount = 0;

        public int killedCount { get { return mKilledCount; } }

        public override void Notify()
        {
            mKilledCount++;
            base.Notify();
        }
    }
}
