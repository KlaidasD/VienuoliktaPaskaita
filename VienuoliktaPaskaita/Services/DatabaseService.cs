using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienuoliktaPaskaita.Models;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using Dapper;


namespace VienuoliktaPaskaita.Services
{
    /*Susikurti testinius duomenis lentelėse Author, Books, BookCopies.
Susikurti duomenų struktūras pagal turimas lenteles.
Parašyti programą turinčią database servisą, kuriame būtų galimybė gauti visus autorius, knygas ir informaciją apie knygų kopijas.*/

    public class DatabaseService : IDatabaseService
    {
        private readonly string _connectionString;
        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void DeleteRecord(int recordId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = "DELETE FROM Book WHERE ID = @RecordIdToDelete;";
                db.Execute(sql, new { RecordIdToDelete = recordId });
            }
        }

        public void InsertObject(Book newBook)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = "INSERT INTO Books (Title, Genre, PublicationYear, AuthorId) VALUES (@Title, @Genre, @PublicationYear, @AuthorId)";
                db.Execute(sql, newBook);
            }
        }

        public IEnumerable<Authors> GetAuthors()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                SELECT *
                FROM Authors";
                return db.Query<Authors>(sql);
            }
        }

        public IEnumerable<Book> GetBookDetails()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                SELECT *
                FROM Books";
                return db.Query<Book>(sql);
            }
        }

        public IEnumerable<BookCopies> GetBooksCopy()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                SELECT *
                FROM BookCopies";
                return db.Query<BookCopies>(sql);
            }
        }

       
    }
}