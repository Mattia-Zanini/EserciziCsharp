using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace P1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\Mattia\Documents\Informatica\EserciziCsharp\Process\P2\server.exe";
            Console.WriteLine("Scrivi un prodotto che vuoi cercare");
            string prodotto = Console.ReadLine();
            Process server = new Process();
            server.StartInfo = new ProcessStartInfo(fileName, prodotto)
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            server.Start();
            server.BeginErrorReadLine();
            Console.WriteLine($"Nome processo: {server.ProcessName} id: {server.Id}");
            server.StandardInput.WriteLine("si");
            string output = server.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            server.WaitForExit();
        }
    }
}
