using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public class BotanyIdleState : IBotanyState
    {
        public BotanyIdleState(BotanyFSMSytem fsm, ICharacter c) : base(fsm, c)
        {
            mStateID = BotanyStateID.Idle;
        }
        public override void Act(List<ICharacter> targets)
        {
            mCharacter.Idle();
        }

        public override void Reason(List<ICharacter> targets)
        {
            if (targets.Count == 0) return;
            foreach (ICharacter item in targets)
            {
                if(item.PosRow == mCharacter.PosRow)
                {
                    mFSM.PerformTransition(BotanyTransition.SeeEnemy);
                    return;
                }
            }
            
        }
    }
}
