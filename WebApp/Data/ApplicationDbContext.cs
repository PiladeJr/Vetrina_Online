using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Modelli;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //public DbSet<Lista> Lista_utenti { get; set; }
        public DbSet<Prodotto> Liste { get; set; }
        public DbSet<Prodotto> Prodotti { get; set; }
        public DbSet<Utente> Utenti { get; set; }
    }
}
