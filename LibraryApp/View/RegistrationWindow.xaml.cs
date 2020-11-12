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
                    Password = PasswordTextBox.Text,
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
            Random random = new Random();
            var partOne = Enumerable.Range(0, 1).Select(x => (char)random.Next('A', 'Z' + 1));
            var partTwo = Enumerable.Range(0, 4).Select(x => (char)random.Next('a', 'z' + 1));
            var partThree = Enumerable.Range(0, 3).Select(x => (char)random.Next('!', '/' + 1));
            var partFour = Enumerable.Range(0,1).Select(x => (char)random.Next('0', '9' + 1));

            PasswordTextBox.Text = string.Concat(partOne.Concat(partTwo).Concat(partThree).Concat(partFour));
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
