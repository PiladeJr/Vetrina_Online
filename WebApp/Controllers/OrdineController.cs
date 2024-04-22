using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Servizi;

namespace WebApp.Controllers
{
    public class OrdineController : Controller
    {
        private readonly OrdineServizi _ordineServizi;

        public OrdineController(ApplicationDbContext _dbcontext)
        {
            _ordineServizi = new OrdineServizi(_dbcontext);
        }
        public async Task<IActionResult> IndexOrdine()
        {
            var modello = await _ordineServizi.GetOrdineAsync();
            return View();
        }
    }
}
