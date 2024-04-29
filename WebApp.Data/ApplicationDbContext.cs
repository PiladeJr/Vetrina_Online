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
        //public DbSet<Ordine> Ordini { get; set; }
        public DbSet<Carrello> CarrelloProdotti { get; set; }

        public DbSet<ProdottoClonato> DettagliCarrello { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Utente>()
                .HasKey(n => n.Id);
            builder.Entity<Prodotto>()
                .HasKey(n => n.IDProdotto);
            //builder.Entity<Ordine>()
            //    .HasKey(n => n.IDOrdine);
            builder.Entity<ProdottoClonato>()
                .HasKey(p => p.IDProdottoClonato);

            base.OnModelCreating(builder);

            builder.Entity<Carrello>()
                .HasKey(n => n.IDCarrello);
            //builder.Entity<Ordine>()
            //    .HasOne(n => n.UtenteAssociato)
            //    .WithMany(n => n.OrdiniUtente)
            //    .HasForeignKey(n => n.IdUtente)
            //    .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Carrello>()
                .HasMany(n => n.prodottiClonati)
                .WithOne(n => n.CarrelloAssociato)
                .HasForeignKey(n => n.IDCarrelloAssociato)
                .OnDelete(DeleteBehavior.Cascade);
            //builder.Entity<ProdottoClonato>()
                //.HasOne(n=>n.OrdineAssociato)
                //.WithMany(n=>n.prodottiClonati)
                //.HasForeignKey(n=>n.IDOrdineAssociato)
                //.OnDelete(DeleteBehavior.Cascade);
                //builder.Entity<Ordine>( o =>
                //{
                //    o.HasOne(n => n.UtenteAssociato)
                //    .WithMany(n => n.OrdiniUtente)
                //    .HasForeignKey(n => n.IdUtente)
                //    .OnDelete(DeleteBehavior.Cascade);
                //    o.HasMany(n => n.prodottiClonati)
                //    .WithOne(n => n.OrdineAssociato)
                //    .HasForeignKey(n => n.IDOrdineAssociato)
                //    .OnDelete(DeleteBehavior.Cascade);
                //});
        }
    }
}

