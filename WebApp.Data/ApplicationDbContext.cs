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
        public DbSet<Prodotto> Prodotti { get; set; }
        public DbSet<Utente> Utenti { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Prodotto>()
                .HasKey(p => p.IDProdotto);
            builder.Entity<Lista>()
                .HasKey(l => l.IDLista);
            builder.Entity<Utente>()
                .HasKey(u => u.Id);
            builder.Entity<Lista>()
                .HasOne(u => u.UtenteAssociato)
                .WithOne()
                .HasForeignKey<Lista>(u => u.Id)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Prodotto>()
                .HasOne(p => p.listaAssociata)
                .WithMany(l => l.ListaProdotti)
                .HasForeignKey(p => p.IDLista)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}

