namespace Dipendenti
{
    public class Persona
    {
        public int Badge { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }

        public string Informazioni()
        {
            return $"Badge: {Badge} Cognome: {Cognome} Nome: {Nome} ";
        }
    }
}