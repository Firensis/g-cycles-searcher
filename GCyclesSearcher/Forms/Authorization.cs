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
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }


        private void LoginBut_Click(object sender, EventArgs e)
        {
            string login = loginInp.Text;
            string password = passwordInp.Text;
            if (login == "" || password == "")
            {
                MessageBox.Show("Необходимо ввести логин и пароль!");
            }
            else
            {
                TryLogin(login, password);
            }
        }

        private void TryLogin(string login, string password)
        {
            try
            {
                UsersSystem.Login(login, password);
                FormsSystem.ChangeForm(new Menu());
            }
            catch (WrongUserDataException)
            {
                MessageBox.Show("Неверно введены логин или пароль!");
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
