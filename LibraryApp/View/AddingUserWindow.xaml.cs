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
        List<string> role = new List<string>() { "Библиотекарь", "Читатель" };
        Readers _readers = new Readers();
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
            _user.Id = user.Id;
            RoleComboBox.ItemsSource = role;
            RoleComboBox.SelectedIndex = 0;
            LoginTextBox.Text=user.Login;
            PasswordTextBox.Text = user.Password;
            BlocCheckBox.IsChecked = user.IsBlocked;
            RoleComboBox.SelectedIndex = 0;
            _readers = LibraryDBEntities.GetContext().Readers.FirstOrDefault(r => r.IdUser == user.Id);
            TelephoneTextBox.Text = _readers.Telephone;
            FIOTextBox.Text = _readers.FIO;
            BirthDatePiker.SelectedDate = _readers.DateOfBirth;
            EmpCheckBox.IsChecked = _readers.IsEmployee;
            RatingTextBox.Text =_readers.ReaderRating.ToString();
            _user = user;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _user.Login = LoginTextBox.Text;
            _user.Password = PasswordTextBox.Text;
            _user.IsBlocked = (bool)BlocCheckBox.IsChecked;
            _user.Role = RoleComboBox.SelectedItem.ToString();
            _readers.FIO = FIOTextBox.Text;
            _readers.DateOfBirth = BirthDatePiker.SelectedDate;
            _readers.IsEmployee = (bool)EmpCheckBox.IsChecked;
            _readers.ReaderRating =int.Parse(RatingTextBox.Text);
            _readers.Telephone = TelephoneTextBox.Text;

            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(_user.Login))
                error.AppendLine("Укажите логин");
            if (string.IsNullOrEmpty(_user.Password))
                error.AppendLine("Укажите пароль");
            if (error.Length > 0)
                MessageBox.Show(error.ToString());
            try
            {
               if(_user.Id != 0)
                {
                    Users tempUser = LibraryDBEntities.GetContext().Users.FirstOrDefault(u => u.Id == _user.Id);
                    tempUser.Login = _user.Login;
                    tempUser.Password = _user.Password;
                    tempUser.Role = _user.Role;
                    tempUser.IsBlocked = _user.IsBlocked;
                    LibraryDBEntities.GetContext().SaveChanges();
                }
                else
                {
                    LibraryDBEntities.GetContext().Users.Add(_user);
                    LibraryDBEntities.GetContext().SaveChanges();
                    Users users = LibraryDBEntities.GetContext().Users.FirstOrDefault(u => u.Login == _user.Login);
                    _readers.IdUser = users.Id;
                    LibraryDBEntities.GetContext().Readers.Add(_readers);
                    LibraryDBEntities.GetContext().SaveChanges();
                }
               this.Close();

            }
            catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }


        }
    }
}
