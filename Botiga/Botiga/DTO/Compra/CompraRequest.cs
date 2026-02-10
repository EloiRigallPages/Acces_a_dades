using Botiga.Domain.Entities;
using Botiga.DTO.Compra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botiga.DTO.Compras;

public record CompraRequest(Guid IdClient, DateOnly Data, List<LiniaProducteRequest> Productes)
{
    public Compra ToCompra()
    {

        Client client = new Client();
        client.codi = IdClient.ToString();

        Compra compraDomain = new Compra();
        compraDomain.client = client;

        compraDomain.data = Data;

        List<LiniaProducte> ProductesDomain = new List<LiniaProducte>();

        foreach (LiniaProducteRequest producte in Productes)
        {
            ProductesDomain.Add(producte.ToProducte());
        }
        compraDomain.Productes = ProductesDomain;

        return compraDomain;
    }
}