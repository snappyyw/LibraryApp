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
        int _id;
        int _code = new Random().Next(100, 999);
        public LibrarianWindow(int id)
        {
            Readers readers = LibraryDBEntities.GetContext().Readers.FirstOrDefault(p => p.IdUser == id);
            _id = readers.Id;
            InitializeComponent();
            DataGridBook.ItemsSource = LibraryDBEntities.GetContext().Books.Where(p => p.IsBlocked == false).ToList();
            HistoryDataGrid.ItemsSource = LibraryDBEntities.GetContext().Journal.Where(p => p.IdReader == _id).ToList(); ;
            DataGridReader.ItemsSource = LibraryDBEntities.GetContext().Users.Where(p => p.Role == "Читатель").ToList();
            JourDataGrid.ItemsSource = LibraryDBEntities.GetContext().Journal.ToList();
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
            DataGridBook.ItemsSource = LibraryDBEntities.GetContext().Books.Where(p => p.IsBlocked == false).ToList();
            HistoryDataGrid.ItemsSource = LibraryDBEntities.GetContext().Journal.Where(p => p.IdReader == _id).ToList();
            DataGridReader.ItemsSource = LibraryDBEntities.GetContext().Users.Where(p => p.Role == "Читатель").ToList();
            JourDataGrid.ItemsSource = LibraryDBEntities.GetContext().Journal.ToList();
        }

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridBook.SelectedItems.Count > 0)
            {
                Books books = (Books)DataGridBook.SelectedItems[0];
                Journal journal = new Journal();
                journal.BookingStartDate = DateTime.Now;
                journal.BookingStatus = "Ожидает подтверждения";
                journal.IdBook = books.Id;
                journal.ReservationCode = _code;
                journal.IdReader = _id;
                try
                {
                    LibraryDBEntities.GetContext().Journal.Add(journal);
                    MessageBox.Show("Ваш талон "+_code );
                    LibraryDBEntities.GetContext().SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void EditBookbutton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridBook.SelectedItems.Count > 0)
            {
                Books books = (Books)DataGridBook.SelectedItems[0];
                AddingBookWindow addingBookWindow = new AddingBookWindow(books);
                addingBookWindow.Show();
            }
        }

        private void AddingButton_Click(object sender, RoutedEventArgs e)
        {
            AddingWindow addingWindow = new AddingWindow("Читатель");
            addingWindow.Show();
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

        private void RemovingReaderButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridReader.SelectedItems.Count > 0)
            {
                try
                {
                    Users users = (Users)DataGridReader.SelectedItems[0];
                    var reader = LibraryDBEntities.GetContext().Readers.FirstOrDefault(r => r.IdUser == users.Id);
                    if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        LibraryDBEntities.GetContext().Readers.Remove(reader);
                        LibraryDBEntities.GetContext().Users.Remove(users);
                        LibraryDBEntities.GetContext().SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void RemoveBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridBook.SelectedItems.Count > 0)
            {
                Books books =(Books) DataGridBook.SelectedItems[0];
                books.IsBlocked = true;
                if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    LibraryDBEntities.GetContext().SaveChanges();
            }
        }

        private void JourEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (JourDataGrid.SelectedItems.Count > 0)
            {
                Journal journal = (Journal)JourDataGrid.SelectedItems[0];
                JournalWindow journalWindow = new JournalWindow(journal);
                journalWindow.Show();
            }
        }

        private void RemovingJourButton_Click(object sender, RoutedEventArgs e)
        {
            if (JourDataGrid.SelectedItems.Count > 0)
            {
                try
                {
                    Journal journal = (Journal)JourDataGrid.SelectedItems[0];
                    LibraryDBEntities.GetContext().Journal.Remove(journal);
                    if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        LibraryDBEntities.GetContext().SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }
    }
}
