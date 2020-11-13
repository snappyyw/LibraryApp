using LibraryApp.Logic;
using LibraryApp.Model;
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
using System.Windows.Shapes;

namespace LibraryApp.View
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {

        PassHelp passHelp = new PassHelp();
        LibraryDBEntities libraryDBEntities = new LibraryDBEntities();
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            if (ModelCheck())
            {
                Users users = new Users
                {
                    IsBlocked = false,
                    Login = LoginTextBox.Text,
                    Role = "Читатель",
                    Password =passHelp.HashPassword(PasswordTextBox.Text),
                };
                try
                {
                    libraryDBEntities.Users.Add(users);
                    libraryDBEntities.SaveChanges();
                    PersonalDataWindow personalDataWindow = new PersonalDataWindow(users.Login);
                    personalDataWindow.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            
        }

        private void CreatePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            PasswordTextBox.Text = passHelp.GeneratePass();
        }

        private void labelBack_MouseEnter(object sender, MouseEventArgs e)
        {
            AuthorizationWindow mainWindow = new AuthorizationWindow();
            mainWindow.Show();
            this.Close();
        }

        private void labelTextBack_MouseEnter(object sender, MouseEventArgs e)
        {
            label1.Foreground = System.Windows.Media.Brushes.White;
            label2.Content += "Вернутьcя назад";
        }

        private void labelHidingBack_MouseLeave(object sender, MouseEventArgs e)
        {
            label1.Foreground = System.Windows.Media.Brushes.Black;
            label2.Content = "";
        }
        private bool ModelCheck()
        {
            StringBuilder error = new StringBuilder();
            if (LoginTextBox.Text=="")
                error.AppendLine("Укажите логин");
            if (PasswordTextBox.Text=="")
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
