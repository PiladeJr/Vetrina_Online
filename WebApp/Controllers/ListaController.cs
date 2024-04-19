using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Modelli;
using WebApp.Servizi;

namespace WebApp.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class ListaController : Controller
    {
        private readonly ListaServizi _listaServizi;

        public ListaController(ListaServizi listaServizi)
        {
            _listaServizi = listaServizi;
        }

        [HttpGet]
        [Route("lista/index")]
        public IActionResult IndexLista()
        {
            return View();
        }

        [HttpPost]
        [Route("lista/calcolaprezzototale")]
        public IActionResult CalcolaPrezzoTotale()
        {
            decimal prezzoTotale = _listaServizi.CalcoloPrezzoTotale();
            return View(prezzoTotale);
        }

        [HttpPost]
        [Route("lista/quantitaprodottitotale")]
        public IActionResult QuantitaProdottiTotale()
        {
            int quantitaProdotti = _listaServizi.QuantitaProdottiTotale();
            return View(quantitaProdotti);
        }

        [HttpPost]
        [Route("lista/svuotacarrello")]
        public IActionResult SvuotaCarrello()
        {
            _listaServizi.SvuotaCarrello();
            return RedirectToAction("Index", "Home"); // Redirect alla home page dopo lo svuotamento del carrello
        }

        [HttpPost]
        [Route("lista/invioprodotti")]
        public IActionResult InvioProdotti(List<Prodotto> prodottiDaInviare)
        {
            _listaServizi.InvioProdotti(prodottiDaInviare);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("lista/aggiungiprodottolista")]
        public IActionResult AggiungiProdottoLista(Prodotto nuovoProdotto)
        {
            _listaServizi.AggiungiProdottoLista(nuovoProdotto);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("lista/eliminaprodottolista")]
        public IActionResult EliminaProdottoLista(Guid prodottoId)
        {
            _listaServizi.EliminaProdottoLista(prodottoId);
            return RedirectToAction("Index");
        }

    }
}
