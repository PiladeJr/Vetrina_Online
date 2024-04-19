using WebApp.Data;
using WebApp.Modelli;

namespace WebApp.Servizi
{
    public class ListaServizi
    {
        private readonly ApplicationDbContext _dbContext;

        public ListaServizi(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public decimal CalcoloPrezzoTotale()
        {
            decimal prezzoTotale = _dbContext.Prodotti.Sum(p => p.Prezzo);
            return prezzoTotale;
        }

        public int QuantitaProdottiTotale()
        {
            int quantitaProdotti = _dbContext.Prodotti.Count();
            return quantitaProdotti;
        }

        public void SvuotaCarrello()
        {
            _dbContext.Prodotti.RemoveRange(_dbContext.Prodotti);
            _dbContext.SaveChanges();
        }

        public void InvioProdotti(List<Prodotto> prodottiDaInviare)
        {
            foreach (var prodotto in prodottiDaInviare)
            {
                var prodottiDaRimuovere = _dbContext.Prodotti.Where(p => p.Nome == prodotto.Nome && p.Prezzo == prodotto.Prezzo).Take(prodotto.Quantita);
                _dbContext.Prodotti.RemoveRange(prodottiDaRimuovere);
            }

            SvuotaCarrello();
            _dbContext.SaveChanges();
        }
        public void AggiungiProdotto(Prodotto prodotto)
        {

            //var prodottoEsistente = _carrello.FirstOrDefault(p => p.Nome == prodotto.Nome && p.Prezzo == prodotto.Prezzo);
            //if (prodottoEsistente != null)
            //{
            //    prodottoEsistente.Quantita += prodotto.Quantita;
            //}
            //else
            //{
            //    _carrello.Add(prodotto);
            //}
        }

        public void EliminaProdotto(Guid id)
        {
            //var prodottoDaEliminare = _carrello.FirstOrDefault(p => p.Id == id);
            //if (prodottoDaEliminare != null)
            //{
            //    _carrello.Remove(prodottoDaEliminare);
            //}
        }
    }
}