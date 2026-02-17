using Botiga.Model;

namespace Botiga.DTO;

public record CarroDeLaCompraResponse(Guid Id, Guid IdCarro, Guid IdProduct, int Quantitat)
{
    public static CarroDeLaCompraResponse FromCarroDeLaCompra(CarroDeLaCompra c)
    {
        return new CarroDeLaCompraResponse(c.Id, c.IdCarro, c.IdProducte, c.Quantitat);
    }


}
