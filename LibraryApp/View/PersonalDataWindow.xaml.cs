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
    /// Логика взаимодействия для PersonalDataWindow.xaml
    /// </summary>
    public partial class PersonalDataWindow : Window
    {
        string _login;
        public PersonalDataWindow(string login)
        {
            InitializeComponent();
            _login = login;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Readers readers = new Readers
            {
                FIO = FioTextBox.Text,
                Telephone = TelephoneTextBox.Text,
                ReaderRating = 5,
                IsEmployee = (bool)EmpCheckBox.IsChecked,
                DateOfBirth = Date.SelectedDate,
                IdUser = LibraryDBEntities.GetContext().Users.FirstOrDefault(u => u.Login == _login).Id
            };
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(readers.FIO))
                error.AppendLine("Укажите FIO");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            
            try
            {
                LibraryDBEntities.GetContext().Readers.Add(readers);
                LibraryDBEntities.GetContext().SaveChanges();
                ReaderWindow readerWindow = new ReaderWindow(readers.IdUser);
                readerWindow.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
