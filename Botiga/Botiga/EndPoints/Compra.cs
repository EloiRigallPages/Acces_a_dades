using Botiga.DTO;
using Botiga.Repository;
using Botiga.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Botiga.DTO.Compra;


namespace Botiga.EndPoints;

public static class EndpointsCompra
{
    public static void MapCompraEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {

        // POST /compra/CompraRequest fet amb DTO
        app.MapPost("/compra", (CompraRequest req) =>
        {



            return Results.Ok(req.Productes);
        });
    }
}



/*
{
 "idClient": "BF3137AB-85DF-4DD8-942C-25F7286FDA41"
 "Productes":[ {id:"7D90DA36-773D-45F0-8CDD-785631C79B09", quantitat: 3},
                { id: "AAF527F6-7AB2-408C-9A56-7DF8359155E2", quantitat: 1} ] 
}
*/
