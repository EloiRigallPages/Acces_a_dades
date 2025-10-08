using Botiga.Repository;
using Botiga.Services;
using Botiga.Model;


namespace Botiga.EndPoints;

public static class CarroDeLaCompra
{
    public static void MapProductEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // GET /products
        app.MapGet("/products", () =>
        {
            List<Model.Product> products = FamiliaADO.GetAll(dbConn);
            return Results.Ok(products);
        });

        // GET Product by id
        app.MapGet("/products/{id}", (Guid id) =>
        {
            Model.Product product = FamiliaADO.GetById(dbConn, id);

            return product is not null
                ? Results.Ok(product)
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
            Model.Product product = new Model.Product
            {
                Id = Guid.NewGuid(),
                Code = req.Code,
                Name = req.Nom,
                Price = req.Descripcio
            };

            FamiliaADO.Insert(dbConn,product);

            return Results.Created($"/products/{product.Id}", product);
        });
    }


}

public record ProductRequest(string Code, string Nom, decimal Descripcio);  // Com ha de llegir el POST