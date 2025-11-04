using Botiga.DTO;
using Botiga.Model;

namespace Botiga.Utils
{
    public class UtilsConvertDTO
    {
        public static DTOCarroDeLaCompra ConvertToDTOCarroDeLaCompra(CarroDeLaCompra carro)
        {
            return new DTOCarroDeLaCompra { Id = carro.Id, IdCarro = carro.IdCarro, IdProducte = carro.IdProducte, Quantitat = carro.Quantitat};
        }
    }
}
