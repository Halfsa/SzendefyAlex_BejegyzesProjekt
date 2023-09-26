using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace bejegyzesek
{
    internal class Program
    {
        static List<Bejegyzes> bejegyzesek1 = new List<Bejegyzes>();
        static List<Bejegyzes> bejegyzesek2 = new List<Bejegyzes>();
        static void Feladat2()
        {
            Console.WriteLine("Hány bejegyzést szeretne a listához adni?");
            int n = int.Parse(Console.ReadLine());
            if (n < 0)
            {
                Console.WriteLine("Hiba! Természetes számot adjon meg");
            }
            else {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Adja meg a bejegyzés szerzőjét és tartalmát");
                    string szerzo = Console.ReadLine();
                    string tartalom = Console.ReadLine();
                    Bejegyzes b = new Bejegyzes(szerzo, tartalom);
                    bejegyzesek1.Add(b);
                }
            }
        }
        static void Beolvasás() {
            StreamReader sr = new StreamReader("bejegyzesek.csv");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] tombi = sor.Split(';');
                Bejegyzes be = new Bejegyzes(tombi[0], tombi[1]);
                bejegyzesek1.Add(be);
            }
            
        }
        static void Main(string[] args)
        {
            Feladat2();
            Beolvasás();
            Console.ReadKey();
        }
    }
}
