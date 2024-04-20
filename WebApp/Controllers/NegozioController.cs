using Microsoft.AspNetCore.Mvc;
using WebApp.Servizi;

namespace WebApp.Controllers
{
    public class NegozioController : Controller
    {
        private readonly NegozioServizi _negozioServizi;

        public NegozioController(NegozioServizi negozioServizi)
        {
            _negozioServizi = negozioServizi;
        }
        public async Task<IActionResult> IndexNegozio()
        {
            var modello = await _negozioServizi.GetNegozioAsync();
            return View();
        }
    }
}
