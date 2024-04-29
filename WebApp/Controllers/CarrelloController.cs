using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Modelli;
using WebApp.Servizi;

namespace WebApp.Controllers
{
    //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class CarrelloController : Controller
    {
        private readonly CarrelloServizi _carrelloServizi;
        private readonly UserManager<Utente> _userManager;

        public CarrelloController(ApplicationDbContext _dbcontext, UserManager<Utente> userManager)
        {
            _carrelloServizi = new CarrelloServizi(_dbcontext);
            _userManager = userManager;
        }

        [HttpGet]
        [Route("/IndexCarrello")]
        [Authorize]
        public async Task<IActionResult> IndexCarrello()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;
            var carrello = await _carrelloServizi.GetCarrelloAsync(userId);
            carrello.prodottiClonati = await _carrelloServizi.ProdottiClonatiAsync(carrello);
            return View(carrello);
        }

        [HttpGet]
        [Route("/GetCarrelloProdotti")]
        public async Task<ActionResult<List<Prodotto>>> GetCarrelloProdottiAsync(string id)
        {
            var prodotti = await _carrelloServizi.GetCarrelloAsync(id);
            return View(prodotti);
        }

        [HttpGet]
        [Route("AggiungiProdottoCarrello")]
        [Authorize]
        public async Task<IActionResult> AggiungiProdottoCarrello()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("AggiungiProdottoCarrello")]
        [Authorize]
        public async Task<IActionResult> AggiungiProdottoCarrello(Guid id, int quantita = 1)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;
            var prodotto = await _carrelloServizi.GetProdottoIdAsync(id);
            if (prodotto != null)
            {
                await _carrelloServizi.AggiungiProdottoCarrello(userId, prodotto, quantita);
            }
            return RedirectToAction(/*"Index", "Home"*/"IndexCarrello");
        }

        [HttpGet]
        [Route("EliminaProdottoCarrello")]
        public async Task<IActionResult> EliminaProdottoCarrello()
        {
            return View();
        }

        [HttpPost]
        [Route("EliminaProdottoCarrello")]
        public async Task<IActionResult> EliminaProdottoCarrello(Guid id)
        {
            if(id == Guid.Empty) { return View(); }
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;
            var prodotto = await _carrelloServizi.GetProdottoIdAsync(id);
            await _carrelloServizi.EliminaProdottoCarrello(id, userId);

            return RedirectToAction("IndexCarrello", "Carrello");
        }

        [HttpPost]
        [Route("SvuotaCarrello")]
        public async Task<IActionResult> SvuotaCarrello()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;
            await _carrelloServizi.SvuotaCarrello(userId);
            return RedirectToAction("IndexCarrello", "Carrello");
        }

        [HttpGet]
        [Route("/InvioProdottiCarrello")]
        public async Task<IActionResult> InvioProdotti()
        {
            return View();
        }
        [HttpGet]
        [Route("/ErroreInvio")]
        public async Task<IActionResult> ErroreInvio() 
        {
            return View(); 
        }
        [HttpPost]
        [Route("/InvioProdottiCarrello")]
        public async Task<IActionResult> InvioProdottiCarrello(string id)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;
            if (await _carrelloServizi.InvioProdotti(userId)) 
            { return RedirectToAction("InvioProdotti"); }
            else { return View("ErroreInvio"); }
        }

        //[HttpPost]
        //[Route("/SvuotaCarrello")]
        //public IActionResult SvuotaCarrello()
        //{
        //    _CarrelloServizi.SvuotaCarrello();
        //    return RedirectToAction("IndexLista", "Lista"); // Redirect alla home page dopo lo svuotamento del carrello
        //}

        //[HttpPost]
        //[Route("/InvioProdotti")]
        //public IActionResult InvioProdotti(List<Prodotto> prodottiDaInviare)
        //{
        //    _CarrelloServizi.InvioProdotti(prodottiDaInviare);
        //    return RedirectToAction("Index", "Home");
        //}

        //Aggiungi ed elimina devono esser fatti da frontend: una volta preso il prezzo del prodotto, il bottone dovrà
        //semplicemente moltiplicare il prezzo per la quantità, la rimozione dovrà dividere per la quantità
        //[HttpPost]
        //[Route("lista/aggiungiprodottolista")]
        //public IActionResult AggiungiProdottoLista(Prodotto nuovoProdotto)
        //{
        //    _CarrelloServizi.AggiungiProdottoLista(nuovoProdotto);
        //    return RedirectToAction("Index", "Home");
        //}

        //[HttpPost]
        //[Route("lista/eliminaprodottolista")]
        //public IActionResult EliminaProdottoLista(Guid prodottoId)
        //{
        //    _CarrelloServizi.EliminaProdottoLista(prodottoId);
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //[Route("lista/quantitaprodottitotale")]
        //public IActionResult QuantitaProdottiTotale()
        //{
        //    int quantitaProdotti = _CarrelloServizi.QuantitaProdottiTotale();
        //    return View(quantitaProdotti);
        //}

        //[HttpPost]
        //[Route("lista/calcolaprezzototale")]
        //public IActionResult CalcolaPrezzoTotale()
        //{
        //    decimal prezzoTotale = _CarrelloServizi.CalcoloPrezzoTotale();
        //    return View(prezzoTotale);
        //}


    }
}
