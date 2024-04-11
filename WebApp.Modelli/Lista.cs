using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Modelli
{
    public class Lista
    {
        public Guid IDLista { get; set; }
        public List<Prodotto> ListaProdotti { get; set; }
        public int QuantitaProdotti { get; set; }
        public decimal PrezzoTotale { get; set; }
       
        // [ForeignKey(nameof(Id))]
        public string Id { get; set; } 

        public Lista() { }
        public Lista(int quantitaProdotti, decimal prezzoTotale)
        {
            ListaProdotti = new List<Prodotto>();
            QuantitaProdotti = quantitaProdotti;
            PrezzoTotale = prezzoTotale;
        }


    }
}
