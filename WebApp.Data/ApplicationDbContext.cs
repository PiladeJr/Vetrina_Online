using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Modelli;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<Utente>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }   
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Prodotto> Prodotti { get; set; }
        public DbSet<Negozio> Negozio { get; set; }
        public DbSet<Ordine> Ordini { get; set; }
        public DbSet<ProdottoOrdinato> ProdottiOrdinati { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Utente>()
                .HasKey(n => n.Id);
            builder.Entity<Prodotto>()
                .HasKey(n => n.IDProdotto);
            builder.Entity<Negozio>()
                .HasKey(n => n.IDNegozio);
            builder.Entity<Ordine>()
                .HasKey(n => n.IDOrdine);
            builder.Entity<ProdottoOrdinato>()
                .HasKey(n => n.IDProdottoOrdinato);

            builder.Entity<Prodotto>()
                .HasOne(n => n.negozioAssociato)
                .WithMany(n => n.Prodotti_Negozio)
                .HasForeignKey(p => p.IDNegozio)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ProdottoOrdinato>(n =>
            {
                n.HasOne(n => n.ProdottoAssociato)
                .WithMany()
                .HasForeignKey(p => p.IDProdotto)
                .OnDelete(DeleteBehavior.Cascade);
                n.HasOne(n => n.OrdineAssociato)
                .WithMany(n =>n.ProdottiOrdinati)
                .HasForeignKey(p => p.IDOrdine)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Ordine>()
                .HasOne(n =>n.UtenteAssociato)
                .WithOne()
                .HasForeignKey<Ordine>(n => n.Id)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}

