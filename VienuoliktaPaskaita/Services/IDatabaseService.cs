using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienuoliktaPaskaita.Models;

namespace VienuoliktaPaskaita.Services
{
    /*Susikurti testinius duomenis lentelėse Author, Books, BookCopies.
Susikurti duomenų struktūras pagal turimas lenteles.
Parašyti programą turinčią database servisą, kuriame būtų galimybė gauti visus autorius, knygas ir informaciją apie knygų kopijas.*/

    public interface IDatabaseService
    {
        IEnumerable<Book> GetBookDetails();

        IEnumerable<Authors> GetAuthors();

        IEnumerable<BookCopies> GetBooksCopy();
        void DeleteRecord(int recordId);

        void InsertObject(Book newBook);

    }
}
