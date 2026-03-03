using Botiga.Repository;
using Botiga.Services;
using Botiga.Model;

namespace Botiga.EndPoints
{
    public static class FamiliaEndPoints
    {
        public static void MapFamiliaEndpoints(this WebApplication app, DatabaseConnection dbConn)
        {
            // GET /Familia
            app.MapGet("/Familia", () =>
            {
                List<Familia> families = FamiliaADO.GetAll(dbConn);
                return Results.Ok(families);
            });

            // GET /Familia/{id}
            app.MapGet("/Familia/{id}", (Guid id) =>
            {
                Familia? familia = FamiliaADO.GetById(dbConn, id);

                return familia is not null
                    ? Results.Ok(familia)
                    : Results.NotFound(new { message = $"Familia amb Id {id} no trobada." });
            });

            // POST /Familia
            app.MapPost("/Familia", (FamiliaRequest req) =>
            {
                Familia familia = new Familia
                {
                    Id = Guid.NewGuid(),
                    Nom = req.Nom,
                    Descripcio = req.Descripcio
                };

                FamiliaADO.Insert(dbConn, familia);

                return Results.Created($"/Familia/{familia.Id}", familia);
            });
        }
    }

    public record FamiliaRequest(string Nom, string Descripcio);
}