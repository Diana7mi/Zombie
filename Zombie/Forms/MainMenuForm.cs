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
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SceneStateController.controll.Request();
        }


        private void MainMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();
            //Application.ExitThread();
            //SceneStateController.controll.Mainform.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            SceneStateController.controll.Mainform.Close();
        }
    }
}
