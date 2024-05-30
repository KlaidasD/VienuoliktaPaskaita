using System;
using VienuoliktaPaskaita.Models;
using VienuoliktaPaskaita.Services;

namespace VienuoliktaPaskaita
{
    public class Program
    {
        /*Susikurti testinius duomenis lentelėse Author, Books, BookCopies.
Susikurti duomenų struktūras pagal turimas lenteles.
Parašyti programą turinčią database servisą, kuriame būtų galimybė gauti visus autorius, knygas ir informaciją apie knygų kopijas.*/

        public static void Main(string[] args)
        {
            IDatabaseService databaseService = new DatabaseService("Server=DESKTOP-9849SKM;Database=PirmaDB;Integrated Security=True;");

            Console.WriteLine("Iveskite Knygos Pavadinima, Zanra, isleidimo data ir AuthorID: ");
            Book newBook = new Book {Title = Console.ReadLine(), Genre = Console.ReadLine(), PublicationYear = int.Parse(Console.ReadLine()), AuthorID = int.Parse(Console.ReadLine()) };
            databaseService.InsertObject(newBook);

            List<Book> bookDetails = (databaseService.GetBookDetails()).ToList();

            foreach (Book bookinfo in bookDetails)
            {
                Console.WriteLine($"{bookinfo.Id} {bookinfo.Title}  {bookinfo.PublicationYear} {bookinfo.Genre} {bookinfo.AuthorID} ");
            }

            List<Authors> authorDetails = (databaseService.GetAuthors()).ToList();

            foreach (Authors authorinfo in authorDetails)
            {
                Console.WriteLine($"{authorinfo.Id} {authorinfo.FirstName}  {authorinfo.LastName} {authorinfo.BirthDate} {authorinfo.Country} ");
            }

            List<BookCopies> bookCopyDetails = (databaseService.GetBooksCopy()).ToList();

            foreach (BookCopies bookCopyinfo in bookCopyDetails)
            {
                Console.WriteLine($"{bookCopyinfo.Id} {bookCopyinfo.BookId}  {bookCopyinfo.Condition} {bookCopyinfo.Price} {bookCopyinfo.InStock} ");
            }
        }
    }
}