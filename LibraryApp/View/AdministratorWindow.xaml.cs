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
        public AdministratorWindow()
        {
            InitializeComponent();
            DataGridReader.ItemsSource = LibraryDBEntities.GetContext().Users.Where(p => p.Role == "Читатель").ToList();
            DataGridLibrarian.ItemsSource = LibraryDBEntities.GetContext().Users.Where(p => p.Role == "Библиотекарь").ToList();
        }

        private void AddingButton_Click(object sender, RoutedEventArgs e)
        {
            AddingWindow addingWindow = new AddingWindow();
            addingWindow.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
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
                    LibraryDBEntities.GetContext().Users.Remove(users);
                    LibraryDBEntities.GetContext().SaveChanges();
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
                    LibraryDBEntities.GetContext().Users.Remove(users);
                    LibraryDBEntities.GetContext().SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            DataGridReader.ItemsSource = LibraryDBEntities.GetContext().Users.Where(p => p.Role == "Читатель").ToList();
            DataGridLibrarian.ItemsSource = LibraryDBEntities.GetContext().Users.Where(p => p.Role == "Библиотекарь").ToList();
        }

        private void ReaderEditButton_Click(object sender, RoutedEventArgs e)
        {
            Users user = null;
            if (DataGridReader.SelectedItems.Count > 0)
                user = (Users)DataGridReader.SelectedItems[0];
            AddingWindow addingWindow = new AddingWindow(user);
            addingWindow.Show();
        }

        private void LibrarianEditButton_Click(object sender, RoutedEventArgs e)
        {
            Users user = null;
            if (DataGridLibrarian.SelectedItems.Count > 0)
                user = (Users)DataGridLibrarian.SelectedItems[0];
            AddingWindow addingWindow = new AddingWindow(user);
            addingWindow.Show();
        }
    }
}
