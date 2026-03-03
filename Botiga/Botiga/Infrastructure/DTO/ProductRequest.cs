//lo que rep del model ho troansfora per enviar-ho a l'ingterficie (un post)

using Botiga.Model;

namespace Botiga.DTO;

public record ProductRequest(string Nom, string Descripcio, decimal Preu, int Descompte, Guid IdFamilia)
{
    // Converteix un ProductRequest al model Product
    public Product ToProduct(Guid id)
    {
        return new Product
        {
            Id = id,
            Nom = Nom,
            Descripcio = Descripcio,
            Preu = Preu,
            Descompte = Descompte,
            IdFamilia = IdFamilia
        };
    }
}