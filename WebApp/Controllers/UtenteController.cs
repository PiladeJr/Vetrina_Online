//using Microsoft.AspNetCore.Mvc;

//namespace WebApp.Controllers
//{
//    public class UtenteController : Controller
//    {
//        [HttpGet]
//        public IActionResult Registrazione()
//        {
//            return View();
//        }
//    }
//}
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Servizi;

namespace WebApp.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class UtenteController : Controller
    {
        private readonly UtenteServizi _utenteServizi;
        public UtenteController(ApplicationDbContext _dbContext)
        {
            _utenteServizi = new UtenteServizi(_dbContext);
        }

    }

}