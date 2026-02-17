using Botiga.Common;
using Botiga.Domain.Entities;
using Botiga.Domain.Validators;
using Botiga.DTO.Compras;
using Botiga.Services;


namespace Botiga.EndPoints;

public static class EndpointsCompra
{
    public static void MapCompraEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {

        // POST /compra/CompraRequest fet amb DTO
        app.MapPost("/compra", (CompraRequest req) =>
        {
            // Console.WriteLine(req);

            Compra compra = req.ToCompra();
            Result result = CompraValidator.Validate(compra);
            // LiniaProducte liniaProducte = req.ToProducte();
            if (!result.IsOk)
            {
                return Results.BadRequest(new
                {
                    error = result.ErrorCode,
                    message = result.ErrorMessage
                });
            }

            //fer obtenir el preu

            return Results.Ok(compra);

        });
    }
}




//  {
//   "idClient": "BF3137AB-85DF-4DD8-942C-25F7286FDA41",
//   "Data": "2026-02-02",     
//   "Productes":[ {id:"7D90DA36-773D-45F0-8CDD-785631C79B09", quantitat: 3},
//                  { id: "AAF527F6-7AB2-408C-9A56-7DF8359155E2", quantitat: 1} ] 
//  }
