//using WebApp.Data;
//using WebApp.Models.Domain;
//namespace WebApp.Servizi
//{
//    public class ListaServizi
//    {
//        // Metodo per calcolare il prezzo totale dei prodotti nel carrello
//        // Se la lista dei prodotti è nulla, restituisce 0ù
//        public ApplicationDbContext Lista_db { get; set; }
//        public ListaServizi(ApplicationDbContext db)
//        {
//            Lista_db = db;
//        }
//        public Decimal CalcoloPrezzoTotale()
//        {
//            Lista_db.Lista.PrezzoTotale = 0; // Azzera il prezzo totale prima di calcolare
//            if (Lista_db.Lista.ListaProdotti != null)
//            {
//                foreach (var prodotto in ListaProdotti)
//                {
//                    PrezzoTotale += prodotto.Prezzo;
//                }
//            }
//            return PrezzoTotale;
//        }

//        // Metodo per ottenere la quantità totale dei prodotti nel carrello
//        // Se la lista dei prodotti è nulla, restituisce 0
//        public int QuantitaProdottiTotale()
//        {
//            if (ListaProdotti != null)
//                QuantitaProdotti = ListaProdotti.Count;
//            return QuantitaProdotti;
//        }

//        // Metodo per svuotare il carrello
//        public void SvuotaCarrello()
//        {
//            {
//                ListaProdotti.Clear();
//            }
//        }
//    }
//}
