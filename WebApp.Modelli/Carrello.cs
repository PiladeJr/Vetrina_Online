using Microsoft.Extensions.DependencyInjection;
using WebApp.Modelli;

namespace WebApp.Modelli
{
    public class Carrello
    {
        public Guid IDCarrello { get; set; }
        public string IDUtenteAssociato { get; set; }
        public virtual ICollection<ProdottoClonato> prodottiClonati { get; set; } = null!;

        public Carrello()
        {

        }
    }
}
