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
    /// Логика взаимодействия для AddingWindow.xaml
    /// </summary>
    public partial class AddingWindow : Window
    {
        PassHelp passHelp = new PassHelp();
        LibraryDBEntities libraryDBEntities = new LibraryDBEntities();
        Readers _readers = new Readers();
         DBQueryHelp dBQuery = new DBQueryHelp();
        Users _user = new Users();
        public AddingWindow(string role)
        {
            InitializeComponent();
            _user.Role = role;
        }
        public AddingWindow(Users user, string role)
        {
            InitializeComponent();
            _user.Id = user.Id;
            _user.Role = role;
            LoginTextBox.Text=user.Login;
            PasswordTextBox.Text = user.Password;
            BlocCheckBox.IsChecked = user.IsBlocked;
            _readers = libraryDBEntities.Readers.FirstOrDefault(r => r.IdUser == user.Id);
            TelephoneTextBox.Text = _readers.Telephone;
            FIOTextBox.Text = _readers.FIO;
            BirthDatePiker.SelectedDate = _readers.DateOfBirth;
            EmpCheckBox.IsChecked = _readers.IsEmployee;
            RatingTextBox.Text =_readers.ReaderRating.ToString();
            _user = user;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModelCheck())
            {
                _user.Login = LoginTextBox.Text;
                _user.Password = passHelp.HashPassword(PasswordTextBox.Text);
                _user.IsBlocked = (bool)BlocCheckBox.IsChecked;
                _readers.FIO = FIOTextBox.Text;
                _readers.DateOfBirth = BirthDatePiker.SelectedDate;
                _readers.IsEmployee = (bool)EmpCheckBox.IsChecked;
                _readers.ReaderRating = int.Parse(RatingTextBox.Text);
                _readers.Telephone = TelephoneTextBox.Text;

                try
                {
                    if (_user.Id != 0)
                    {
                        Users tempUser = libraryDBEntities.Users.FirstOrDefault(u => u.Id == _user.Id);
                        tempUser.Login = _user.Login;
                        tempUser.Password = passHelp.HashPassword(_user.Password);
                        tempUser.Role = _user.Role;
                        tempUser.IsBlocked = _user.IsBlocked;
                        dBQuery.Update(libraryDBEntities);
                        MessageBox.Show("Данные изменены");
                    }
                    else
                    {
                        dBQuery.AddReaderAndUser(_readers,_user);
                        MessageBox.Show("Данные добавлены");
                    }
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }


        }
        private bool ModelCheck()
        {
            StringBuilder error = new StringBuilder();
            int a;
            if (LoginTextBox.Text=="")
                error.AppendLine("Укажите логин");
            if (PasswordTextBox.Text=="")
                error.AppendLine("Укажите пароль");
            if (!int.TryParse(RatingTextBox.Text, out a))
                error.AppendLine("Укажите рейтинг");
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
