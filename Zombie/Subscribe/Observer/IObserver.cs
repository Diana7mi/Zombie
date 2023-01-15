using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public interface IObserver//观察者模式，委托的概念
    {
          void Update();
          void SetSubject(ISubject sub);
    }
}
