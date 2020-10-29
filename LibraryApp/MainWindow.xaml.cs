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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonEntrance_Click(object sender, RoutedEventArgs e)
        {
            List<Users> users = LibraryDBEntities.GetContext().Users.ToList();
            bool found = false;
            foreach (var user in users)
            {
                if (textBoxLogin.Text == user.Login && passwordBox.Password == user.Password && user.IsBlocked!=true)
                {
                    switch (user.Role)
                    {
                        case "Читатель":
                            ReaderWindow reader = new ReaderWindow(user.Id);
                            found = true;
                            reader.Show();
                            this.Close();
                            break;
                        case "Библиотекарь":
                            LibrarianWindow librarian = new LibrarianWindow();
                            found = true;
                            librarian.Show();
                            this.Close();
                            break;
                        case "Администратор":
                            AdministratorWindow administrator = new AdministratorWindow();
                            found = true;
                            administrator.Show();
                            this.Close();
                            break;
                    }
                }
            }
            if (found == false)
                MessageBox.Show("Пойманы за руку как дешевка");
        }

        private void buttonRegistration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registration = new RegistrationWindow();
            registration.Show();
            this.Close();
        }

        
    }
}
