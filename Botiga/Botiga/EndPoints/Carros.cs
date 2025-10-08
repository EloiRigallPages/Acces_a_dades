using Botiga.Repository;
using Botiga.Services;

namespace Botiga.EndPoints
{
    public static class Carros
    {
        public static void MapProductEndpoints(this WebApplication app, DatabaseConnection dbConn)
        {
            // GET /products
            app.MapGet("/products", () =>
            {
                List<Model.Familia> carros = FamiliaADO.GetAll(dbConn);
                return Results.Ok(carros);
            });

            // GET Product by id
            app.MapGet("/products/{id}", (Guid id) =>
            {
                Model.Familia carros = FamiliaADO.GetById(dbConn, id);

                return carros is not null
                    ? Results.Ok(carros)
                    : Results.NotFound(new { message = $"Product with Id {id} not found." });

                // if (product is not null)
                // {
                //     return Results.Ok(product);
                // }
                // else
                // {
                //     return Results.NotFound(new { message = $"Product with Id {id} not found." });
                // }
            });




            // POST /products
            app.MapPost("/products", (ProductRequest req) =>
            {
                Model.Familia carros = new Model.Familia
                {
                    Id = Guid.NewGuid(),
                    Code = req.Code,
                    Name = req.Nom,
                    Price = req.Descripcio
                };

                FamiliaADO.Insert(dbConn, carros);

                return Results.Created($"/products/{carros.Id}", carros);
            });
        }
    }
}
