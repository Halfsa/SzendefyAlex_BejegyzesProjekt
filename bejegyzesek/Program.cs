﻿using System;
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
        static void FeltoltLike()
        {
            Random r = new Random();
            int likeok = bejegyzesek1.Count()*20;
            while (likeok > 0)
            {
                bejegyzesek1[r.Next(0, bejegyzesek1.Count)].Like();
                likeok--;
            }
        }
        static void Modosit()
        {
            Console.WriteLine("Adja meg a tartalmat amire a 2. bejegyzést módosítani akarja");
            bejegyzesek1[1].Tartalom = Console.ReadLine();
        }
        static void Kiir()
        {
            for (int i = 0; i < bejegyzesek1.Count; i++)
            {
                Console.WriteLine(bejegyzesek1[i].ToString());
            }
        }
        static void LegNepszerubb()
        {
            int legnagyobb = 0;
            int index = 0;
            bool mom = false;
            for (int i = 0; i < bejegyzesek1.Count; i++)
            {
                if (bejegyzesek1[i].Likeok > legnagyobb)
                {
                    legnagyobb = bejegyzesek1[i].Likeok;
                    index = i;

                }
                if (15 > bejegyzesek1[i].Likeok)
                {
                    mom = true;
                }
            }
            Console.WriteLine($"A legnépszerűbb bejegyzés {bejegyzesek1[index].Szerzo}-é volt, {bejegyzesek1[index].Likeok} likeal");
            if (legnagyobb >35)
            {
                Console.WriteLine("\nVolt olyan bejegyzés, ami több mint 35 likeot kapott");
            }
            else
            {
                Console.WriteLine("\nNem volt olyan bejegyzés ami több mint 35 likeot kapott volna");
            }
            if (mom == true)
            {
                Console.WriteLine("\nVolt olyan bejegyzés ami 15-nél kevesebb likeot kapott");
            }
            else
            {
                Console.WriteLine("\nNem volt olyan bejegyzés ami kevesebb mint 15 likeot kapott volna");
            }
        }
        static void ListaRendez()
        {
            StreamWriter sw = new StreamWriter("bejegyzesek_rendezett.txt");
            bejegyzesek2 = bejegyzesek1.OrderBy(x => x.Likeok).ToList();
            bejegyzesek2.Reverse();
            bejegyzesek1 = bejegyzesek2;
            for (int i = 0; i < bejegyzesek1.Count; i++)
            {
                Console.WriteLine(bejegyzesek1[i].ToString());
                sw.WriteLine(bejegyzesek1[i].ToString());
            }
            sw.Close();

        }
        static void Main(string[] args)
        {
            Feladat2();
            Beolvasás();
            FeltoltLike();
            Modosit();
            Kiir();
            LegNepszerubb();
            ListaRendez();
            Console.ReadKey();
        }
    }
}
