using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    class EnemyAttackState:IEnemyState
    {
        private float mAttackTime = 1;
        private float mAttackTimer = 1;
        public EnemyAttackState(EnemyFSMSystem fsm, ICharacter c) : base(fsm, c)
        {
            mStateID = EnemyStateID.Attack;
            mAttackTimer = mAttackTime;
        }

        public override void Act(List<ICharacter> targets)
        {
            if (targets == null || targets.Count == 0) return;
            mAttackTimer += 0.1f;
            if (mAttackTimer >= mAttackTime)
            {
                //mCharacter.Attack(targets[0]);
                foreach (ICharacter t in targets)
                {
                    if (t.PosRow == mCharacter.PosRow)
                    {
                        int temp =mCharacter.Position.X - t.Position.X;
                        if ( temp<=mCharacter.AtkRange && temp>0)
                            mCharacter.Attack(t);
                    }
                }
                mAttackTimer = 0;
            }
        }

        public override void Reason(List<ICharacter> targets)
        {
            
            if (targets == null || mCharacter.Position.X <=50)
            {
                mFSM.PerformTransition(EnemyTransition.LostSoldier);
            }
            else
            {
                float distance =2000;
                int temp;
                foreach (ICharacter t in targets)
                {
                    if (t.PosRow == mCharacter.PosRow)
                    {
                        temp = mCharacter.Position.X - t.Position.X;
                        if (distance > temp && temp>=0)
                            distance = temp;
                    }
                }

                if (distance > mCharacter.AtkRange )
                {
                    mFSM.PerformTransition(EnemyTransition.LostSoldier);
                }
            }
        }

    }
}
