using Botiga.DTO;
using Botiga.Model;
using Botiga.Repository;
using Botiga.Services;
using Botiga.Validators;
using Botiga.Common;

namespace Botiga.EndPoints
{
    public static class CarroDeLaCompraEndpoints
    {
        public static void MapCarroDeLaCompraEndpoints(this WebApplication app, DatabaseConnection dbConn)
        {
            // GET ALL
            app.MapGet("/CarroDeLaCompra/{id}", (Guid id) =>
            {
                List<CarroDeLaCompra> items = CarroDeLaCompraADO.GetAllProductesCarroDeLaCompra(dbConn, id);
                List<CarroDeLaCompraResponse> response = new();

                foreach (var item in items)
                {
                    response.Add(CarroDeLaCompraResponse.FromModel(item));
                }

                return Results.Ok(response);
            });

            // GET BY ID
            app.MapGet("/CarroDeLaCompra/{id}", (Guid id) =>
            {
                CarroDeLaCompra? item = CarroDeLaCompraADO.GetById(dbConn, id);

                return item is not null
                    ? Results.Ok(CarroDeLaCompraResponse.FromModel(item))
                    : Results.NotFound(new { message = $"CarroDeLaCompra amb Id {id} no trobat." });
            });

            // POST
            app.MapPost("/CarroDeLaCompra", (CarroDeLaCompraRequest req) =>
            {
                Result result = CarroDeLaCompraValidator.Validate(req);
                if (!result.IsOk)
                {
                    return Results.BadRequest(new
                    {
                        error = result.ErrorCode,
                        message = result.ErrorMessage
                    });
                }

                Guid id = Guid.NewGuid();
                CarroDeLaCompra model = req.ToModel(id);

                CarroDeLaCompraADO.Insert(dbConn, model);

                return Results.Created(
                    $"/CarroDeLaCompra/{model.Id}",
                    CarroDeLaCompraResponse.FromModel(model)
                );
            });
        }
    }
}


