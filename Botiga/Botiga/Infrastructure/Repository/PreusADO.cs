using Botiga.Entities;
using Botiga.Model;
using Botiga.Services;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace Botiga.Repository
{
    public class PreusADO()
    {
        public static Preu GetPreus(DatabaseConnection dbConn, Guid id)
        {

            dbConn.Open();
            string sql = "SELECT * FROM  Preu WHERE IdProducte = @IdProducte";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = cmd.ExecuteReader();
            Preu? preu= null;

            if (reader.Read())
            {
                preu = new Preu
                {
                    Id = reader.GetGuid(0),
                    IdProducte = reader.GetGuid(1),
                    dataPreu = reader.GetDateTime(2),
                    preu = reader.GetDecimal(3),
                };
            }

            dbConn.Close();
            return preu;
        }
    }
}
