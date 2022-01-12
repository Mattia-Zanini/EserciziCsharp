using System;

namespace Esercizio3
{
    class Program
    {
        static void Main(string[] args)
        {
            Cargo c = new Cargo();
            Passeggeri p = new Passeggeri();
            SetDati<Cargo>(ref c);
            SetDati<Passeggeri>(ref p);
            Console.WriteLine("Scrivi il numero di km percorsi con il Cargo");
            int km1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Scrivi il numero di km percorsi con il Passeggeri");
            int km2 = Int32.Parse(Console.ReadLine());
            GetDati<Cargo>(ref c, "Cargo", km1);
            GetDati<Passeggeri>(ref p, "Passeggeri", km2);
        }
        private static void SetDati<T>(ref T aereo) where T : Aerei
        {
            string codaereo, tipo, nome;
            Console.WriteLine("Codice dell'aereo:");
            codaereo = Console.ReadLine();
            Console.WriteLine("Tipo dell'aereo:");
            tipo = Console.ReadLine();
            Console.WriteLine("Nome dell'aereo:");
            nome = Console.ReadLine();
            aereo.codaereo = codaereo;
            aereo.tipo = tipo;
            aereo.nome = nome;
        }
        private static void GetDati<T>(ref T aereo, string nomeAereo, int km) where T : Aerei
        {
            Console.WriteLine($"{nomeAereo}\nNome: {aereo.nome}\nTipo: {aereo.tipo}\nCodAereo: {aereo.codaereo}\nCosto Mezzo Utilizzato: {aereo.CostoMezzoUtilizzato()} euro\nCosto Utilizzo Mezzo: {aereo.CostoUtilizzoMezzo(km)} euro\n");
        }
    }
}