namespace Esercizio3
{
    public class Cargo : Aerei
    {
        public override double CostoMezzoUtilizzato()
        {
            return (base.CostoMezzoUtilizzato() * 1.35);
        }
        public override int CostoUtilizzoMezzo(int km)
        {
            return (base.CostoUtilizzoMezzo(km) * 500);
        }
    }
}