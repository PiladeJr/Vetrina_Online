using WebApp.EnumFolder;

namespace WebApp.Modelli
{
    public class Prodotto
    {
        public Guid IDProdotto { get; set; }
        public string Nome { get; set; }
        public string Immagine { get; set; }
        public string Descrizione { get; set; }
        public decimal Prezzo { get; set; }
        public int Quantita { get; set; }
        public EnumWebApp.Categoria Categoria { get; set; }
        public EnumWebApp.Taglia Taglia { get; set; }
        public string Colore { get; set; }

        public Prodotto() { }
        public Prodotto(string nome,string immagine, string descrizione, decimal prezzo, EnumWebApp.Categoria categoria,
                               EnumWebApp.Taglia taglia, string colore)
        {
            Nome = nome;
            Immagine = immagine;
            Descrizione = descrizione;
            Prezzo = prezzo;
            Categoria = categoria;
            Taglia = taglia;
            Colore = colore;
        }

        public ProdottoClonato CreazioneProdottoClonato()
        {
            var prodottoclonato = new ProdottoClonato()
            {
                Nome = this.Nome,
                Immagine = this.Immagine,
                Descrizione = this.Descrizione,
                Prezzo = this.Prezzo,
                Categoria = this.Categoria,
                Taglia = this.Taglia,
                Colore = this.Colore
            };
            return prodottoclonato;
        }
    }
}
