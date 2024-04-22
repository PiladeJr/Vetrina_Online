namespace WebApp.Modelli
{
    public class Lista
    {
        public Guid IDLista { get; set; }
        public Guid IDListaProdotti { get; set; }
        public int QuantitaProdotti { get; set; }
        public virtual Prodotto ProdottoAssociato { get; set; }
    }
}
