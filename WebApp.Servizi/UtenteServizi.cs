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
            utente.PasswordHash = nuovaPassword;
        }

        public void AggiornaUtente(string nuovoNome, string nuovaEmail, DateTime nuovaDataNascita, string nuovoIndirizzo)
        {
            utente.Nome = nuovoNome;
            utente.Email = nuovaEmail;
            utente.DataNascita = nuovaDataNascita;
            utente.Indirizzo = nuovoIndirizzo;


        }
    }
}