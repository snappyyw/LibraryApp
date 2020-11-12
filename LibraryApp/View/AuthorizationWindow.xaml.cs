using LibraryApp.Model;
using LibraryApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        LibraryDBEntities LibraryDBEntities = new LibraryDBEntities();
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void buttonEntrance_Click(object sender, RoutedEventArgs e)
        {
            if (ModelCheck())
            {
                try
                {
                    Users users = LibraryDBEntities.Users.FirstOrDefault(p => p.Login == textBoxLogin.Text && p.Password == passwordBox.Password);
                    if (users.IsBlocked == true)
                    {
                        MessageBox.Show("Дешевка заблокирована");
                        return;
                    }
                    switch (users.Role.ToLower())
                    {
                        case "читатель":
                            ReaderWindow reader = new ReaderWindow(users.Id);
                            reader.Show();
                            this.Close();
                            break;
                        case "библиотекарь":
                            LibrarianWindow librarian = new LibrarianWindow(users.Id);
                            librarian.Show();
                            this.Close();
                            break;
                        case "администратор":
                            AdministratorWindow administrator = new AdministratorWindow();
                            administrator.Show();
                            this.Close();
                            break;
                    }
                }
                catch
                {
                    MessageBox.Show("Пойманы за руку как дешевка");
                }
            }
        }

        private void buttonRegistration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registration = new RegistrationWindow();
            registration.Show();
            this.Close();
        }
        private bool ModelCheck()
        {
            StringBuilder error = new StringBuilder();
            if (textBoxLogin.Text == "")
                error.AppendLine("Укажите логин");
            if (passwordBox.Password == "")
                error.AppendLine("Укажите пароль");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return false;
            }
            else
                return true;
        }

    }
}
