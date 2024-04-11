using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ListaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
