using WebApp.EnumFolder;

namespace WebApp.ViewModel
{
    public class ProdottoVM
    {
        public Guid IDProdotto { get; set; }
        public string Nome { get; set; }
        public IFormFile Immagine { get; set; }
        public string Descrizione { get; set; }
        public decimal Prezzo { get; set; }
        public int Quantita { get; set; }
        public EnumWebApp.Categoria Categoria { get; set; }
        public EnumWebApp.Taglia Taglia { get; set; }
        public string Colore { get; set; }
    }
}
