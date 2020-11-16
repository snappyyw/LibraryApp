using LibraryApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Logic
{
    class PointHelp
    {
        LibraryDBEntities libraryDBEntities = new LibraryDBEntities();
        public void PenaltyPoint(Journal journal)
        {
            if (journal.BookingStatus == 5)
            {
                Readers readers = libraryDBEntities.Readers.FirstOrDefault(p => p.Id == journal.IdReader);
                if (journal.BookingEndDate < DateTime.Now)
                {
                    Books books = libraryDBEntities.Books.FirstOrDefault(p => p.Id == journal.IdBook);


                    readers.ReaderRating = readers.ReaderRating - books.PenaltyPoint;
                }
                else
                {
                    readers.ReaderRating = readers.ReaderRating + 1;
                }
                libraryDBEntities.SaveChanges();
            }
        }
    }
}
