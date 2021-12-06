using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ListeOggettiScrittura
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lines = new List<string>();
            List<Prodotto> prodotti = new List<Prodotto>();
            List<string> output = new List<string>();
            lines = File.ReadAllLines("output.txt").ToList();
            foreach (string line in lines)
            {
                string[] item = line.Split(',');
                Prodotto p = new Prodotto(item[0], Convert.ToInt32(item[1]), Convert.ToDouble(item[2]));
                prodotti.Add(p);
            }
            foreach (Prodotto good in prodotti)
            {
                Console.WriteLine(good);
            }
            Console.WriteLine("Scrivi il nome di un prodotto da aggiungere");
            string prodotto = Console.ReadLine();
            Console.WriteLine("Scrivi la quantità");
            string quantita = Console.ReadLine();
            Console.WriteLine("Scrivi il prezzo");
            string prezzo = Console.ReadLine();
            prodotti.Add(new Prodotto(prodotto, Convert.ToInt32(quantita), Convert.ToDouble(prezzo)));
            Console.WriteLine("Prodotto aggiunto");
            foreach (Prodotto good in prodotti)
            {
                Console.WriteLine(good);
                output.Add(good.ToSave());
            }
            File.WriteAllLines("output.txt", output);
        }
    }
}
