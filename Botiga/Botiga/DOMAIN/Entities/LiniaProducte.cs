using Botiga.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botiga.Domain.Entities;

public class LiniaProducte
{
    public Producte producte { get; set; }
    public int Quantitat { get; set; }

    // public LiniaProducte(Guid idProducte, int quantitat)
    // {
    //     IdProducte = idProducte;
    //     Quantitat = quantitat;
    // }
}