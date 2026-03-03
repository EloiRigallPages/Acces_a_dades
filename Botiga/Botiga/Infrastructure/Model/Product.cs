
namespace Botiga.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } = "";
        public string Descripcio { get; set; } = "";
        public decimal Preu { get; set; }
        public int Descompte { get; set; }
        public Guid IdFamilia { get; set; }
    }
}
