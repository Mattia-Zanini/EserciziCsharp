namespace Esercizio2
{
    public class Furgone : Veicolo
    {
        public override int CostoVeicoloUsato()
        {
            return base.CostoVeicoloUsato() + (base.CostoVeicoloUsato() * 40) / 100;
        }
        public override int CostoUso(int km)
        {
            return km * 10;
        }
    }
}