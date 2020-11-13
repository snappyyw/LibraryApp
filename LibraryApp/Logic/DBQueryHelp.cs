using LibraryApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Logic
{
    class DBQueryHelp
    {
        LibraryDBEntities libraryDBEntities = new LibraryDBEntities();
        public void AddReaderAndUser(Readers reader, Users user)
        {
            libraryDBEntities.Users.Add(user);
            libraryDBEntities.SaveChanges();
            Users users = libraryDBEntities.Users.FirstOrDefault(u => u.Login == user.Login);
            reader.IdUser = users.Id;
            libraryDBEntities.Readers.Add(reader);
            libraryDBEntities.SaveChanges();
        }
        public void Update(LibraryDBEntities libraryDBEntities)
        {
            libraryDBEntities.SaveChanges();
        }
        public void AddBook(Books book)
        {
            libraryDBEntities.Books.Add(book);
            libraryDBEntities.SaveChanges();
        }
        public void RemovingUser(Readers reader, Users user)
        {
            libraryDBEntities.Readers.Remove(reader);
            libraryDBEntities.Users.Remove(user);
            libraryDBEntities.SaveChanges();
        }
        public void RemovingJournal(Journal journal)
        {
            libraryDBEntities.Journal.Remove(journal);
            libraryDBEntities.SaveChanges();
        }
        public void AddReader(Readers reader)
        {
            libraryDBEntities.Readers.Add(reader);
            libraryDBEntities.SaveChanges();
        }
        public void AddJournal(Journal journal)
        {
            libraryDBEntities.Journal.Add(journal);
            libraryDBEntities.SaveChanges();
        }
        public void AddUser(Users users)
        {
            libraryDBEntities.Users.Add(users);
            libraryDBEntities.SaveChanges();
        }
    }
}
