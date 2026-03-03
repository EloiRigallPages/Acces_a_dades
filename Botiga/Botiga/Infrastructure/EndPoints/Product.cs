using Botiga.Repository;
using Botiga.Services;
using Botiga.Model;


namespace Botiga.EndPoints
{
    public static class ProductEndPoints
    {
        public static void MapProductEndpoints(this WebApplication app, DatabaseConnection dbConn)
        {
            // GET /Product
            app.MapGet("/Products", () =>
            {
                List<Product> products = ProductADO.GetAll(dbConn);
                return Results.Ok(products);
            });

            // GET /Product/{id}
            app.MapGet("/Product/{id}", (Guid id) =>
            {
                Product? product = ProductADO.GetById(dbConn, id);

                return product is not null
                    ? Results.Ok(product)
                    : Results.NotFound(new { message = $"Producte amb Id {id} no trobat." });
            });

            // POST /Product
            app.MapPost("/Product", (ProductRequest req) =>
            {
                Product product = new Product
                {
                    Id = Guid.NewGuid(),
                    Nom = req.Nom,
                    Descripcio = req.Descripcio,
                    Preu = req.Preu,
                    Descompte = req.Descompte,
                    IdFamilia = req.IdFamilia
                };

                ProductADO.Insert(dbConn, product);

                return Results.Created($"/Product/{product.Id}", product);
            });
        }
    }

    public record ProductRequest(string Nom, string Descripcio, decimal Preu, int Descompte, Guid IdFamilia);
}