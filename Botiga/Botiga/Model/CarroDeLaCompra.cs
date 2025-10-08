namespace Botiga.Model
{
    public class CarroDeLaCompra
    {
        public Guid Id { get; set; }
        public string IdCarro { get; set; } = "";
        public string IdProducte { get; set; } = "";
        public int Quantitat { get; set; }
    }
}
