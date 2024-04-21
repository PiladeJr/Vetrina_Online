using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Modelli;
using WebApp.Servizi;

namespace WebApp.Controllers
{
   // [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class ListaController : Controller
    {
        private readonly ListaServizi _listaServizi;

        public ListaController(ApplicationDbContext _dbcontext)
        {
            _listaServizi = new ListaServizi(_dbcontext);
        }

        [HttpGet]
        [Route("/IndexLista")]
        public IActionResult IndexLista()
        {
            return View();
        }

        [HttpPost]
        [Route("/SvuotaCarrello")]
        public IActionResult SvuotaCarrello()
        {
            _listaServizi.SvuotaCarrello();
            return RedirectToAction("Index", "Home"); // Redirect alla home page dopo lo svuotamento del carrello
        }

        [HttpPost]
        [Route("/InvioProdotti")]
        public IActionResult InvioProdotti(List<Prodotto> prodottiDaInviare)
        {
            _listaServizi.InvioProdotti(prodottiDaInviare);
            return RedirectToAction("Index", "Home");
        }

        //Aggiungi ed elimina devono esser fatti da frontend: una volta preso il prezzo del prodotto, il bottone dovrà
        //semplicemente moltiplicare il prezzo per la quantità, la rimozione dovrà dividere per la quantità
        //[HttpPost]
        //[Route("lista/aggiungiprodottolista")]
        //public IActionResult AggiungiProdottoLista(Prodotto nuovoProdotto)
        //{
        //    _listaServizi.AggiungiProdottoLista(nuovoProdotto);
        //    return RedirectToAction("Index", "Home");
        //}

        //[HttpPost]
        //[Route("lista/eliminaprodottolista")]
        //public IActionResult EliminaProdottoLista(Guid prodottoId)
        //{
        //    _listaServizi.EliminaProdottoLista(prodottoId);
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //[Route("lista/quantitaprodottitotale")]
        //public IActionResult QuantitaProdottiTotale()
        //{
        //    int quantitaProdotti = _listaServizi.QuantitaProdottiTotale();
        //    return View(quantitaProdotti);
        //}

        //[HttpPost]
        //[Route("lista/calcolaprezzototale")]
        //public IActionResult CalcolaPrezzoTotale()
        //{
        //    decimal prezzoTotale = _listaServizi.CalcoloPrezzoTotale();
        //    return View(prezzoTotale);
        //}


    }
}
