using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Zombie
{
    public abstract class IEnemy : ICharacter
    {
        protected EnemyFSMSystem mFSMSystem;
        
        public IEnemy() 
        {
            MakeFSM();
        }
        public override void UpdateFSMAI(List<ICharacter> targets)
        {
            if (mIsKilled) return;
            mFSMSystem.CurrentState.Reason(targets);
            mFSMSystem.CurrentState.Act(targets);
        }
        private void MakeFSM()
        {
            mFSMSystem = new EnemyFSMSystem();

            EnemyChaseState chaseState = new EnemyChaseState(mFSMSystem, this);
            chaseState.AddTransition(EnemyTransition.CanAttack, EnemyStateID.Attack);

            EnemyAttackState attackState = new EnemyAttackState(mFSMSystem, this);
            attackState.AddTransition(EnemyTransition.LostSoldier, EnemyStateID.Chase);

            mFSMSystem.AddState(chaseState, attackState);
        }
        public override void UnderAttack(int damage)
        {
            if (mIsKilled) return;
            base.UnderAttack(damage);
            //PlayEffect();
            if (Attr.MCurrentHP <= 0)
            {
                Killed();
            }
        }
        public abstract void PlayEffect();

        public override void Killed()
        {
            base.Killed();
            GameFacade.Insance.NotifySubject(GameEventType.EnemyKilled);
        }
    }
}
