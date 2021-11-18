using System;

namespace Dipendenti
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p = new Persona()
            {
                Badge = 1,
                Cognome = "Da Vinci",
                Nome = "Leonardo"
            };
            Dipendente d = new Dipendente()
            {
                Badge = 2,
                Cognome = "Buonarroti",
                Nome = "Michelangelo",
                Matricola = 1,
                Rettribuzione = 100
            };
            Collaboratore c = new Collaboratore()
            {
                Badge = 3,
                Cognome = "Vecellio",
                Nome = "Tiziano",
                Azienda = "Abc"
            };
            Console.WriteLine(p.Informazioni());
            Console.WriteLine(d.Informazioni());
            Console.WriteLine(c.Informazioni());
        }
    }
}