using Botiga.Domain.Entities;
using Botiga.DTO.Compras;

namespace Botiga.DOMAIN.Entities;

public class Compra
{
    public Client client { get; set; }

    public DateOnly data { get; set; }

    public List<LiniaProducteRequest> Productes { get; set; }


}