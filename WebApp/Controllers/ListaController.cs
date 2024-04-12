using Microsoft.AspNetCore.Mvc;
using WebApp.Servizi;

namespace WebApp.Controllers
{
    public class ListaController : Controller
    {
        private readonly ListaServizi _listaServizi;

        public ListaController(ListaServizi listaServizi)
        {
            _listaServizi = listaServizi;
        }

        // Azione per calcolare il prezzo totale dei prodotti nel carrello
        public IActionResult CalcolaPrezzoTotale()
        {
            decimal prezzoTotale = _listaServizi.CalcoloPrezzoTotale();
            return View(prezzoTotale);
        }

        // Azione per ottenere la quantità totale dei prodotti nel carrello
        public IActionResult QuantitaProdottiTotale()
        {
            int quantitaProdotti = _listaServizi.QuantitaProdottiTotale();
            return View(quantitaProdotti);
        }

        // Azione per svuotare il carrello
        [HttpPost]
        public IActionResult SvuotaCarrello()
        {
            _listaServizi.SvuotaCarrello();
            return RedirectToAction("Index", "Home"); // Redirect alla home page dopo lo svuotamento del carrello
        }
    }
}
