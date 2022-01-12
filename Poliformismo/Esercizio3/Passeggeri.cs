namespace Esercizio3
{
    public class Passeggeri : Aerei
    {
        public override double CostoMezzoUtilizzato()
        {
            return (base.CostoMezzoUtilizzato() * 1.45);
        }
        public override int CostoUtilizzoMezzo(int km)
        {
            return (base.CostoUtilizzoMezzo(km) * 750);
        }
    }
}