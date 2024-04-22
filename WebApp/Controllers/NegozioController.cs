using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Servizi;

namespace WebApp.Controllers
{
    public class NegozioController : Controller
    {
        //private readonly ApplicationDbContext _dbcontext;
        private  NegozioServizi _negozioServizi;
        
        public NegozioController(ApplicationDbContext _dbcontext) 
        {
            _negozioServizi = new NegozioServizi( _dbcontext );
        }
        // private readonly ApplicationDbContext _dbContext;

        //public NegozioController(ApplicationDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        public async Task<IActionResult> IndexNegozio()
        {
             var modello = await _negozioServizi.GetNegozioAsync();
            //var modello = await _dbContext.Negozio.ToListAsync();

            return View(modello);
        }
    }
}
