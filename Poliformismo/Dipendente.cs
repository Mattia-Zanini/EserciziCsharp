namespace Poliformismo
{
    public class Dipendente
    {
        public string matricola { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public virtual int RetribuzioneOraria(int ore)
        {
            return ore * 35;
        }
    }
}