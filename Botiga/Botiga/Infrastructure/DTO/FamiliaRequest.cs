using Botiga.Model;

namespace Botiga.DTO;

public record FamiliaRequest(string Nom, string Descripcio)
{
    public Familia ToFamilia(Guid id)
    {
        return new Familia
        {
            Id = id,
            Nom = Nom,
            Descripcio = Descripcio
        };
    }
}
