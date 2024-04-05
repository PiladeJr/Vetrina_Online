using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Domain;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //public DbSet<Lista> Lista_utenti { get; set; }
        public DbSet<Prodotto> Magazzino { get; set; }
        public DbSet<Utente> Utenti { get; set; }
    }
}
