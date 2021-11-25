using System;
using System.Collections.Generic;

namespace Liste
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lista = new List<string>();
            lista.Add("Pizza");
            lista.Add("Pomodoro");
            lista.Add("Mozzarella");
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }

            List<Animal> Animals = new List<Animal>();
            /*
            Animals.Add(new Animal("Larry", 10));
            Animals.Add(new Animal("Berry", 21));
            Animals.Add(new Animal("Jake", 4));
            */
            Console.WriteLine("Lista:");
            Animals.Add(new Animal { _name = "Larry", _age = 10 });
            Animals.Add(new Animal { _name = "Berry", _age = 21 });
            Animals.Add(new Animal { _name = "Jake", _age = 4 });
            foreach (var animals in Animals)
            {
                Console.WriteLine($"Name: {animals._name}\tAge: {animals._age}");
            }
            Console.WriteLine("Elementi lista in posizione 1:");
            Console.WriteLine(Animals[1]._name);
            Console.WriteLine("Scritta la lista in un metodo alternativo");
            foreach (var animals in Animals)
            {
                Console.WriteLine(animals);
            }
            Console.WriteLine("Rimozione dell'elemento 'Larry' dalla lista:\t\t[ Animals.Remove(new Animal { _name = 'Larry', _age = 4 }); ]");
            Animals.Remove(new Animal { _name = "Larry", _age = 4 });
            foreach (var animals in Animals)
            {
                Console.WriteLine(animals);
            }
            Console.WriteLine("Rimozione fallita, perchè non è stato inserito anche l'età corretta");
        }
    }
}
