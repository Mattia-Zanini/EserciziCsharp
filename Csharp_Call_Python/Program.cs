using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace prova
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Esecuzione del programma python");
            run_cmd();
        }
        private static void run_cmd()
        {

            string fileName = @"C:\Users\Mattia\Desktop\Csharp_Call_Python\prova.py";

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(@"C:\Python310\python.exe", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            Console.WriteLine(output);
        }
    }
}