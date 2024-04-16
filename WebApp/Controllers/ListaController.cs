using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Modelli;
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

        [HttpGet]
        public IActionResult CalcolaPrezzoTotale()
        {
            decimal prezzoTotale = _listaServizi.CalcoloPrezzoTotale();
            return View(prezzoTotale);
        }

        [HttpGet]
        public IActionResult QuantitaProdottiTotale()
        {
            int quantitaProdotti = _listaServizi.QuantitaProdottiTotale();
            return View(quantitaProdotti);
        }

        [HttpPost]
        public IActionResult SvuotaCarrello()
        {
            _listaServizi.SvuotaCarrello();
            return RedirectToAction("Index", "Home"); // Redirect alla home page dopo lo svuotamento del carrello
        }

        [HttpPost]
        public IActionResult InvioProdotti(List<Prodotto> prodottiDaInviare)
        {
            _listaServizi.InvioProdotti(prodottiDaInviare);
            return RedirectToAction("Index", "Home");   
        }

    }
}
