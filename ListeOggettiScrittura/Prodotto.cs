namespace ListeOggettiScrittura
{
    public class Prodotto
    {
        public string prodotto { get; set; }
        public int quantita { get; set; }
        public double prezzo { get; set; }
        public Prodotto(string prodotto, int quantita, double prezzo)
        {
            this.prodotto = prodotto;
            this.quantita = quantita;
            this.prezzo = prezzo;
        }
        public override string ToString()
        {
            return $"Nome prodotto: {this.prodotto}\tQuantità: {this.quantita}\tPrezzo: {this.prezzo} euro";
        }
        public string ToSave()
        {
            return $"{this.prodotto},{this.quantita},{this.prezzo}";
        }
    }
}