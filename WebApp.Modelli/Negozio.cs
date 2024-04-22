using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Modelli
{
    public class Negozio
    {
        public Guid IDNegozio { get; set; }
        public ICollection <Prodotto> Prodotti_Negozio { get; set; } = new List<Prodotto>();

        public Negozio() { }

        public Negozio(ICollection<Prodotto> prodotti_negozio) 
        {
            Prodotti_Negozio=prodotti_negozio;
        }
    }

}
