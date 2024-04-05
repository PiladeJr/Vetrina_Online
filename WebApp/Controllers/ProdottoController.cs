using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ProdottoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
