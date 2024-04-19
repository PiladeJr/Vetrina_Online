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

        public bool CambiaPassword(string email, string vecchiaPassword, string nuovaPassword)
        {
            Utente utente = _dbContext.Utenti.FirstOrDefault(u => u.Email == email);

            if (utente == null)
                return false;

            if (utente.PasswordHash != vecchiaPassword)
                return false;

            utente.PasswordHash = nuovaPassword;
            _dbContext.SaveChanges();

            return true;
        }

        public void AggiornaUtente(string nuovoNome, string nuovoCognome, string nuovaEmail, string nuovoCellulare)
        {
            this.ControlloDati(nuovoNome, nuovoCognome, nuovaEmail, nuovoCellulare);
            Utente utente = _dbContext.Utenti.FirstOrDefault(u => u.Email == nuovaEmail);
            utente.Nome = nuovoNome;
            utente.Cognome = nuovoCognome;
            utente.PhoneNumber = nuovoCellulare;
            utente.Email = nuovaEmail;
        }

        private void ControlloDati(string nuovoNome, string nuovoCognome, string nuovaEmail, string nuovoCellulare)
        {
            if (string.IsNullOrEmpty(nuovoNome))
            {
                throw new ArgumentException("Il campo 'nuovoNome' non può essere vuoto o null.");
            }

            if (string.IsNullOrEmpty(nuovoCognome))
            {
                throw new ArgumentException("Il campo 'nuovoCognome' non può essere vuoto o null.");
            }

            if (string.IsNullOrEmpty(nuovaEmail))
            {
                throw new ArgumentException("Il campo 'nuovaEmail' non può essere vuoto o null.");
            }

            if (string.IsNullOrEmpty(nuovoCellulare))
            {
                throw new ArgumentException("Il campo 'nuovoCellulare' non può essere vuoto o null.");
            }
        }

    }
}