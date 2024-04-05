using System.ComponentModel.DataAnnotations;
using WebApp.Enum;

namespace WebApp.Models.Domain
{
    public class Prodotto
    {
        [Key]
        public Guid IDProdotto { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public decimal Prezzo { get; set; }
        public EnumWebApp.Categoria Categoria { get; set; }
        public string Marchio { get; set; }
        public DateTime DataCreazione { get; set; }
        public DateTime DataUltimaModifica { get; set; }
        public EnumWebApp.Taglia Taglia { get; set; }
        public string Colore { get; set; }
        public string Materiale { get; set; }
        public int Disponibilita { get; set; }

        public Prodotto() { }
        public Prodotto(Guid idProdotto, string nome, string descrizione, decimal prezzo, EnumWebApp.Categoria categoria, string marchio,
                              DateTime dataCreazione, DateTime dataUltimaModifica, EnumWebApp.Taglia taglia, string colore,
                              string materiale, int disponibilita)
        {
            IDProdotto = idProdotto;
            Nome = nome;
            Descrizione = descrizione;
            Prezzo = prezzo;
            Categoria = categoria;
            Marchio = marchio;
            DataCreazione = dataCreazione;
            DataUltimaModifica = dataUltimaModifica;
            Taglia = taglia;
            Colore = colore;
            Materiale = materiale;
            Disponibilita = disponibilita;
        }
    }
}
