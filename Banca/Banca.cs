namespace Banca
{
    public class Banca
    {
        protected int versamentoMax { get; }
        public Banca()
        {
            this.versamentoMax = 3000;
        }
        protected bool ValiditaVersamento(int saldo)
        {
            if (saldo > versamentoMax || saldo <= 0)
            {
                return false;
            }
            return true;
        }
        protected bool ValiditaPrelievo(int saldo)
        {
            if (saldo > versamentoMax || saldo <= 0)
            {
                return false;
            }
            return true;
        }
    }
}