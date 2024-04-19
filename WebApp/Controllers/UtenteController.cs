//using Microsoft.AspNetCore.Mvc;

//namespace WebApp.Controllers
//{
//    public class UtenteController : Controller
//    {
//        [HttpGet]
//        public IActionResult Registrazione()
//        {
//            return View();
//        }
//    }
//}
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Servizi;

namespace WebApp.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class UtenteController : Controller
    {
        private readonly UtenteServizi _utenteServizi;
        public UtenteController(UtenteServizi utenteServizi)
        {
            _utenteServizi = utenteServizi;
        }
        // Azione per aggiornare i dettagli dell'utente
        [HttpPost("aggiorna-utente")]
        public IActionResult AggiornaUtente(string nome, string cognome, string email, string cellulare)
        {
            _utenteServizi.AggiornaUtente(nome, cognome, email, cellulare);
            return RedirectToAction("Index", "Home"); // Redirect alla home page dopo l'aggiornamento
        }

        // Azione per cambiare la password dell'utente
        [HttpPost("cambio-password")]
        public async Task<IActionResult> CambioPassword(string email, string vecchiaPassword, string nuovaPassword)
        {
            bool cambioPasswordRiuscito = _utenteServizi.CambiaPassword(email, vecchiaPassword, nuovaPassword);

            if (cambioPasswordRiuscito)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "La vecchia password è errata.");
                return View();
            }
        }

    }

}