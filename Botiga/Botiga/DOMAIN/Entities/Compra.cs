namespace Botiga.DOMAIN.Entities;

public class Compra
{
    public string Nom { get; set; } = "";
    public string Descripcio { get; set; } = "";
    public decimal Preu { get; set; }
    public int Descompte { get; set; }
    

    public Compra(string nom, string descripcio, decimal preu, int descompte)
    {
        Nom = nom;
        Descripcio = descripcio;
        Preu = preu;
        Descompte = descompte;
    }
}