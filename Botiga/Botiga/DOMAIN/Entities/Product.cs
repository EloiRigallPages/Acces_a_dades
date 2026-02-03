namespace Botiga.DOMAIN.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Nom { get; set; } = "";
    public string Descripcio { get; set; } = "";
    public decimal Preu { get; set; }
    public int Descompte { get; set; }
    public Guid IdFamilia { get; set; }

    public Product(Guid id, string nom, string descripcio, decimal preu, int descompte)
    {
        Id = id;
        Nom = nom;
        Descripcio = descripcio;
        Preu = preu;
        Descompte = descompte;
    }
}