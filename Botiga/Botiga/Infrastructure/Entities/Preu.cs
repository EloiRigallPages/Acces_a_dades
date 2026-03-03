namespace Botiga.Entities
{
    public class Preu
    {
        public Guid Id { get; set; }
        public Guid IdProducte { get; set; }
        public DateTime dataPreu { get; set; }
        public decimal preu { get; set; }
    }
}
