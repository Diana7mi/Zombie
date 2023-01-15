using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public abstract class ISubject
    {
        private List<IObserver> mObservers = new List<IObserver>();//抽象目标

        public void RegisterObserver(IObserver ob)
        {
            mObservers.Add(ob);//添加观察者
        }
        public void RemoveObserver(IObserver ob)
        {
            mObservers.Remove(ob);//移除
        }
        public virtual void Notify()
        {
            foreach (IObserver ob in mObservers)
            {
                ob.Update();//更新，修改，通知观察者
            }
        }
    }
}
