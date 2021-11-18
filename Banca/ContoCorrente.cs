namespace Banca
{
    public class ContoCorrente : Banca
    {
        public int conto { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public int Versamento(int saldo)
        {
            if (!base.ValiditaVersamento(saldo))
            {
                return -1;
            }
            else
                this.conto += saldo; return 0;
        }
        public int Prelievo(int saldo)
        {
            if (this.conto <= 0 || !base.ValiditaPrelievo(saldo))
            {
                return -1;
            }
            else
                this.conto -= saldo; return 0;
        }
        public bool ValiditaConto()
        {
            if (this.conto > 0)
            {
                return true;
            }
            return false;
        }
        public string GetInfo()
        {
            return $"Nome: {nome} Cognome: {cognome} Conto: {conto}";
        }
    }
}