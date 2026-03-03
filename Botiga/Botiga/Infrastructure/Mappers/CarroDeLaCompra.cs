using Botiga.DOMAIN.Entities;
using Botiga.Model;
using Botiga.Entities;

namespace Botiga.Infrastructure.Mappers;

public static class CarroDeLaCompra
{
    public static CarroDeLaCompraEntity ToEntity(Guid idCarroDeLaCompra, Guid idCarro, LiniaProducte liniaProducte, Preus preu)
        => new CarroDeLaCompraEntity
        {
            Id = idCarroDeLaCompra,
            IdCarro = idCarro,
            IdProduct = Guid.Parse(liniaProducte.producte.Codi),
            Quantitat = liniaProducte.Quantitat,
            Preu = preu.Preu

        };
}
