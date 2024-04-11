using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Modelli
{
    public class Lista
    {
        public Guid IDLista { get; set; }
        //    public Utente Utente { get; set; }
        //    public List<Prodotto> ListaProdotti { get; set; }
        public int QuantitaProdotti { get; set; }
        public decimal PrezzoTotale { get; set; }

        public Lista() { }
        public Lista(int quantitaProdotti, decimal prezzoTotale)
        {
            // Inizializzazione delle proprietà
            //    ListaProdotti = new List<Prodotto>();
            QuantitaProdotti = quantitaProdotti;
            PrezzoTotale = prezzoTotale;
        }


    }
}
