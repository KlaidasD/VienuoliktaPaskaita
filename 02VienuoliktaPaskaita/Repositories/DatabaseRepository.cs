using VienuoliktaPaskaita.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienuoliktaPaskaita.Models;
using System.Data.SqlClient;
using Dapper;

namespace VienuoliktaPaskaita.Repositories
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly string _connectionString;

        public DatabaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddAutomobilis(Automobilis automobilis)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("INSERT INTO Automobiliai (Marke, Modelis, Metai, RegistracijosNumeris) VALUES (@Marke, @Modelis, @Metai, @RegistracijosNumeris)", automobilis);
            }
        }

        public void UpdateAutomobilis(Automobilis automobilis)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("UPDATE Automobiliai SET Marke = @Marke, Modelis = @Modelis, Metai = @Metai, RegistracijosNumeris = @RegistracijosNumeris WHERE Id = @Id", automobilis);
            }
        }

        public Automobilis GetAutomobilisById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<Automobilis>("SELECT * FROM Automobiliai WHERE Id = @Id", new { Id = id });
            }
            
        }

        public IEnumerable<Automobilis> GetAllAutomobiliai()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Automobilis>("SELECT * FROM Automobiliai");
            }
        }

        public void DeleteAutomobilis(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("DELETE FROM Automobiliai WHERE Id = @Id", new { Id = id });
            }
        }

        public void RentAutomobilis(Nuoma nuoma)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("INSERT INTO Nuoma (AutomobilioId, KlientoId, Nuo, Iki) VALUES (@AutomobilioId, @KlientoId, @Nuo, @Iki)", nuoma);
            }
        }

        public IEnumerable<Nuoma> GetAllNuomos()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Nuoma>("SELECT * FROM Nuoma");
            }
        }
    }
}
