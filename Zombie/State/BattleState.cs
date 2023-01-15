using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Zombie
{
    class BattleState:ISceneState
    {
        public BattleState(string formty):base(formty)
        {
            StartState();
        }

        public override void EndState()
        {
            GameFacade.Insance.Release();
            myform.Close();
            
        }

        public override void Handle(SceneStateController context)
        {
            context.MState = new MainMenuState("Zombie.MainMenuForm");
        }

        public override void StartState()
        {
            myform.Visible = true;
        }
        

    }
}
