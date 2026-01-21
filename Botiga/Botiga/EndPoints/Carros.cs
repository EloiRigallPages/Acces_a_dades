using Botiga.Classes.Factori_Descomptes;
using Botiga.Common;
using Botiga.DTO;
using Botiga.Model;
using Botiga.Model.Interficie;
using Botiga.Repository;
using Botiga.Services;
using Botiga.Utils;
using Botiga.Validators;

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
                List<CarrosResponse> response = new();

                foreach (var carro in carros)
                {
                    response.Add(CarrosResponse.FromModel(carro));
                }

                return Results.Ok(response);
            });

            // GET /Carro/{id}
            app.MapGet("/Carro/{id}", (Guid id) =>
            {
                Carros? carro = CarrosADO.GetById(dbConn, id);

                return carro is not null
                    ? Results.Ok(CarrosResponse.FromModel(carro))
                    : Results.NotFound(new { message = $"Carro amb Id {id} no trobat." });
            });

            // POST /Carro
            app.MapPost("/Carro", (CarrosRequest req) =>
            {
                Result result = CarrosValidator.Validate(req);
                if (!result.IsOk)
                {
                    return Results.BadRequest(new
                    {
                        error = result.ErrorCode,
                        message = result.ErrorMessage
                    });
                }

                Guid id = Guid.NewGuid();
                Carros carro = req.ToModel(id);

                CarrosADO.Insert(dbConn, carro);

                return Results.Created(
                    $"/Carro/{carro.Id}",
                    CarrosResponse.FromModel(carro)
                );
            });

            app.MapGet("/Carro/{id}/import", (Guid id, string tipusClient) =>
            {
                Carros? carro = CarrosADO.GetById(dbConn, id);

                if (carro is null)
                {
                    return Results.NotFound(new { message = $"Carro amb Id {id} no trobat." });
                }

                //List<CarroDeLaCompra> ProductesDelCarro = 

                List<CarroDeLaCompra> ProductesCarroCompra = CarroDeLaCompraADO.GetAllProductesCarroDeLaCompra(dbConn, id);


                decimal ImportTotal = Utils.CalcularImportTotal.CalcularImportTotalCarro(ProductesCarroCompra);


                //Calcular descompte //crear descompte per determinar
                IDescompteFactory dteFactory = tipusClient switch
                {
                    "Estandard" => new DescompteEstandardFactory(),
                    "Premium" => new DescomptePremiumFactory(),
                    _ => throw new ArgumentException("Tipus de client desconegut.")
                };

                IDescompte descompte = dteFactory.CreateDescompte();

                decimal dte = descompte.CalcularDte(ImportTotal);

                decimal importFinal = ImportTotal - dte;

                //Retornar import, Descompte, Import amb descompte

                //return Results.Ok(importFinal);
                return Results.Ok(new
                {
                    Import = ImportTotal,
                    Descompte = dte,
                    ImportFinal = importFinal
                });



            });

        }
    }
}
