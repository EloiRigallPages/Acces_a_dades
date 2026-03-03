using Botiga.Domain.Entities;
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

        List<LiniaProducte> productesDomain = new List<LiniaProducte>();

        foreach (LiniaProducteRequest producte in Productes)
        {
            productesDomain.Add(producte.ToProducte());
        }
        compraDomain.Productes = productesDomain;

        return compraDomain;
    }
}