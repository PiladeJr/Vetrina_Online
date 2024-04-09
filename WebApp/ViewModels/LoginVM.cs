using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Username non inserito")]
        public string? Username { get; set; }
       
        [Required(ErrorMessage = "Password non inserita")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Ricordami")]
        public bool RememberMe { get; set; }
    }
}
