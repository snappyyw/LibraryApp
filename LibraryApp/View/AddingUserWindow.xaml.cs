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
    /// Логика взаимодействия для AddingWindow.xaml
    /// </summary>
    public partial class AddingWindow : Window
    {
        List<string> role = new List<string>() { "Администратор", "Библиотекарь", "Читатель" };
        Users _user = new Users();
        public AddingWindow()
        {
            InitializeComponent();
            RoleComboBox.ItemsSource = role;
            RoleComboBox.SelectedIndex = 0;
        }
        public AddingWindow(Users user)
        {
            InitializeComponent();
            user.Id = user.Id;
            RoleComboBox.ItemsSource = role;
            LoginTextBox.Text=user.Login;
            PasswordTextBox.Text = user.Password;
            BlocCheckBox.IsChecked = user.IsBlocked;
            RoleComboBox.SelectedIndex = 0;

            _user = user;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _user.Login = LoginTextBox.Text;
            _user.Password = PasswordTextBox.Text;
            _user.IsBlocked = (bool)BlocCheckBox.IsChecked;
            _user.Role = RoleComboBox.SelectedItem.ToString();
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(_user.Login))
                error.AppendLine("Укажите логин");
            if (string.IsNullOrEmpty(_user.Password))
                error.AppendLine("Укажите пароль");
            if (error.Length > 0)
                MessageBox.Show(error.ToString());
            try
            {
               
               LibraryDBEntities.GetContext().Users.Add(_user);
               LibraryDBEntities.GetContext().SaveChanges();
               this.Close();

            }
            catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }


        }
    }
}
