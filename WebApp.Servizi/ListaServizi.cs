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

        public List<Prodotto> GetListaProdotti()
        {
            return _dbContext.Prodotti.ToList();
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

            _dbContext.ProdottiOrdinati.RemoveRange(_dbContext.ProdottiOrdinati);
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
        public void AggiungiProdottoLista(Prodotto prodottoDaAggiungere)
        {
            if (prodottoDaAggiungere == null)
            {
              this.GetListaProdotti();
            }

            var prodottoEsistente = _dbContext.Prodotti.FirstOrDefault(p => p.Nome == prodottoDaAggiungere.Nome && p.Prezzo == prodottoDaAggiungere.Prezzo);

            if (prodottoEsistente != null)
            {
                prodottoEsistente.Quantita += prodottoDaAggiungere.Quantita;
            }
            else
            {
                _dbContext.Prodotti.Add(prodottoDaAggiungere);
            }

            _dbContext.SaveChanges();
        }

        public void EliminaProdottoLista(Guid prodottoId)
        {
            var prodottoDaEliminare = _dbContext.Prodotti.Find(prodottoId);
            if (prodottoDaEliminare != null)
            {
                _dbContext.Prodotti.Remove(prodottoDaEliminare);
                _dbContext.SaveChanges();
            }
        }


    }
}