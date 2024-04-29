using WebApp.EnumFolder;
using WebApp.Modelli;

public class ProdottoClonato
{
    public Guid IDProdottoClonato { get; set; }
    public string Immagine { get; set; }
    public string Nome { get; set; }
    public string Descrizione { get; set; }
    public decimal Prezzo { get; set; }
    public int QuantitaOrdinati { get; set; } = 0;
    public EnumWebApp.Categoria Categoria { get; set; }
    public EnumWebApp.Taglia Taglia { get; set; }
    public string Colore { get; set; }
    public Guid IDCarrelloAssociato { get; set; }
    public virtual Carrello CarrelloAssociato { get; set; }
    //public Guid IDOrdineAssociato { get; set; }
    //public virtual Ordine OrdineAssociato  { get; set; }



    public ProdottoClonato()
    {

    }

    public ProdottoClonato(Prodotto prodotto)
    {
        IDProdottoClonato = Guid.NewGuid();
        Nome = prodotto.Nome;
        Immagine = prodotto.Immagine;
        Descrizione = prodotto.Descrizione;
        Prezzo = prodotto.Prezzo;
        Categoria = prodotto.Categoria;
        Taglia = prodotto.Taglia;
        Colore = prodotto.Colore;
    }
}
