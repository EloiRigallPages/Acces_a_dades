using Botiga.Model;
using Botiga.Repository;
using Botiga.Services;

namespace Botiga.EndPoints
{
    public class CarroDeLaCompra
    {
        public static void MapProductEndpoints(this WebApplication app, DatabaseConnection dbConn)
        {
            // GET /products
            app.MapGet("/products", () =>
            {
                List<Model.Product> carrodelacompra = ProductADO.GetAll(dbConn);
                return Results.Ok(carrodelacompra);
            });

            // GET Product by id
            app.MapGet("/products/{id}", (Guid id) =>
            {
                Model.Product carrodelacompra = ProductADO.GetById(dbConn, id);

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
                Model.Product carrodelacompra = new Model.Product
                {
                    Id = Guid.NewGuid(),
                    Code = req.Code,
                    Name = req.Name,
                    Price = req.Price
                };

                ProductADO.Insert(dbConn, carrodelacompra);

                return Results.Created($"/products/{carrodelacompra.Id}", carrodelacompra);
            });
        }


    }

}
