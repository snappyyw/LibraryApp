﻿using LibraryApp.Model;
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
    /// Логика взаимодействия для JournalWindow.xaml
    /// </summary>
    public partial class JournalWindow : Window
    {
        List<string> status = new List<string>() { "Ожидает подтверждения", "Принято", "Отказано", "Кинга передана читателю", "Возвращено" };
        int _id;
        public JournalWindow(Journal journal)
        {
            InitializeComponent();
            StatusComboBox.ItemsSource = status;
            StatusComboBox.SelectedIndex = 0;
            DateStart.SelectedDate = journal.BookingStartDate;
            DateEnd.SelectedDate = journal.BookingEndDate;
            StatusComboBox.SelectedItem = journal.BookingStatus;
            CodeTextBox.Text = journal.ReservationCode.ToString();
            _id = journal.Id;
        }

        private void EditJourButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModelCheck())
            {
                Journal journal = LibraryDBEntities.GetContext().Journal.FirstOrDefault(p => p.Id == _id);
                journal.BookingStartDate = (DateTime)DateStart.SelectedDate;
                journal.BookingEndDate = (DateTime)DateEnd.SelectedDate;
                journal.BookingStatus = StatusComboBox.SelectedItem.ToString();
                journal.ReservationCode = int.Parse(CodeTextBox.Text);

                if (journal.BookingStatus == "Возвращено")
                {
                    Readers readers = LibraryDBEntities.GetContext().Readers.FirstOrDefault(p => p.Id == journal.IdReader);
                    if (journal.BookingEndDate < DateTime.Now)
                    {
                        Books books = LibraryDBEntities.GetContext().Books.FirstOrDefault(p => p.Id == journal.IdBook);


                        readers.ReaderRating = readers.ReaderRating - books.PenaltyPoint;
                    }
                    else
                    {
                        readers.ReaderRating = readers.ReaderRating + 1;
                    }
                }
                try
                {
                    LibraryDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные изменены");
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
            if (DateStart.SelectedDate == null)
                error.AppendLine("Укажите дату начала");
            if (DateEnd.SelectedDate == null)
                error.AppendLine("Укажите дату конца");
            if (!int.TryParse(CodeTextBox.Text, out a))
                error.AppendLine("Укажите код");
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
