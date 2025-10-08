using Botiga.Model;
using Botiga.Repository;
using Botiga.Services;

namespace Botiga.EndPoints
{
    public static class CarroDeLaCompra
    {
        public static void MapProductEndpoints(this WebApplication app, DatabaseConnection dbConn)
        {
            // GET /products
            app.MapGet("/products", () =>
            {
                List<Model.Familia> carrodelacompra = FamiliaADO.GetAll(dbConn);
                return Results.Ok(carrodelacompra);
            });

            // GET Product by id
            app.MapGet("/products/{id}", (Guid id) =>
            {
                Model.Familia carrodelacompra = FamiliaADO.GetById(dbConn, id);

                return carrodelacompra is not null
                    ? Results.Ok(carrodelacompra)
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
                Model.Familia carrodelacompra = new Model.Familia
                {
                    Id = Guid.NewGuid(),
                    Code = req.Code,
                    Name = req.Nom,
                    Price = req.Descripcio
                };

                FamiliaADO.Insert(dbConn, carrodelacompra);

                return Results.Created($"/products/{carrodelacompra.Id}", carrodelacompra);
            });
        }


    }

}
