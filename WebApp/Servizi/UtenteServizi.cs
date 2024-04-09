using WebApp.Data;
using WebApp.Models.Domain;
namespace WebApp.Servizi
{
    public class UtenteServizi
    {
        private readonly ApplicationDbContext _dbContext;

        public UtenteServizi(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Metodo per aggiornare i dettagli dell'utente
        public void AggiornaUtente(string nome, string cognome, string email, string telefono, DateTime dataNascita, string indirizzo, Guid idUtente)
        {
            // Esempio di come aggiornare i dettagli dell'utente nel database utilizzando Entity Framework Core
            // Supponiamo che tu abbia una classe Utente nel tuo DbContext
            var utente = _dbContext.Utenti.Find(idUtente); // id è l'identificatore unico dell'utente
            if (utente != null)
            {
                utente.Nome = nome;
                utente.Cognome = cognome;
                utente.Email = email;
                utente.PhoneNumber = telefono;
                utente.DataNascita = dataNascita;
                utente.Indirizzo = indirizzo;

                _dbContext.SaveChanges();
            }
            else
            {
                // Utente non trovato, gestisci l'errore di conseguenza
            }
        }

        // Metodo per cambiare la password dell'utente
        public void CambiaPassword(string nuovaPassword, Guid idUtente)
        {
            // Esempio di come cambiare la password dell'utente nel database utilizzando Entity Framework Core
            // Supponiamo che tu abbia una classe Utente nel tuo DbContext
            var utente = _dbContext.Utenti.Find(idUtente); // id è l'identificatore unico dell'utente
            if (utente != null)
            {
                utente.PasswordHash = nuovaPassword;
                _dbContext.SaveChanges();
            }
            else
            {
                // Utente non trovato, gestisci l'errore di conseguenza
            }
        }
    }
}
