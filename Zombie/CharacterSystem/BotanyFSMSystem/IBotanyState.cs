using System;
using System.Collections.Generic;
using System.Text;

public enum BotanyTransition
{
    NullTansition = 0,
    SeeEnemy,
    NoEnmey
}
public enum BotanyStateID
{
    NullState,
    Idle,
    Attack
}
namespace Zombie
{
    public abstract class IBotanyState
    {
        protected Dictionary<BotanyTransition, BotanyStateID> mMap = new Dictionary<BotanyTransition, BotanyStateID>();
        protected BotanyStateID mStateID;
        protected ICharacter mCharacter;
        protected BotanyFSMSytem mFSM;
        public IBotanyState(BotanyFSMSytem fsm, ICharacter character)
        {
            mFSM = fsm;
            mCharacter = character;
        }
        public BotanyStateID stateID { get { return mStateID; } }
        public void AddTransition(BotanyTransition trans, BotanyStateID id)
        {
            if (trans == BotanyTransition.NullTansition)
            {
                return;
            }
            if (id == BotanyStateID.NullState)
            {
                return;
            }
            if (mMap.ContainsKey(trans))
            {
                return;
            }
            mMap.Add(trans, id);
        }
        public void DeleteTransition(BotanyTransition trans)
        {
            if (mMap.ContainsKey(trans) == false)
            {
                return;
            }
            mMap.Remove(trans);
        }
        public BotanyStateID GetOutPutState(BotanyTransition trans)
        {
            if (mMap.ContainsKey(trans) == false)
            {
                return BotanyStateID.NullState;
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
