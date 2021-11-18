using System;

namespace Banca
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scrivi il tuo nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Scrivi il tuo cognome");
            string cognome = Console.ReadLine();
            Console.WriteLine("Quanti soldi hai nel conto?");
            int conto = int.Parse(Console.ReadLine());
            ContoCorrente cc = new ContoCorrente()
            {
                nome = nome,
                cognome = cognome,
                conto = conto
            };
            if (cc.ValiditaConto())
            {
                Console.WriteLine("Il conto è valido");
                Console.WriteLine("Inserisci il valore di un prelievo");
                int prelievo = int.Parse(Console.ReadLine());
                if (cc.Prelievo(prelievo) != -1)
                {
                    Console.WriteLine("Il prelievo è valido");
                    Console.WriteLine("Inserisci un versamento");
                    int versamento = int.Parse(Console.ReadLine());
                    if (cc.Versamento(versamento) != -1)
                    {
                        Console.WriteLine("Il versamento è valido");
                        Console.WriteLine(cc.GetInfo());
                    }
                }
            }
        }
    }
}
