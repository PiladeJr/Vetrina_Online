using Microsoft.AspNetCore.Mvc;
using WebApp.Servizi;

namespace WebApp.Controllers
{
    public class OrdineController : Controller
    {
        private readonly OrdineServizi _ordineServizi;

        public OrdineController(OrdineServizi ordineServizi)
        {
            _ordineServizi = ordineServizi;
        }
        public async Task<IActionResult> IndexOrdine()
        {
            var modello = await _ordineServizi.GetOrdineAsync();
            return View();
        }
    }
}
