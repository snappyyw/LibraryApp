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
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        LibraryDBEntities libraryDBEntities = new LibraryDBEntities();
        DBQueryHelp dBQuery = new DBQueryHelp();
        public AdministratorWindow()
        {
            InitializeComponent();
            DataGridReader.ItemsSource = libraryDBEntities.Users.Where(p => p.Role == "Читатель").ToList();
            DataGridLibrarian.ItemsSource = libraryDBEntities.Users.Where(p => p.Role == "Библиотекарь").ToList();
        }

        private void AddingReaderButton_Click(object sender, RoutedEventArgs e)
        {
            AddingWindow addingWindow = new AddingWindow("Читатель");
            addingWindow.Show();
        }
        private void AddingLibrarianButton_Click(object sender, RoutedEventArgs e)
        {
            AddingWindow addingWindow = new AddingWindow("Библиотекарь");
            addingWindow.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow mainWindow = new AuthorizationWindow();
            mainWindow.Show();
            this.Close();
        }

        private void RemovingLibrarianButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridLibrarian.SelectedItems.Count > 0)
            {
                try
                {
                    Users users = (Users)DataGridLibrarian.SelectedItems[0];
                    var reader = libraryDBEntities.Readers.FirstOrDefault(r => r.IdUser == users.Id);
                    if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        dBQuery.RemovingUser(reader, users);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

        }

        private void RemovingReaderButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridReader.SelectedItems.Count > 0)
            {
                try
                {
                    Users users = (Users)DataGridReader.SelectedItems[0];
                    var reader = libraryDBEntities.Readers.FirstOrDefault(r => r.IdUser == users.Id);
                    if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        dBQuery.RemovingUser(reader, users);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            DataGridReader.ItemsSource = libraryDBEntities.Users.Where(p => p.Role == "Читатель").ToList();
            DataGridLibrarian.ItemsSource = libraryDBEntities.Users.Where(p => p.Role == "Библиотекарь").ToList();
        }

        private void ReaderEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridReader.SelectedItems.Count > 0)
            {
                Users user = (Users)DataGridReader.SelectedItems[0];
                AddingWindow addingWindow = new AddingWindow(user, "Читатель");
                addingWindow.Show();
            }
        }

        private void LibrarianEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridLibrarian.SelectedItems.Count > 0)
            {
                Users user = (Users)DataGridLibrarian.SelectedItems[0];
                AddingWindow addingWindow = new AddingWindow(user, "Библиотекарь");
                addingWindow.Show();
            }
        }
    }
}
