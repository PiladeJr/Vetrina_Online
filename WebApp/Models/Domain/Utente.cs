using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Domain
{
    public class Utente
    {
        [Key]
        public Guid IDUtente { get; set; }
        public string Username { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime DataNascita { get; set; }
        public string Indirizzo { get; set; }
       // public Lista CarrelloUtente { get; set; }
        public bool isAdmin { get; set; }

        public Utente() { }
        public Utente(string username, string nome, string cognome, string email, string password, string telefono,
            DateTime dataNascita, string indirizzo, /*Lista carrelloUtente,*/ bool IsAdmin)
        {
            Username = username;
            Nome = nome;
            Cognome = cognome;
            Email = email;
            Password = password;
            Telefono = telefono;
            DataNascita = dataNascita;
            Indirizzo = indirizzo;
            //CarrelloUtente = carrelloUtente;
            isAdmin = IsAdmin;
        }

     

    }
}
