namespace Botiga.DOMAIN.Entities
{
    public class CarroDeLaCompraEntity
    {
        public Guid Id { get; set; }
        public Guid IdCarro { get; set; }
        public Guid IdProduct { get; set; }
        public int Quantitat { get; set; }
        public decimal Preu { get; set; }
    }
}
