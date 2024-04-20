using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Modelli;

namespace WebApp.Servizi
{
    public class OrdineServizi
    {
        private readonly ApplicationDbContext _dbContext;

        public OrdineServizi(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Ordine>> GetOrdineAsync()
        {
            var modello = await _dbContext.Ordini.ToListAsync();
            return modello;
        }
    }
}
