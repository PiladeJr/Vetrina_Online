using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class RegistrazioneVM
    {
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Cognome { get; set; }
        public string? Telefono { get; set; }
        [DataType(DataType.MultilineText)]
        public string? Indirizzo { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]

        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Le password non corrispondono")]
        [Display(Name = "Conferma Password")]
        [DataType(DataType.Password)]

        public string? ConfermaPassword { get; set;}

        

    }
}
