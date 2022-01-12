namespace Esercizio3
{
    public class Aerei
    {
        public string codaereo { get; set; }
        public string tipo { get; set; }
        public string nome { get; set; }
        public virtual double CostoMezzoUtilizzato()
        {
            return 5000000;
        }
        public virtual int CostoUtilizzoMezzo(int km)
        {
            return km;
        }
    }
}