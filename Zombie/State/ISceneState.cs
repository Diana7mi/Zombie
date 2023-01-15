using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;//反射的引用

namespace Zombie
{
    public abstract class ISceneState
    {
        protected Form myform;   
        public ISceneState(string formname)
        {
            Type type = Type.GetType(formname);
            myform =(Form) Activator.CreateInstance(type);//这里创建
        }
        public Form GetForm() {
            return myform;
        }
        public abstract void StartState();
        public abstract void EndState();
        public abstract void Handle(SceneStateController context);
    }
}
