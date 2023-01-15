using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Zombie
{
    public class SceneStateController
    {
        private ISceneState mState;
        private Form mainform;
        public static SceneStateController controll;
        public ISceneState MState { get => mState; set => mState = value; }
        public Form Mainform { get => mainform; set => mainform = value; }

        public SceneStateController(ISceneState state)
        {
            this.MState = state;
        }
        public void Request()
        {
            if (mState != null)
            {
                mState.EndState();
            }
            
            mState.Handle(this);
        }
    }
}
