﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Data;
using WebApp.Enum;
using WebApp.Modelli;

namespace WebApp.Servizi
{
    public class ProdottoServizi
    {
        private readonly ApplicationDbContext _dbContext;

        public ProdottoServizi(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Prodotto> GetProdotti()
        {
            return _dbContext.Prodotti.ToList();
        }

        public Prodotto GetProdottoById(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("ID non valido");
            }
            return _dbContext.Prodotti.FirstOrDefault(p => p.IDProdotto == id);
        }
        public List<Prodotto> FiltraProdotti(EnumWebApp.Categoria? categoria, EnumWebApp.Taglia? taglia)
        {
            IQueryable<Prodotto> prodottiFiltrati = _dbContext.Prodotti;

            if (categoria != null)
            {
                prodottiFiltrati = prodottiFiltrati.Where(p => p.Categoria == categoria);
            }

            if (taglia != null)
            {
                prodottiFiltrati = prodottiFiltrati.Where(p => p.Taglia == taglia);
            }

            return prodottiFiltrati.ToList();
        }

        public void AggiungiProdotto(Prodotto prodotto)
        {
            if (prodotto != null) { 
                _dbContext.Prodotti.Add(prodotto);
            }
            _dbContext.SaveChanges();
        }

        public void AggiornaProdotto(Prodotto prodotto)
        {
            _dbContext.Entry(prodotto).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void EliminaProdotto(Guid id)
        {
            var prodotto = _dbContext.Prodotti.Find(id);
            if (prodotto != null)
            {
                _dbContext.Prodotti.Remove(prodotto);
                _dbContext.SaveChanges();
            }
        }
    }
}
        
