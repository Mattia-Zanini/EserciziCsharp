namespace Dipendenti
{
    public class Collaboratore : Persona
    {
        public string Azienda { get; set; }
        new public string Informazioni()//"new" nasconde in modo esplicito il metodo ereditato "Informazioni" dalla classe base, sostituendola
        {
            return $"Badge: {Badge} Cognome: {Cognome} Nome: {Nome} Azienda: {Azienda}";
        }
    }
}