using WebApp.Enum;

namespace WebApp.Modelli
{
    public class Prodotto
    {
        public Guid IDProdotto { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public decimal Prezzo { get; set; }
        public int Quantita { get; set; }
        public EnumWebApp.Categoria Categoria { get; set; }
        public string Marchio { get; set; }
        public EnumWebApp.Taglia Taglia { get; set; }
        public string Colore { get; set; }
        public string Materiale { get; set; }
        public int Disponibilita { get; set; }

        public Guid IDNegozio { get; set; }
        public virtual Negozio negozioAssociato { get; set; }

        public Prodotto() { }
        public Prodotto(string nome, string descrizione, decimal prezzo, EnumWebApp.Categoria categoria, string marchio,
                               EnumWebApp.Taglia taglia, string colore,
                              string materiale, int disponibilita, Negozio negozio)
        {
            Nome = nome;
            Descrizione = descrizione;
            Prezzo = prezzo;
            Categoria = categoria;
            Marchio = marchio;
            Taglia = taglia;
            Colore = colore;
            Materiale = materiale;
            Disponibilita = disponibilita;
            negozioAssociato = negozio;
        }
    }
}
