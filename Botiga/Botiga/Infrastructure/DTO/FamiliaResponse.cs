//lo que respon l'api (un get)

using Botiga.Model;

namespace Botiga.DTO;

public record FamiliaResponse(Guid Id, string Nom, string Descripcio)
{
    public static FamiliaResponse FromFamilia(Familia familia)
    {
        return new FamiliaResponse(familia.Id, familia.Nom, familia.Descripcio);
    }
}