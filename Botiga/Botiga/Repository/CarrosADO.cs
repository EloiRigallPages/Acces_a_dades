using Botiga.Model;
using Botiga.Services;
using Microsoft.Data.SqlClient;

namespace Botiga.Repository
{
    public class CarrosADO
    {
        public static void Insert(DatabaseConnection dbConn, Familia product)
        {

            dbConn.Open();

            string sql = @"INSERT INTO Products (Id, Code, Name, Price)
                        VALUES (@Id, @Code, @Name, @Price)";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", product.Id);
            cmd.Parameters.AddWithValue("@Code", product.Code);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Price", product.Price);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"{rows} fila inserida.");
            dbConn.Close();
        }

        public static List<Familia> GetAll(DatabaseConnection dbConn)
        {
            List<Familia> products = new();

            dbConn.Open();
            string sql = "SELECT Id, Code, Name, Price FROM Products";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new Familia
                {
                    Id = reader.GetGuid(0),
                    Code = reader.GetString(1),
                    Name = reader.GetString(2),
                    Price = reader.GetDecimal(3)
                });
            }

            dbConn.Close();
            return products;
        }

        public static Familia? GetById(DatabaseConnection dbConn, Guid id)
        {
            dbConn.Open();
            string sql = "SELECT Id, Code, Name, Price FROM Products WHERE Id = @Id";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = cmd.ExecuteReader();
            Familia? product = null;

            if (reader.Read())
            {
                product = new Familia
                {
                    Id = reader.GetGuid(0),
                    Code = reader.GetString(1),
                    Name = reader.GetString(2),
                    Price = reader.GetDecimal(3)
                };
            }

            dbConn.Close();
            return product;
        }
    }
}
