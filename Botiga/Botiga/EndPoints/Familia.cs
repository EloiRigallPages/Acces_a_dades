using Botiga.Repository;
using Botiga.Services;
using Botiga.Model;

namespace Botiga.EndPoints
{
    public static class EndPointFamilia
    {
        public static void MapFamiliaEndpoints(this WebApplication app, DatabaseConnection dbConn)
        {
            // GET /products
            app.MapGet("/familia", () =>
            {
                List<Familia> familia = FamiliaADO.GetAll(dbConn);
                return Results.Ok(familia);
            });

            // GET Product by id
            app.MapGet("/familia/{id}", (Guid id) =>
            {
                Familia? familia = FamiliaADO.GetById(dbConn, id);

                return familia is not null
                    ? Results.Ok(familia)
                    : Results.NotFound(new { message = $"Familia with Id {id} not found." });
            });




            // POST /products
            app.MapPost("/familia", (FamiliaRequest req) =>
            {
                Familia familia = new Familia
                {
                    Id = Guid.NewGuid(),
                    Nom = req.Nom,
                    Descripcio = req.Descripcio
                };

                FamiliaADO.Insert(dbConn, familia);

                return Results.Created($"/familia/{familia.Id}", familia);
            });
        }
    }
    public record FamiliaRequest(string Nom, string Descripcio);  // Com ha de llegir el POST
}
