using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UtenteController : Controller
    {
        [HttpGet]
        public IActionResult Registrazione()
        {
            return View();
        }
    }
}
