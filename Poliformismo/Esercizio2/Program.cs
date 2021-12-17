using System;

namespace Esercizio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto a = new Auto();
            Furgone f = new Furgone();
            GetDati<Auto>(ref a);
            GetDati<Furgone>(ref f);
            int km1 = 0, km2 = 0;
            Console.WriteLine("Km percorsi auto:");
            km1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Km percorsi furgone:");
            km2 = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine($"AUTO\n{a.ToString()}\nCosto uso veicolo per {km1}km: {a.CostoUso(km1)} euro\n");
            Console.WriteLine($"FURGONE\n{f.ToString()}\nCosto uso veicolo per {km2}km: {f.CostoUso(km2)} euro\n");
        }
        private static void GetDati<T>(ref T veicolo) where T : Veicolo
        {
            string codveicolo, tipo, nome, marca;
            Console.WriteLine("Codice del veicolo:");
            codveicolo = Console.ReadLine();
            Console.WriteLine("Tipo del veicolo:");
            tipo = Console.ReadLine();
            Console.WriteLine("Nome del veicolo:");
            nome = Console.ReadLine();
            Console.WriteLine("Marca del veicolo:");
            marca = Console.ReadLine();
            veicolo.codveicolo = codveicolo;
            veicolo.tipo = tipo;
            veicolo.nome = nome;
            veicolo.marca = marca;
        }
    }
}
