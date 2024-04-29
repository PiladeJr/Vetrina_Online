﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApp.Data;
using WebApp.Modelli;
using WebApp.Servizi;

namespace WebApp.Controllers
{

    public class UtenteController : Controller
    {
        public readonly UtenteServizi _utenteServizi;

        public UtenteController(ApplicationDbContext _dbContext)
        {
            _utenteServizi = new UtenteServizi(_dbContext);
        }
        [HttpGet]
        [Route("/AreaPersonale")]
        [Authorize]
        public async Task<IActionResult> AreaPersonale()
        {
            string idUtente = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //bool ruolo = User.IsInRole("Admin");
            //var utente = new Utente
            //{
            //    Id = idUtente,
            //    isAdmin = ruolo,
            //};
            var areaPersonale = await _utenteServizi.GetUtenteByIdAsync(idUtente);
            return View(areaPersonale);
        }
        [HttpPost]
        [Route("/AreaPersonale")]
        [Authorize]
        public async Task<IActionResult> AreaPersonale(string id, string nome, string cognome, string phoneNumber, string email)
        {
            var utente = await _utenteServizi.GetUtenteByIdAsync(id);
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(cognome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber)) { RedirectToAction("AreaPersonale"); }

            if (await _utenteServizi.ControlloMail(email))
            {
                ModelState.AddModelError("Email", "L'email inserita è già associata a un altro utente.");
                return RedirectToAction("AreaPersonale");
            }
            utente.Nome = nome;
            utente.Cognome = cognome;
            utente.Email = email;
            utente.PhoneNumber = phoneNumber;

            await _utenteServizi.AggiornaUtente(utente);
            return RedirectToAction("AreaPersonale");
        }
    }
}

