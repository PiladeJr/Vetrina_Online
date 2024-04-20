namespace WebApp.Modelli
{
    public class Lista
    {
        public Guid IDLista { get; set; }
        public virtual ICollection<Prodotto> ListaProdotti { get; set; } = new List<Prodotto>();
        public int QuantitaProdotti { get; set; }
        public decimal PrezzoTotale { get; set; }
        public string Id { get; set; }
        public virtual Utente UtenteAssociato { get; set; }

        public Lista() { }
        public Lista(int quantitaProdotti, decimal prezzoTotale, ICollection<Prodotto> listaProdotti)
        {
            ListaProdotti = listaProdotti;
            QuantitaProdotti = quantitaProdotti;
            PrezzoTotale = prezzoTotale;
        }
    }
}
