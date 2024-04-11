using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;
using WebApp.Servizi;

namespace WebApp.Controllers
{

    public class UtenteController : Controller
    {
        private readonly UtenteServizi _utenteServizi;
        public UtenteController(UtenteServizi utenteServizi)
        {
            _utenteServizi = utenteServizi;
        }
        // Azione per aggiornare i dettagli dell'utente
        [HttpPost("aggiorna-utente")]
        public IActionResult AggiornaUtente(string nome, string cognome, DateTime dataNascita, string indirizzo)
        {
            _utenteServizi.AggiornaUtente(nome, cognome, dataNascita, indirizzo);
            return RedirectToAction("Index", "Home"); // Redirect alla home page dopo l'aggiornamento
        }

        // Azione per cambiare la password dell'utente
        [HttpPost("cambio-password")]
        public IActionResult CambioPassword(string nuovaPassword)
        {
            _utenteServizi.CambioPassword(nuovaPassword);
            return RedirectToAction("Index", "Home"); // Redirect alla home page dopo il cambio password
        }

    } 
        
}

