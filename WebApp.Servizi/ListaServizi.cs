using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Servizi
{
    public class ListaServizi
    {
        // Metodo per calcolare il prezzo totale dei prodotti nel carrello
        // Se la lista dei prodotti è nulla, restituisce 0
        public Decimal CalcoloPrezzoTotale()
        {
            PrezzoTotale = 0; // Azzera il prezzo totale prima di calcolare
            if (ListaProdotti != null)
            {
                foreach (var prodotto in ListaProdotti)
                {
                    PrezzoTotale += prodotto.Prezzo;
                }
            }
            return PrezzoTotale;
        }

        // Metodo per ottenere la quantità totale dei prodotti nel carrello
        // Se la lista dei prodotti è nulla, restituisce 0
        public int QuantitaProdottiTotale()
        {
            if (ListaProdotti != null)
                QuantitaProdotti = ListaProdotti.Count;
            return QuantitaProdotti;
        }

        // Metodo per svuotare il carrello
        public void SvuotaCarrello()
        {
            {
                ListaProdotti.Clear();
            }
        }
    }
}
