using GCyclesSearcher.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCyclesSearcher.Forms
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            addUsers.Visible = UsersSystem.IsCurrentAdmin;
        }

        private void AddUsers_Click(object sender, EventArgs e)
        {
            FormsSystem.ChangeForm(new Registration());
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FormsSystem.ChangeForm(new CyclesSearch());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FormsSystem.ChangeForm(new StepsVisualizer());
        }

        private void CycleSearchInfo_Click(object sender, EventArgs e)
        {
            HelpInfo.ShowFindCyclesHelp();
        }

        private void StepCyclesSearchInfo_Click(object sender, EventArgs e)
        {
            HelpInfo.ShowStepFindCyclesHelp();
        }

        private void CreateGraph_Click(object sender, EventArgs e)
        {
            FormsSystem.ChangeForm(new GraphCreator());
        }

        private void CreateGraphInfo_Click(object sender, EventArgs e)
        {
            HelpInfo.ShowCreateGraphHelp();
        }
    }
}
