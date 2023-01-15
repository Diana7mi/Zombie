using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public enum EnemyTransition
    {
        NullTansition = 0,
        CanAttack,
        LostSoldier,
        WillDead
    }
    public enum EnemyStateID
    {
        NullState,
        WillDead,
        Chase,
        Attack
    }
    public abstract class IEnemyState
    {
        protected Dictionary<EnemyTransition, EnemyStateID> mMap = new Dictionary<EnemyTransition, EnemyStateID>();
        protected EnemyStateID mStateID;
        protected ICharacter mCharacter;
        protected EnemyFSMSystem mFSM;

        public IEnemyState(EnemyFSMSystem fsm, ICharacter character)
        {
            mFSM = fsm;
            mCharacter = character;
        }
        public EnemyStateID stateID { get { return mStateID; } }
        public void AddTransition(EnemyTransition trans, EnemyStateID id)
        {
            if (trans == EnemyTransition.NullTansition)
            {
               return;
            }
            if (id == EnemyStateID.NullState)
            {
               return;
            }
            if (mMap.ContainsKey(trans))
            {
               return;
            }
            mMap.Add(trans, id);
        }
        public void DeleteTransition(EnemyTransition trans)
        {
            if (mMap.ContainsKey(trans) == false)
            {
                return;
            }
            mMap.Remove(trans);
        }
        public EnemyStateID GetOutPutState(EnemyTransition trans)
        {
            if (mMap.ContainsKey(trans) == false)
            {
                return EnemyStateID.NullState;
            }
            else
            {
                return mMap[trans];
            }
        }
        public virtual void DoBeforeEntering() { }
        public virtual void DoBeforeLeaving() { }
        public abstract void Reason(List<ICharacter> targets);
        public abstract void Act(List<ICharacter> targets);
    }
}
