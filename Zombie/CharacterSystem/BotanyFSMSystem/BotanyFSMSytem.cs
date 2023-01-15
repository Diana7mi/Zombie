using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public class BotanyFSMSytem
    {
        private List<IBotanyState> mStates = new List<IBotanyState>();

        private IBotanyState currentState;
        public IBotanyState CurrentState { get { return currentState; } }

        public void AddState(params IBotanyState[] states)
        {
            foreach (IBotanyState s in states)
            {
                AddState(s);
            }
        }
        public void AddState(IBotanyState state)
        {
            if (state == null)
            {
                return;
            }
            if (mStates.Count == 0)
            {
                mStates.Add(state);
                currentState = state;
                return;
            }
            foreach (IBotanyState s in mStates)
            {
                if (s.stateID == state.stateID)
                {
                   return;
                }
            }
            mStates.Add(state);
        }
        public void DeleteState(BotanyStateID stateID)
        {
            if (stateID == BotanyStateID.NullState)
            {
               return;
            }
            foreach (IBotanyState s in mStates)
            {
                if (s.stateID == stateID)
                {
                    mStates.Remove(s);
                    return;
                }
            }
        }
        public void PerformTransition(BotanyTransition trans)
        {
            if (trans == BotanyTransition.NullTansition)
            {
               return;
            }
            BotanyStateID nextStateID = CurrentState.GetOutPutState(trans);
            if (nextStateID == BotanyStateID.NullState)
            {
                return;
            }
            foreach (IBotanyState s in mStates)
            {
                if (s.stateID == nextStateID)
                {
                    currentState.DoBeforeLeaving();
                    currentState = s;
                    currentState.DoBeforeEntering();
                    return;
                }
            }
        }
    }
}
