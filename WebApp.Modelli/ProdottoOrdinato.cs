using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Modelli
{
    public class ProdottoOrdinato
    {
            //[Key]
            public Guid IDProdottoOrdinato { get; set; }

            public int Quantità { get; set; }
            public double Prezzo { get; set; }

            public Guid IDProdotto { get; set; }

            public virtual Prodotto ProdottoAssociato { get; set; }

            public Guid IDOrdine { get; set; }

            public virtual Ordine OrdineAssociato { get; set; }

        public ProdottoOrdinato() { }
        public ProdottoOrdinato(int quantità, double prezzo, Prodotto prodotto, Ordine ordine)
        {
            
            Quantità = quantità;
            Prezzo = prezzo;
            ProdottoAssociato = prodotto;
            OrdineAssociato = ordine;
        }
    }
}
