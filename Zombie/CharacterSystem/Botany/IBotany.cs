using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    public abstract class IBotany : ICharacter
    {
        protected BotanyFSMSytem mFSMSystem;

        public IBotany()
        {
            MakeFSM();
        }

        private void MakeFSM()
        {
            mFSMSystem = new BotanyFSMSytem();

            BotanyIdleState idleState = new BotanyIdleState(mFSMSystem, this);
            idleState.AddTransition(BotanyTransition.SeeEnemy, BotanyStateID.Attack);

            BotanyAttackState attackState = new BotanyAttackState(mFSMSystem, this);
            attackState.AddTransition(BotanyTransition.NoEnmey, BotanyStateID.Idle);

            mFSMSystem.AddState(idleState, attackState);
        }
        public override void UpdateFSMAI(List<ICharacter> targets)
        {
            if (mIsKilled) return;
            mFSMSystem.CurrentState.Reason(targets);
            mFSMSystem.CurrentState.Act(targets);
        }
        public override void UnderAttack(int damage)
        {
            if (mIsKilled) return;
            base.UnderAttack(damage);

            if (Attr.MCurrentHP <= 0)
            {
                //PlaySound();
                //PlayEffect();
                Killed();
            }
        }
        public override void Killed()
        {
            base.Killed();
            //GameFacade.Insance.NotifySubject(GameEventType.SoldierKilled);
        }
        protected abstract void PlaySound();
        protected abstract void PlayEffect();
    }
}
