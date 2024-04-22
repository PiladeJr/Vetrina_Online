﻿using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Modelli;

namespace WebApp.Servizi
{
    public class OrdineServizi
    {
        private readonly ApplicationDbContext _dbContext;
      //  private readonly Lista _Lista;

        public OrdineServizi(ApplicationDbContext dbContext/*,Lista lista*/)
        {
            _dbContext = dbContext;
           // _Lista = lista;
        }
        public async Task<List<Ordine>> GetOrdineAsync()
        {
            var modello = await _dbContext.Ordini.ToListAsync();
            return modello;
        }

        public async Task<List<Ordine>> GetOrderByUser(Utente utente)
        {
            var ordini = _dbContext.Ordini.Include(o => o.ProdottiOrdinati).ThenInclude(o => o.ProdottoAssociato).Include(o => o.UtenteAssociato).ToList();
            if (utente.isAdmin!=true)
            {
                ordini = ordini.Where(o => o.UtenteAssociato.Id == utente.Id).ToList();
            }
            return ordini;
        }

        // da modificare per prodotti e lista
        //public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        //{
        //    var order = new Order()
        //    {
        //        UserId = userId,
        //        Email = userEmailAddress
        //    };
        //    await _context.Orders.AddAsync(order);
        //    await _context.SaveChangesAsync();

        //    foreach (var item in items)
        //    {
        //        var orderItem = new OrderItem()
        //        {
        //            Amount = item.Amount,
        //            MovieId = item.Movie.Id,
        //            OrderId = order.Id,
        //            Price = item.Movie.Price
        //        };
        //        await _context.OrderItems.AddAsync(orderItem);
        //    }
        //    await _context.SaveChangesAsync();
        //}
    }
}
