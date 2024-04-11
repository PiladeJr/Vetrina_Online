using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebApp.Modelli;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<Utente>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Lista> Lista { get; set; }
        public DbSet<Prodotto> Prodotto { get; set; }
        public DbSet<Utente> Utenti { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Prodotto>()
                .HasKey(p => p.IDProdotto);
            builder.Entity<Lista>()
                .HasKey(p => p.IDLista);
            builder.Entity<Utente>()
                .HasKey(p => p.Id);
            builder.Entity<Lista>()
                .HasOne<Utente>()
                .WithOne()
                .HasForeignKey<Lista>(u => u.Id)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Prodotto>()
                .HasOne<Lista>()
                .WithMany()
                .HasForeignKey(p => p.IDLista)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}

