using Botiga.Model;
using Botiga.Repository;
using Botiga.Services;

namespace Botiga.EndPoints
{
    public static class CarroDeLaCompra
    {
        public static void MapCarroDeLaCompraEndpoints(this WebApplication app, DatabaseConnection dbConn)
        {
            // GET /products
            app.MapGet("/CarroDeLaCompra", () =>
            {
                List<Model.CarroDeLaCompra> carrodelacompra = CarroDeLaCompraADO.GetAll(dbConn);
                return Results.Ok(carrodelacompra);
            });

            // GET Product by id
            app.MapGet("/CarroDeLaCompra/{id}", (Guid id) =>
            {
                Model.CarroDeLaCompra carrodelacompra = CarroDeLaCompraADO.GetById(dbConn, id);

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
            app.MapPost("/CarroDeLaCompra", (CarroDeLaCompraRequest req) =>
            {
                Model.CarroDeLaCompra carrodelacompra = new Model.CarroDeLaCompra
                {
                    Id = Guid.NewGuid(),
                    IdCarro = req.IdCarro,
                    IdProducte = req.IdProducte,
                    Quantitat = req.Quantitat
                };

                CarroDeLaCompraADO.Insert(dbConn, carrodelacompra);

                return Results.Created($"/CarroDeLaCompra/{carrodelacompra.Id}", carrodelacompra);
            });
        }


    }

}
public record CarroDeLaCompraRequest(Guid IdCarro, Guid IdProducte, int Quantitat);
