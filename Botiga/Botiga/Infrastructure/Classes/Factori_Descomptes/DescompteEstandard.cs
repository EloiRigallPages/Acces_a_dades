using Botiga.Classes.Descomptes;
using Botiga.Model.Interficie;

namespace Botiga.Classes.Factori_Descomptes
{
    public class DescompteEstandardFactory : IDescompteFactory
    {
        public IDescompte CreateDescompte()
        {
            return new DescompteEstandard();
        }
    }
}
