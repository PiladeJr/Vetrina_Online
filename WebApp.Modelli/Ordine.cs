using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Modelli
{
    public class Ordine
    {
        public Guid IDOrdine { get; set; }

        public string Email { get; set; }

        public string Id { get; set; }
        public virtual Utente UtenteAssociato { get; set; }

        public ICollection<ProdottoOrdinato> ProdottiOrdinati { get; set; } = new List<ProdottoOrdinato>();
        public Ordine()
        {
        }

        // Costruttore con parametri
        public Ordine( string email, string id, Utente utente,ICollection<ProdottoOrdinato> prodottiOrdinati)
        {
            Email = email;
            Id = id;
            UtenteAssociato = utente;
            ProdottiOrdinati = prodottiOrdinati;
        }
    }
}
