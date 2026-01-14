using Botiga.Common;
using Botiga.DTO;

namespace Botiga.Validators
{
    public static class CarrosValidator
    {
        public static Result Validate(CarrosRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Nom))
            {
                return Result.Failure(
                    "El nom del carro no pot estar buit",
                    "NOM_BUIT"
                );
            }

            if (req.Nom.Length < 3)
            {
                return Result.Failure(
                    "El nom del carro ha de tenir almenys 3 caràcters",
                    "NOM_MASSA_CURT"
                );
            }

            return Result.Ok();
        }
    }
}
