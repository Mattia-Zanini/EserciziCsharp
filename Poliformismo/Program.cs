using System;

namespace Poliformismo
{
    class Program
    {
        static void Main(string[] args)
        {
            int ore1 = 0, ore2 = 0, ore3 = 0;
            Operaio o = new Operaio();
            Impiegato i = new Impiegato();
            Dirigente d = new Dirigente();
            GetDati<Operaio>(ref o, "operaio");
            GetDati<Impiegato>(ref i, "impiegato");
            GetDati<Dirigente>(ref d, "dirigente");
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
        private static void GetDati<T>(ref T dipendete, string nomeDip) where T : Dipendente
        {
            string nome, cognome, matricola;
            Console.WriteLine($"Dati {nomeDip}");
            Console.WriteLine("Nome:");
            nome = Console.ReadLine();
            Console.WriteLine("Cognome");
            cognome = Console.ReadLine();
            Console.WriteLine("Matricola");
            matricola = Console.ReadLine();
            dipendete.nome = nome;
            dipendete.cognome = cognome;
            dipendete.matricola = matricola;
        }
    }
}
