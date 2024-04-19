using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Modelli;
using WebApp.Models;

namespace WebApp.Controllers
{

    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Utente> _utente;

        public HomeController(ILogger<HomeController> logger, UserManager<Utente> utente)
        {
            _utente = utente;
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
            //ViewData["UtenteID"]=_utente.GetUserId(this.User);
        }
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        [Route("/AreaPersonale")]
        [Authorize]
        public IActionResult AreaPersonale()
        {
            return View("~/Views/Vetrina/AreaPersonale.cshtml");
        }
        [HttpGet]
        [Route("/Carrello")]
        [Authorize]
        public IActionResult Carrello()
        {
            return View("~/Views/Vetrina/Carrello.cshtml");
        }
        [AllowAnonymous]
        public IActionResult Prodotti()
        {
            return View("~/Views/Vetrina/Prodotti.cshtml");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
