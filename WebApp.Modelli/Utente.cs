using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Modelli

{
    public class Utente : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string Nome { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(60)")]
        public string Cognome { get; set; }
        [PersonalData]
        [Column(TypeName = "date")]
        public DateTime DataNascita { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
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
