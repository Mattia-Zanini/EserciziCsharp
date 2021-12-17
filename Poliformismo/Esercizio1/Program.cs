using System;

namespace Esercizio1
{
    class Program
    {
        static void Main(string[] args)
        {
            int ore1 = 0, ore2 = 0, ore3 = 0;
            Operaio o = new Operaio();
            Impiegato i = new Impiegato();
            Dirigente d = new Dirigente();
            SetDati<Operaio>(ref o, "operaio");
            SetDati<Impiegato>(ref i, "impiegato");
            SetDati<Dirigente>(ref d, "dirigente");

            Console.WriteLine("Orario dell'operaio:");
            ore1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Orario dell'impiegato:");
            ore2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Orario del dirigente:");
            ore3 = Convert.ToInt32(Console.ReadLine());

            GetDati<Operaio>(ref o, "OPERAIO", ore1);
            GetDati<Operaio>(ref o, "IMPIEGATO", ore2);
            GetDati<Operaio>(ref o, "DIRIGENTE", ore3);
        }
        private static void SetDati<T>(ref T dipendete, string nomeDip) where T : Dipendente
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
        private static void GetDati<T>(ref T dipendete, string nomeDip, int ore) where T : Dipendente
        {
            Console.WriteLine($"{nomeDip}\nNome: {dipendete.nome}\nCognome: {dipendete.cognome}\nMatricola: {dipendete.matricola}\nRetribuzione oraria: {dipendete.RetribuzioneOraria(ore)}");
        }
    }
}
