using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Domain;
using WebApp.ViewModels;

namespace WebApp.Controllers
{   
    
    public class AccountController : Controller
    {
        private readonly SignInManager<Utente> signInManager;
        private readonly UserManager<Utente> userManager;

        public AccountController(SignInManager<Utente> signInManager)
        {
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("/Registazione")]
        public async Task<IActionResult> Registrazione(RegistrazioneVM model)
        {
            if (ModelState.IsValid)
            {
                Utente utente = new()
                {
                    Nome = model.Nome,
                    Cognome = model.Cognome,
                    PhoneNumber = model.Telefono,
                    Indirizzo = model.Indirizzo,
                    Email = model.Email,
                    PasswordHash = model.Password
                };
                var result = await userManager.CreateAsync(utente, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(utente, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("/Login")]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
               var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe, false);
                if (result.Succeeded)
                { 
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Login non valido");
            }
            
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index));
        }
    }
}
