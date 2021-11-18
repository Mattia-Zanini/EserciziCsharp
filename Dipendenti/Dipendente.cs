namespace Dipendenti
{
    public class Dipendente : Persona
    {
        public int Matricola { get; set; }
        public int Rettribuzione { get; set; }
        new public string Informazioni()//"new" nasconde in modo esplicito il metodo ereditato "Informazioni" dalla classe base, sostituendola
        {
            return $"Badge: {Badge} Cognome: {Cognome} Nome: {Nome} Matricola: {Matricola} Rettribuzione: {Rettribuzione}";
        }
    }
}