using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public class BotanyAttackState : IBotanyState
    {
        private float mAttackTime = 5;
        private float mAttackTimer = 0;

        public BotanyAttackState(BotanyFSMSytem fsm, ICharacter c) : base(fsm, c)
        {
            mStateID = BotanyStateID.Attack;
            mAttackTimer = mAttackTime;
        }
        public override void Act(List<ICharacter> targets)
        {
            mCharacter.Idle();
            if (targets == null || targets.Count == 0) return;
            mAttackTimer += 0.5f;
            if (mAttackTimer >= mAttackTime)
            {
                mCharacter.Attack(null);
                mAttackTimer = 0;
            }
        }

        public override void Reason(List<ICharacter> targets)
        {
            bool flag = true;
            foreach (ICharacter item in targets)
            {
                if (item.PosRow == mCharacter.PosRow)
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                mFSM.PerformTransition(BotanyTransition.NoEnmey);
            }
        }
    }
}
