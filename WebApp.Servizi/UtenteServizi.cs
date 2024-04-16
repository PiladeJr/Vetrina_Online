using WebApp.Modelli;
namespace WebApp.Servizi
{
    public class UtenteServizi
    {
        private Utente utente;
        public UtenteServizi(Utente utente)
        {
            this.utente = utente;
        }

        public void CambioPassword(string nuovaPassword)
        {
            if (!string.IsNullOrEmpty(nuovaPassword))
                utente.PasswordHash = nuovaPassword;
        }

        public void AggiornaUtente(string nuovoNome, string nuovoCognome, string nuovaEmail, string nuovoCellulare)
        {
            this.ControlloDati(nuovoNome, nuovoCognome, nuovaEmail, nuovoCellulare);
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