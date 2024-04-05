using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class MagazzinoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
