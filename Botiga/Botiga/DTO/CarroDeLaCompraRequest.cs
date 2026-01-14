using Botiga.Model;

namespace Botiga.DTO
{
    public record CarroDeLaCompraRequest(Guid IdCarro, Guid IdProducte, int Quantitat)
    {
        public CarroDeLaCompra ToModel(Guid id)
        {
            return new CarroDeLaCompra
            {
                Id = id,
                IdCarro = IdCarro,
                IdProducte = IdProducte,
                Quantitat = Quantitat
            };
        }
    }
}
