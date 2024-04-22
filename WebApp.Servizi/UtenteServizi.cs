using WebApp.Data;
using WebApp.Modelli;
namespace WebApp.Servizi
{
    public class UtenteServizi
    {
        private readonly ApplicationDbContext _dbContext;

        public UtenteServizi(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}