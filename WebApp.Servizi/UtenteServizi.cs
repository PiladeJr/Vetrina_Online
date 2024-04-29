using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Modelli;

namespace WebApp.Servizi
{
    public class UtenteServizi
    {
        private readonly ApplicationDbContext _dbContext;
        public UtenteServizi(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Utente> GetUtenteByIdAsync(string idutente)
        {
            return await _dbContext.Utenti.FirstOrDefaultAsync(u => u.Id == idutente);
        }

        public async Task AggiornaUtente(Utente datiAggiornati)
        {
            Utente utenteEsistente = await GetUtenteByIdAsync(datiAggiornati.Id);

            if (utenteEsistente != null)
            {
                utenteEsistente.Nome = datiAggiornati.Nome;
                utenteEsistente.Cognome = datiAggiornati.Cognome;
                utenteEsistente.Email = datiAggiornati.Email;
                utenteEsistente.PhoneNumber = datiAggiornati.PhoneNumber;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("l'utente da aggiornare non è stato trovato nel database.");
            }
        }

        public async Task<bool> ControlloMail(string email)
        {
            var utenti = _dbContext.Utenti.FirstOrDefault(u => u.Email == email);
            if (utenti == null) return true;
            return false;
        }
    }
}
