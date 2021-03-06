﻿using LibraryApp.Logic;
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
    /// Логика взаимодействия для AddingBookWindow.xaml
    /// </summary>
    public partial class AddingBookWindow : Window
    {
        LibraryDBEntities libraryDBEntities = new LibraryDBEntities();
        DBQueryHelp dBQuery = new DBQueryHelp();
        Books _books = new Books();
        public AddingBookWindow()
        {
            InitializeComponent();
            GenreComboBox.ItemsSource = libraryDBEntities.Genres.Select(s=>s.Genre).ToList();
            GenreComboBox.SelectedIndex = 0;
        }

        public AddingBookWindow(Books books)
        {
            InitializeComponent();
            _books.Id = books.Id;
            AuthorTextBox.Text = books.Author;
            IsPublicCheckBox.IsChecked = books.PublishedBooks;
            NameTextBox.Text = books.Name;
            InstancesTextBox.Text = books.NumberOfCopies.ToString();
            PointsTextBox.Text = books.PenaltyPoint.ToString();
            GenreComboBox.ItemsSource = libraryDBEntities.Genres.Select(s => s.Genre).ToList();
            GenreComboBox.SelectedIndex = books.BookGenre-1;
            DiskripTextBox.Text = books.Description;
            DateTextBox.Text = books.PublicationDate.ToString();
            TagsTextBox.Text = books.ToString();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModelCheck())
            {
                _books.Author = AuthorTextBox.Text;
                _books.IsBlocked = false;
                _books.PublishedBooks = (bool)IsPublicCheckBox.IsChecked;
                _books.Name = NameTextBox.Text;
                _books.NumberOfCopies = int.Parse(InstancesTextBox.Text);
                _books.PenaltyPoint = int.Parse(PointsTextBox.Text);
                _books.BookGenre = GenreComboBox.SelectedIndex+1;
                _books.Description = DiskripTextBox.Text;
                _books.PublicationDate = int.Parse(DateTextBox.Text);
                _books.Tags = TagsTextBox.Text;

                try
                {
                    if (_books.Id != 0)
                    {
                        Books tempBook = libraryDBEntities.Books.FirstOrDefault(u => u.Id == _books.Id);
                        tempBook.Author = AuthorTextBox.Text;
                        tempBook.Description = DiskripTextBox.Text;
                        tempBook.BookGenre = GenreComboBox.SelectedIndex+1;
                        tempBook.Name = NameTextBox.Text;
                        tempBook.NumberOfCopies = int.Parse(InstancesTextBox.Text);
                        tempBook.PenaltyPoint = int.Parse(PointsTextBox.Text);
                        tempBook.PublicationDate = int.Parse(DateTextBox.Text);
                        tempBook.PublishedBooks = (bool)IsPublicCheckBox.IsChecked;
                        tempBook.Tags = TagsTextBox.Text;
                        dBQuery.Update(libraryDBEntities);
                        MessageBox.Show("Данные изменены");
                    }
                    else
                    {
                        dBQuery.AddBook(_books);
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
            int a;
            StringBuilder error = new StringBuilder();
            if (AuthorTextBox.Text=="")
                error.AppendLine("Укажите автора");
            if (NameTextBox.Text=="")
                error.AppendLine("Укажите Название");
            if(!int.TryParse(InstancesTextBox.Text,out a))
                error.AppendLine("Укажите кол-во копий");
            if (!int.TryParse(PointsTextBox.Text, out a))
                error.AppendLine("Укажите штрафные очки");
            if (!int.TryParse(DateTextBox.Text, out a))
                error.AppendLine("Укажите дату публикации");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                error.Clear();
                return false;
            }
            else
                return true;
        }
    }
}
