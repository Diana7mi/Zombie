using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public class EnemyFSMSystem
    {
        private List<IEnemyState> mStates = new List<IEnemyState>();

        private IEnemyState currentState;
        public IEnemyState CurrentState { get { return currentState; } }
        public void AddState(params IEnemyState[] states)
        {
            foreach (IEnemyState s in states)
            {
                AddState(s);
            }
        }
        public void AddState(IEnemyState state)
        {
            if (state == null)
            {
                return;
            }
            if (mStates.Count == 0)
            {
                mStates.Add(state);
                currentState = state;
                currentState.DoBeforeEntering();
                return;
            }
            foreach (IEnemyState s in mStates)
            {
                if (s.stateID == state.stateID)
                {
                    return;
                }
            }
            mStates.Add(state);
        }
        public void DeleteState(EnemyStateID stateID)
        {
            if (stateID == EnemyStateID.NullState)
            {
                return;
            }
            foreach (IEnemyState s in mStates)
            {
                if (s.stateID == stateID)
                {
                    mStates.Remove(s);
                    return;
                }
            }
           
        }
        public void PerformTransition(EnemyTransition trans)
        {
            if (trans == EnemyTransition.NullTansition)
            {
                return;
            }
            EnemyStateID nextStateID = currentState.GetOutPutState(trans);
            if (nextStateID == EnemyStateID.NullState)
            {
                return;
            }
            foreach (IEnemyState s in mStates)
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
