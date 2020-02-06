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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void ToPrevBut_Click(object sender, EventArgs e)
        {
            FormsSystem.ChangeForm(new Menu());
            Hide();
        }

        private void RegisterBut_Click(object sender, EventArgs e)
        {
            string login = loginInp.Text;
            string password = passwordInp.Text;

            if (login == "" || password == "")
            {
                MessageBox.Show("Необходимо ввести логин и пароль добавляемого пользователя!");
            }
            else if (TryCreate(login, password))
            {
                MessageBox.Show($"ПОльзователь {login} успешно создан!");
                loginInp.Text = "";
                passwordInp.Text = "";
                loginInp.Focus();
            }
            else
            {
                MessageBox.Show($"Пользователь с логином {login} уже присутствует в системе!");
            }
        }

        private bool TryCreate(string login, string password)
        {
            try
            {
                UsersSystem.CreateUser(login, password);
                return true;
            }
            catch (UserExistsException)
            {
                return false;
            }
        }
    }
}
