using Botiga.Model.Interficie;

namespace Botiga.Classes.Descomptes
{
    public class DescomptePremium : IDescompte
    {

        public decimal CalcularDte(decimal import)
        {
            decimal descompte = import * 0.10m;

            return descompte;
        }

    }
}
