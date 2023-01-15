using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Zombie
{
    public class EnemyChaseState : IEnemyState
    {
        private Point mTargetPosition;

        public EnemyChaseState(EnemyFSMSystem fsm, ICharacter c) : base(fsm, c)
        {
            mStateID = EnemyStateID.Chase;
        }
        public override void DoBeforeEntering()
        {
            //mTargetPosition = GameFacade.Insance.GetEnemyTargetPosition();
            mTargetPosition = new Point(50, mCharacter.Position.Y);
        }
        public override void Act(List<ICharacter> targets)
        {
            //if (targets != null && targets.Count > 0)
            //{
            //    mCharacter.MoveTo(targets[0].Position.X);
           // }
           // else
           // {
                mCharacter.MoveTo(mTargetPosition.X);
           // }
        }

        public override void Reason(List<ICharacter> targets)
        {
            if (targets != null && targets.Count > 0)
            {
                //float distance = mCharacter.Position.X- targets[0].Position.X;
                //float distance = mCharacter.Position.X - 1198;
                int distance = 2000;
                int temp=2000;
                foreach (ICharacter t in targets)
                {
                    if(t.PosRow== mCharacter.PosRow)
                    {
                        temp = mCharacter.Position.X - t.Position.X;
                        if (distance > temp && temp>=0)
                            distance = temp;
                    }
                }
                if (distance <= mCharacter.AtkRange)
                {
                    mFSM.PerformTransition(EnemyTransition.CanAttack);
                }
            }
        }
    }
}
