using System;

namespace Poliformismo
{
    class Program
    {
        static void Main(string[] args)
        {
            string nome, cognome, matricola;
            int ore1 = 0, ore2 = 0, ore3 = 0;
            Console.WriteLine($"Dati dell'operaio");
            Console.WriteLine("Nome:");
            nome = Console.ReadLine();
            Console.WriteLine("Cognome");
            cognome = Console.ReadLine();
            Console.WriteLine("Matricola");
            matricola = Console.ReadLine();
            Operaio o = new Operaio()
            {
                nome = nome,
                cognome = cognome,
                matricola = matricola
            };
            Console.WriteLine($"Dati dell'impiegato");
            Console.WriteLine("Nome:");
            nome = Console.ReadLine();
            Console.WriteLine("Cognome");
            cognome = Console.ReadLine();
            Console.WriteLine("Matricola");
            matricola = Console.ReadLine();
            Impiegato i = new Impiegato()
            {
                nome = nome,
                cognome = cognome,
                matricola = matricola
            };
            Console.WriteLine($"Dati del dirigente");
            Console.WriteLine("Nome:");
            nome = Console.ReadLine();
            Console.WriteLine("Cognome");
            cognome = Console.ReadLine();
            Console.WriteLine("Matricola");
            matricola = Console.ReadLine();
            Dirigente d = new Dirigente()
            {
                nome = nome,
                cognome = cognome,
                matricola = matricola
            };
            Console.WriteLine("Orario dell'operaio:");
            ore1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Orario dell'impiegato:");
            ore2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Orario del dirigente:");
            ore3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"OPERAIO\nNome: {o.nome}\nCognome: {o.cognome}\nMatricola: {o.matricola}\nRetribuzione oraria: {o.RetribuzioneOraria(ore1)}");
            Console.WriteLine($"IMPIEGATO\nNome: {i.nome}\nCognome: {i.cognome}\nMatricola: {i.matricola}\nRetribuzione oraria: {i.RetribuzioneOraria(ore2)}");
            Console.WriteLine($"DIRIGENTE\nNome: {d.nome}\nCognome: {d.cognome}\nMatricola: {d.matricola}\nRetribuzione oraria: {d.RetribuzioneOraria(ore3)}");
        }
    }
}
