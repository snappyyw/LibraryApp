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
    /// Логика взаимодействия для Reader.xaml
    /// </summary>
    public partial class ReaderWindow : Window
    {
        int _id;
        int _code = new Random().Next(100, 999);
        public ReaderWindow(int id)
        {
            Readers readers = LibraryDBEntities.GetContext().Readers.FirstOrDefault(p => p.IdUser == id);
            _id = readers.Id;
            InitializeComponent();
            DataGridBook.ItemsSource = LibraryDBEntities.GetContext().Books.Where(p => p.PublishedBooks == true&&p.IsBlocked==false).ToList();
            HistoryDataGrid.ItemsSource = LibraryDBEntities.GetContext().Journal.Where(p => p.IdReader == _id).ToList();
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
                    MessageBox.Show(_code + " Ваш талон");
                    LibraryDBEntities.GetContext().SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            HistoryDataGrid.ItemsSource = LibraryDBEntities.GetContext().Journal.Where(p => p.IdReader == _id).ToList();
        }
    }
}
