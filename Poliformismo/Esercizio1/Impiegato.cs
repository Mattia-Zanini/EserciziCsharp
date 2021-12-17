namespace Esercizio1
{
    public class Impiegato : Dipendente
    {
        public override int RetribuzioneOraria(int ore)
        {
            int retribuzione = base.RetribuzioneOraria(ore);
            retribuzione += (retribuzione * 30) / 100;
            return retribuzione;
        }
    }
}