using Botiga.Classes.Descomptes;
using Botiga.Model.Interficie;

namespace Botiga.Classes.Factori_Descomptes
{
    public class DescomptePremiumFactory : IDescompteFactory
    {
        public IDescompte CreateDescompte()
        {
            return new DescomptePremium();
        }
    }
}
