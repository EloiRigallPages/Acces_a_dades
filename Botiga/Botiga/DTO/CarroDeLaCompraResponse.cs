using Botiga.Model;
using Botiga.EndPoints;

namespace Botiga.DTO
{
    public record CarroDeLaCompraResponse(Guid Id, Guid IdCarro, Guid IdProducte, int Quantitat)
    {
        public static CarroDeLaCompraResponse FromModel(CarroDeLaCompra model)
        {
            return new CarroDeLaCompraResponse(
                model.Id,
                model.IdCarro,
                model.IdProducte,
                model.Quantitat
            );
        }
    }
}
