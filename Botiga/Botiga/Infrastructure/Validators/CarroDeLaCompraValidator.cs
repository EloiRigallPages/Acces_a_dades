using Botiga.Common;
using Botiga.DTO;

namespace Botiga.Validators
{
    public static class CarroDeLaCompraValidator
    {
        public static Result Validate(CarroDeLaCompraRequest req)
        {
            if (req.Quantitat <= 0)
            {
                return Result.Failure(
                    "La quantitat ha de ser superior a 0",
                    "QUANTITAT_INVALIDA"
                );
            }

            if (req.IdCarro == Guid.Empty)
            {
                return Result.Failure(
                    "L'IdCarro no pot ser buit",
                    "ID_CARRO_INVALID"
                );
            }

            if (req.IdProducte == Guid.Empty)
            {
                return Result.Failure(
                    "L'IdProducte no pot ser buit",
                    "ID_PRODUCTE_INVALID"
                );
            }

            return Result.Ok();
        }
    }
}
