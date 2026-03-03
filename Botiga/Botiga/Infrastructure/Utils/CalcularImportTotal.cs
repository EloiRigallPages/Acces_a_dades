using Botiga.Model;

namespace Botiga.Utils
{
    public class CalcularImportTotal
    {
        public static decimal CalcularImportTotalCarro(List<CarroDeLaCompra> ProductesDelCarro)
        {
            decimal total = 0;

            foreach (var item in ProductesDelCarro)
            {
                total += item.Preu * item.Quantitat;
            }

            return total;
        }
    }
}
