using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Zombie
{
    public class MainMenuState: ISceneState
    {     
        public MainMenuState(string formty):base(formty){
            StartState();
        }

        public override void EndState()
        {
            //throw new NotImplementedException();
            myform.Close();
        }

        public override void Handle(SceneStateController context)
        {
            context.MState = new BattleState("Zombie.BattleForm");
        }

        public override void StartState()
        {
            // throw new NotImplementedException();
            myform.Visible = true;
        }
    }
}
