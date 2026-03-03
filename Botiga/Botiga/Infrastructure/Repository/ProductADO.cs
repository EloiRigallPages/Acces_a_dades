using Microsoft.Data.SqlClient;
using static System.Console;
using Botiga.Services;
using Botiga.Model;

namespace Botiga.Repository
{
    public class ProductADO
    {
        public static void Insert(DatabaseConnection dbConn, Product product)
        {
            dbConn.Open();

            string sql = @"INSERT INTO Product (Id, Nom, Descripcio, Preu, Descompte, IdFamilia)
                           VALUES (@Id, @Nom, @Descripcio, @Preu, @Descompte, @IdFamilia)";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", product.Id);
            cmd.Parameters.AddWithValue("@Nom", product.Nom);
            cmd.Parameters.AddWithValue("@Descripcio", product.Descripcio);
            cmd.Parameters.AddWithValue("@Preu", product.Preu);
            cmd.Parameters.AddWithValue("@Descompte", product.Descompte);
            cmd.Parameters.AddWithValue("@IdFamilia", product.IdFamilia);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"{rows} fila inserida.");
            dbConn.Close();
        }

        public static List<Product> GetAll(DatabaseConnection dbConn)
        {
            List<Product> products = new();

            dbConn.Open();
            string sql = "SELECT Id, Nom, Descripcio, Preu, Descompte, IdFamilia FROM Product";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = reader.GetGuid(0),
                    Nom = reader.GetString(1),
                    Descripcio = reader.GetString(2),
                    Preu = reader.GetDecimal(3),
                    Descompte = reader.GetInt32(4),
                    IdFamilia = reader.GetGuid(5)
                });
            }

            dbConn.Close();
            return products;
        }

        public static Product? GetById(DatabaseConnection dbConn, Guid id)
        {
            dbConn.Open();
            string sql = "SELECT Id, Nom, Descripcio, Preu, Descompte, IdFamilia FROM Product WHERE Id = @Id";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = cmd.ExecuteReader();
            Product? product = null;

            if (reader.Read())
            {
                product = new Product
                {
                    Id = reader.GetGuid(0),
                    Nom = reader.GetString(1),
                    Descripcio = reader.GetString(2),
                    Preu = reader.GetDecimal(3),
                    Descompte = reader.GetInt32(4),
                    IdFamilia = reader.GetGuid(5)
                };
            }

            dbConn.Close();
            return product;
        }
    }
}
