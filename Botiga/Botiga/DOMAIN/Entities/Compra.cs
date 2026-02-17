using Botiga.DTO.Compras;

namespace Botiga.Domain.Entities;


public class Compra
{
    public Client client { get; set; }

    public DateOnly data { get; set; }

    public List<LiniaProducteRequest> Productes { get; set; }


}