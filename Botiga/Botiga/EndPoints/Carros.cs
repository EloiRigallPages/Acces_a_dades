using Botiga.Model;
using Botiga.Repository;
using Botiga.Services;

namespace Botiga.EndPoints
{
    namespace Botiga.EndPoints
    {
        public static class CarrosEndPoints
        {
            public static void MapCarrosEndpoints(this WebApplication app, DatabaseConnection dbConn)
            {
                // GET /Carro
                app.MapGet("/Carro", () =>
                {
                    List<Carros> carros = CarrosADO.GetAll(dbConn);
                    return Results.Ok(carros);
                });

                // GET /Carro/{id}
                app.MapGet("/Carro/{id}", (Guid id) =>
                {
                    Carros? carro = CarrosADO.GetById(dbConn, id);

                    return carro is not null
                        ? Results.Ok(carro)
                        : Results.NotFound(new { message = $"Carro amb Id {id} no trobat." });
                });

                // POST /Carro
                app.MapPost("/Carro", (CarrosRequest req) =>
                {
                    Carros carro = new Carros
                    {
                        Id = Guid.NewGuid(),
                        Nom = req.Nom
                    };

                    CarrosADO.Insert(dbConn, carro);

                    return Results.Created($"/Carro/{carro.Id}", carro);
                });
            }
        }

        public record CarrosRequest(string Nom);
    }
}
