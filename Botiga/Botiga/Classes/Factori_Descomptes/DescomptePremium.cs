using Botiga.Classes.Descomptes;

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
