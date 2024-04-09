using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Data;
using WebApp.Models.Domain;

namespace WebApp.Servizi
{
    public class ListaServizi
    {
        private readonly ApplicationDbContext _dbContext;

        public ListaServizi(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Metodo per calcolare il prezzo totale dei prodotti nel carrello
        // Se la lista dei prodotti è nulla, restituisce 0
        public decimal CalcoloPrezzoTotale()
        {
            decimal prezzoTotale = 0; // Inizializza il prezzo totale a 0

            var listaProdotti = _dbContext.ListaProdotti.ToList(); // Recupera tutti i prodotti dalla lista

            if (listaProdotti != null)
            {
                foreach (var prodotto in listaProdotti)
                {
                    prezzoTotale += prodotto.Prezzo; // Aggiunge il prezzo del prodotto al prezzo totale
                }
            }

            return prezzoTotale;
        }

        // Metodo per ottenere la quantità totale dei prodotti nel carrello
        // Se la lista dei prodotti è nulla, restituisce 0
        public int QuantitaProdottiTotale()
        {
            var listaProdotti = _dbContext.ListaProdotti.ToList(); // Recupera tutti i prodotti dalla lista

            if (listaProdotti != null)
                return listaProdotti.Count; // Restituisce il numero totale di prodotti nella lista
            else
                return 0; // Se la lista è vuota, restituisce 0
        }

        // Metodo per svuotare il carrello
        public void SvuotaCarrello()
        {
            var listaProdotti = _dbContext.ListaProdotti.ToList(); // Recupera tutti i prodotti dalla lista

            if (listaProdotti != null)
            {
                _dbContext.ListaProdotti.RemoveRange(listaProdotti); // Rimuove tutti i prodotti dalla lista
                _dbContext.SaveChanges(); // Salva i cambiamenti nel database
            }
        }
    }
}
