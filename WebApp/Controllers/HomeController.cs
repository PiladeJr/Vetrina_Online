﻿using Microsoft.AspNetCore.Authorization;
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

        public IActionResult Index()
        {
            return View("~/Views/Vetrina/Index.cshtml");
            //ViewData["UtenteID"]=_utente.GetUserId(this.User);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Carrello()
        {
            return View("~/Views/Vetrina/Carrello.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
