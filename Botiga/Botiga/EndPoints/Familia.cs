using Botiga.Repository;
using Botiga.Services;

namespace Botiga.EndPoints
{
    public class Familia
    {
        public static void MapProductEndpoints(this WebApplication app, DatabaseConnection dbConn)
        {
            // GET /products
            app.MapGet("/products", () =>
            {
                List<Model.Product> familia = ProductADO.GetAll(dbConn);
                return Results.Ok(familia);
            });

            // GET Product by id
            app.MapGet("/products/{id}", (Guid id) =>
            {
                Model.Product familia = ProductADO.GetById(dbConn, id);

                return familia is not null
                    ? Results.Ok(familia)
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
                Model.Product familia = new Model.Product
                {
                    Id = Guid.NewGuid(),
                    Code = req.Code,
                    Name = req.Name,
                    Price = req.Price
                };

                ProductADO.Insert(dbConn, familia);

                return Results.Created($"/products/{familia.Id}", familia);
            });
        }
    }
}
