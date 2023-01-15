using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zombie
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;
            ISceneState state = new MainMenuState("Zombie.MainMenuForm");
           
            SceneStateController.controll = new SceneStateController(state);
            SceneStateController.controll.Mainform = this;
        }
    }
}
