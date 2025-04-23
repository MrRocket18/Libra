using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjectLIB
{
    public partial class Authorization : Form 
    {

        public Authorization() 
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void Authorization_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click_1(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            User current = new User();
            current = current.FindUserByLogin(username, password);
            if (current!=null)
            {
                if (current.Role != "Admin")
                {
                    if(current.Role != "Librarian")
                    {
                        MessageBox.Show($"Вы читатель! {current.Role}", "Вход", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    {
                        (string FullName, string group) = current.GetFullNameAndGroupById(current.Id);
                        this.Hide();
                        MenuLib menu = new MenuLib(FullName);
                        menu.FormClosed += (object s, FormClosedEventArgs ev) => { this.Show(); };
                        menu.Show();
                        usernameTextBox.Text = "";
                        passwordTextBox.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Вы Админ!", "Вход", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


           
        }
        private void Authorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
    

}

