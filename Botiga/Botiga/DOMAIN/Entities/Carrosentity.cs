namespace Botiga.DOMAIN.Entities
{
    public class CarrosEntity
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } = "";

        public Guid idClient { get; set; }

        public DateOnly data { get; set; }
    }
}
