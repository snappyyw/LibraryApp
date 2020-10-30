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
    /// Логика взаимодействия для Librarian.xaml
    /// </summary>
    public partial class LibrarianWindow : Window
    {
        public LibrarianWindow()
        {
            InitializeComponent();
            DataGridBook.ItemsSource = LibraryDBEntities.GetContext().Books.Where(p => p.PublishedBooks == true).ToList();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void AddintBookButton_Click(object sender, RoutedEventArgs e)
        {
            AddingBookWindow addingBookWindow = new AddingBookWindow();
            addingBookWindow.Show();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            DataGridBook.ItemsSource = LibraryDBEntities.GetContext().Books.Where(p => p.PublishedBooks == true).ToList();
        }
    }
}
