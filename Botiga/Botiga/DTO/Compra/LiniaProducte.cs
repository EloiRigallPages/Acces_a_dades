using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botiga.DTO.Compra
{
    public record LiniaProducteRequest(Guid Id, int quantitat)
    {

    }
}