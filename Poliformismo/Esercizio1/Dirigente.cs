namespace Esercizio1
{
    public class Dirigente : Dipendente
    {
        public override int RetribuzioneOraria(int ore)
        {
            int retribuzione = base.RetribuzioneOraria(ore);
            retribuzione += (retribuzione * 50) / 100;
            return retribuzione;
        }
    }
}