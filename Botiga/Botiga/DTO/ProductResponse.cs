using Botiga.Model;

namespace Botiga.DTO;

public record ProductResponse(Guid Id, string Nom, string Descripcio, decimal Preu, decimal Descompte, Guid IdFamilia)
{
    // Converteix el model Product a ProductResponse
    public static ProductResponse FromProduct(Product product)
    {
        return new ProductResponse(
            product.Id,
            product.Nom,
            product.Descripcio,
            product.Preu,
            product.Descompte,
            product.IdFamilia
        );
    }
}