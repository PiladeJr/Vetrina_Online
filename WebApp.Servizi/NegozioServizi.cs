using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Modelli;

namespace WebApp.Servizi
{
    public class NegozioServizi
    {
        private readonly ApplicationDbContext _dbContext;

        public NegozioServizi(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Negozio>> GetNegozioAsync() 
        { 
            var modello = await _dbContext.Negozio.ToListAsync();
            return modello;
        }
    }
}
