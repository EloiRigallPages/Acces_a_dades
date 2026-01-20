using Botiga.Model;
using Botiga.Services;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Botiga.Repository
{
    public class CarroDeLaCompraADO
    {
        public static void Insert(DatabaseConnection dbConn, CarroDeLaCompra CarroDeLaCompra)
        {

            dbConn.Open();

            string sql = @"INSERT INTO CarroDeLaCompra (Id, IdCarro, IdProduct, Quantitat)
                        VALUES (@Id, @IdCarro, @IdProduct, @Quantitat)";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", CarroDeLaCompra.Id);
            cmd.Parameters.AddWithValue("@IdCarro", CarroDeLaCompra.IdCarro);
            cmd.Parameters.AddWithValue("@IdProduct", CarroDeLaCompra.IdProducte);
            cmd.Parameters.AddWithValue("@Quantitat", CarroDeLaCompra.Quantitat);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"{rows} fila inserida.");
            dbConn.Close();
        }

        public static List<CarroDeLaCompra> GetAll(DatabaseConnection dbConn, Guid id)
        {
            List<CarroDeLaCompra> CarroDeLaCompra = new();

            dbConn.Open();
            string sql = "SELECT Id, IdCarro, IdProduct, Quantitat FROM CarroDeLaCompra WHERE IdCarro = @Id";
        

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CarroDeLaCompra.Add(new CarroDeLaCompra
                {
                    Id = reader.GetGuid(0),
                    IdCarro = reader.GetGuid(1),
                    IdProducte = reader.GetGuid(2),
                    Quantitat = reader.GetInt32(3)
                });
            }

            dbConn.Close();
            return CarroDeLaCompra;
        }

        public static CarroDeLaCompra? GetById(DatabaseConnection dbConn, Guid id)
        {
            dbConn.Open();
            string sql = "SELECT Id, IdCarro, IdProduct, Quantitat FROM CarroDeLaCompra WHERE Id = @Id";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = cmd.ExecuteReader();
            CarroDeLaCompra? product = null;

            if (reader.Read())
            {
                product = new CarroDeLaCompra
                {
                    Id = reader.GetGuid(0),
                    IdCarro = reader.GetGuid(1),
                    IdProducte = reader.GetGuid(2),
                    Quantitat = reader.GetInt32(3)
                };
            }

            dbConn.Close();
            return product;
        }
    }
}
