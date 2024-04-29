using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApp.Data;
using WebApp.Modelli;
using WebApp.Models;
using WebApp.Servizi;

namespace WebApp.Controllers
{

    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Utente> _utente;
        private readonly ProdottoServizi _prodottoServizi;
        private readonly CarrelloServizi _carrelloServizi;
        private readonly UserManager<IdentityUser> _userManager;


        public HomeController(ILogger<HomeController> logger, UserManager<Utente> utente, ApplicationDbContext _dbContext)
        {
            _utente = utente;
            _logger = logger;
            _prodottoServizi = new ProdottoServizi(_dbContext);


        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var ProdottiTotali = await _prodottoServizi.GetProdottiAsync();
            return View(ProdottiTotali);
            //ViewData["UtenteID"]=_utente.GetUserId(this.User);
        }
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [Route("/Carrello")]
        //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Carrello()
        {
            return View("~/Views/Carrello/IndexCarrello.cshtml");
        }

        [AllowAnonymous]
        public IActionResult Prodotti()
        {
            return View("~/Views/Prodotto/AggiungiProdotto.cshtml");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
