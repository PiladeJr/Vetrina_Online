using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApp.Data;
using WebApp.Modelli;

namespace WebApp.Servizi
{
    public class ListaServizi
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Lista _lista;

        public ListaServizi(ApplicationDbContext dbContext, Lista lista)
        {
            _dbContext = dbContext;
            _lista = lista;
        }

        public List<Prodotto> GetListaProdotti()
        {
            return _dbContext.Prodotti.ToList();
        }

        public void AggiungiProdottoLista(Prodotto prodottoDaAggiungere)
        {
            if (prodottoDaAggiungere == null)
            {
              this.GetListaProdotti();
            }

            var prodottoEsistente = _dbContext.Prodotti.FirstOrDefault(p => p.Nome == prodottoDaAggiungere.Nome && p.Prezzo == prodottoDaAggiungere.Prezzo);
            var listaprodotti = _dbContext.ListaProdotti.FirstOrDefault(n => n.ProdottoAssociato.IDProdotto == prodottoDaAggiungere.IDProdotto && n.IDListaProdotti == _lista.IDLista);
             if (listaprodotti == null)
                {
                listaprodotti = new Lista()
                {
                    IDListaProdotti = listaprodotti.IDLista,
                    ProdottoAssociato=prodottoDaAggiungere,
                    QuantitaProdotti=1
                };

             }
            
            else
            {
                listaprodotti.QuantitaProdotti++;
            }
            _dbContext.SaveChangesAsync();
        }

        public async Task EliminaProdotto(Guid idProdotto)
        {
        var prodottoInLista = _dbContext.ListaProdotti.FirstOrDefault(p => p.ProdottoAssociato.IDProdotto == idProdotto && p.IDListaProdotti == _lista.IDLista);

            if (prodottoInLista != null)
            {
            if (prodottoInLista.QuantitaProdotti > 1)
            {
                prodottoInLista.QuantitaProdotti--;
            }
            else
            {
                _dbContext.ListaProdotti.Remove(prodottoInLista);
            }

            await _dbContext.SaveChangesAsync();
             }
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

        public async Task SvuotaCarrello()
        {
            var prodottiInCarrello = _dbContext.ListaProdotti.Where(p => p.IDListaProdotti == _lista.IDLista);
            _dbContext.ListaProdotti.RemoveRange(prodottiInCarrello);
            await _dbContext.SaveChangesAsync();
        }

        public async Task InvioProdotti()
        {
            var prodottiInCarrello = _dbContext.ListaProdotti.Where(p => p.IDListaProdotti == _lista.IDLista);
            foreach (var prodottoInCarrello in prodottiInCarrello)
            {
                var prodotto = _dbContext.Prodotti.Find(prodottoInCarrello.ProdottoAssociato.IDProdotto);
                if (prodotto != null)
                {
                    // Logica per l'invio del prodotto...
                    // Ad esempio, potresti aggiungere il prodotto a un ordine o un carrello d'acquisto e rimuoverlo dalla lista.
                    // _dbContext.Ordini.Add(new Ordine { Prodotto = prodotto, Quantita = prodottoInCarrello.QuantitaProdotti });
                    _dbContext.ListaProdotti.Remove(prodottoInCarrello);
                }
            }
            await _dbContext.SaveChangesAsync();
        }

    }
}

//    public List<ShoppingCartItem> GetShoppingCartItems()
//    {
//        return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Movie).ToList());
//    }

//    public double GetShoppingCartTotal() => _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Movie.Price * n.Amount).Sum();

//    public async Task ClearShoppingCartAsync()
//    {
//        var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
//        _context.ShoppingCartItems.RemoveRange(items);
//        await _context.SaveChangesAsync();
//    }
//}
