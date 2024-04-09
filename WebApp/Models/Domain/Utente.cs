using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Domain
{
    public class Utente :IdentityUser
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string Indirizzo { get; set; }
        public bool isAdmin { get; set; }

        public Utente() { }
        public Utente(string nome, string cognome, DateTime dataNascita, string indirizzo, bool IsAdmin)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            Indirizzo = indirizzo;
            isAdmin = IsAdmin;
        }
    }
}
