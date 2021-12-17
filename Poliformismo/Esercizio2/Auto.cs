namespace Esercizio2
{
    public class Auto : Veicolo
    {
        public override int CostoVeicoloUsato()
        {
            return base.CostoVeicoloUsato() + (base.CostoVeicoloUsato() * 25) / 100;
        }
        public override int CostoUso(int km)
        {
            return km * 5;
        }
    }
}