//using WebApp.Modelli;

//namespace WebApp.Servizi
//{
//    public class ProdottiServizi
//    {
//        public void AggiungiProdotto(Prodotto prodotto)
//        {
//            ProdottiInMagazzino.Add(prodotto);
//        }

//        // Metodo per rimuovere un prodotto dal magazzino
//        public void RimuoviProdotto(Prodotto prodotto)
//        {
//            ProdottiInMagazzino.Remove(prodotto);
//        }

//        // Metodo per controllare se un prodotto è disponibile nel magazzino
//        public bool IsDisponibile(Prodotto prodotto)
//        {
//            // Cerca il prodotto nella lista dei prodotti in magazzino
//            foreach (Prodotto prodottoCercato in ProdottiInMagazzino)
//            {
//                if (prodottoCercato.IDProdotto == prodotto.IDProdotto)
//                {
//                    // Se il prodotto è trovato e la sua disponibilità è maggiore di 0, restituisci true
//                    return prodottoCercato.Disponibilita > 0;
//                }
//            }
//            // Se il prodotto non è trovato o la sua disponibilità è 0, restituisci false
//            return false;
//        }
//    }
//}
