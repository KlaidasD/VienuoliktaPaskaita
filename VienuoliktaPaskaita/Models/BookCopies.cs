using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VienuoliktaPaskaita.Models
{
    /*Susikurti testinius duomenis lentelėse Author, Books, BookCopies.
Susikurti duomenų struktūras pagal turimas lenteles.
Parašyti programą turinčią database servisą, kuriame būtų galimybė gauti visus autorius, knygas ir informaciją apie knygų kopijas.*/

    public class BookCopies
    {
        public int Id;
        public int BookId;
        public string Condition;
        public decimal Price;
        public int InStock;
    }
}
