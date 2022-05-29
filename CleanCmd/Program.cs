using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CleanCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lines = new List<string>();
            List<string> output = new List<string>();
            lines = File.ReadAllLines("comandi.txt").ToList();
            foreach (string line in lines)
            {
                string[] item = line.Split(' ');
                string row = "";
                for(int i = 5; i < item.Length; i++)
                {
                    if (i != item.Length - 1)
                    {
                        row += item[i] + " ";
                    }
                    else
                    {
                        row += item[i];
                    }
                }
                output.Add(row);
            }
            File.WriteAllLines("output.txt", output);
        }
    }
}
