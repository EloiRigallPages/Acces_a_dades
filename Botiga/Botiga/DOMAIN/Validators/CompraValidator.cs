using Botiga.Common;
using Botiga.Common;
using Botiga.DOMAIN.Entities;

namespace Botiga.Domain.Validators;

public static class CompraValidator
{
    public static Result Validate(Compra compra)
    {
        if (compra.client == null)
            return Result.Failure("El client no pot ser null", "CLIENT_NULL");

        if (string.IsNullOrEmpty(compra.client.codi))
            return Result.Failure("El codi del client és obligatori", "CLIENT_CODI_INVALID");

        DateOnly avui = DateOnly.FromDateTime(DateTime.Now);
        if (compra.data > avui)
            return Result.Failure("La data de la compra no pot ser futura", "DATA_FUTURA");

        if ((avui.DayNumber - compra.data.DayNumber) > 10)
            return Result.Failure("La data de la compra no pot ser de més de 10 dies enrere", "DATA_MASSA_ANTERIOR");

        if (compra.Productes == null || compra.Productes.Count == 0)
            return Result.Failure("La compra ha de tenir almenys un producte", "PRODUCTES_BUITS");

        foreach (var linia in compra.Productes)
        {
            if (linia.Quantitat <= 0)
                return Result.Failure("La quantitat ha de ser superior a 0", "QUANTITAT_INVALIDA");

            if (linia.producte == null)
                return Result.Failure("El producte no pot ser null", "PRODUCTE_NULL");
        }

        return Result.Ok();
    }
}