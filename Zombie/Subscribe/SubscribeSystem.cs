using System;
using System.Collections.Generic;
using System.Text;

namespace Zombie
{
    public enum GameEventType
    {
        Null,
        EnemyKilled,
        SoldierKilled,
        NewStage,
        GameOver
    }
    class SubscribeSystem : IGameSystem
    {
        private Dictionary<GameEventType, ISubject> mGameEvents = new Dictionary<GameEventType, ISubject>();
        public override void Init()
        {
            base.Init();
        }
        public void RegisterObserver(GameEventType eventType, IObserver observer)
        {
            ISubject sub = GetGameEventSub(eventType);
            if (sub == null) return;
            sub.RegisterObserver(observer);
            observer.SetSubject(sub);
        }
        public void RemoveObserver(GameEventType eventType, IObserver observer)
        {
            ISubject sub = GetGameEventSub(eventType);
            if (sub == null) return;
            sub.RemoveObserver(observer);
            observer.SetSubject(null);
        }
        private ISubject GetGameEventSub(GameEventType eventType)
        {
            if (mGameEvents.ContainsKey(eventType) == false)
            {
                switch (eventType)
                {
                    case GameEventType.EnemyKilled:
                        mGameEvents.Add(GameEventType.EnemyKilled, new EnemyKilledSubjectcs());
                        break;
                    case GameEventType.SoldierKilled:
                        //mGameEvents.Add(GameEventType.SoldierKilled, new SoldierKilledSubject());
                        break;
                    case GameEventType.NewStage:
                        //mGameEvents.Add(GameEventType.NewStage, new NewStageSubject());
                        break;
                    case GameEventType.GameOver:
                    //mGameEvents.Add(GameEventType.GameOver, new GameOverSubject());
                    default:
                         return null;
                }
            }
            return mGameEvents[eventType];
        }
        public void NotifySubject(GameEventType eventType)
        {
            ISubject sub = GetGameEventSub(eventType);
            if (sub == null) return;
            sub.Notify();
        }
    }
}
