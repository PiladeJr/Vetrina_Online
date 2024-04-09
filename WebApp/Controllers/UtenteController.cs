using Microsoft.AspNetCore.Mvc;
using WebApp.Servizi;

namespace WebApp.Controllers
{
   
        public class UtenteController : Controller
        {
            private readonly UtenteServizi utenteServizi;

            public UtenteController(UtenteServizi utenteServizi)
            {
                utenteServizi = utenteServizi;
            }

            // Azione per aggiornare i dettagli dell'utente
            [HttpPost]
            public IActionResult AggiornaDettagliUtente(string nome, string cognome, string email, string telefono, DateTime dataNascita, string indirizzo)
            {
                utenteServizi.AggiornaUtente(nome, cognome, email, telefono, dataNascita, indirizzo);
                return RedirectToAction("Index", "Home"); // Redirect alla home page dopo l'aggiornamento
            }

            // Azione per cambiare la password dell'utente
            [HttpPost]
            public IActionResult CambiaPassword(string nuovaPassword)
            {
                utenteServizi.CambiaPassword(nuovaPassword);
                return RedirectToAction("Index", "Home"); // Redirect alla home page dopo il cambio password
            }
        }
}

