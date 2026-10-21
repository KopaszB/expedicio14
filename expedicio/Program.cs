using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace expedicio
{
    internal class Program
    {
        static List<Adas> adasok = new List<Adas>();
        static void Main(string[] args)
        {
            fajlBeolvas();
            //adatKiir();

            //2.feladat
            Console.WriteLine("2.feladat");
            Console.WriteLine($"Az első üzenet rögzítője: {adasok.First().RadioAmator}");
            Console.WriteLine($"Az utolsó üzenet rögzítője: {adasok.Last().RadioAmator}");

            //3.feladat
            Console.WriteLine("\n3.feladat");
            adasok.Where(x => x.Uzenet.ToLower().Contains("farkas")).ToList().ForEach(w => Console.WriteLine($"{w.Nap}. nap {w.RadioAmator}. rádióamatőr"));

            //4.feladat
            Console.WriteLine("\n4.feladat");
            adasok
                .GroupBy(x => x.Nap)
                .Select(x => new { nap = x.Key, amatorDb = x.Count() })
                .OrderBy(x=>x.nap)
                .ToList()
                .ForEach(w => Console.WriteLine($"{w.nap}. nap: {(w.amatorDb==0?0:w.amatorDb)} rádióamatőr"));

            Console.ReadKey();
        }

        private static void adatKiir()
        {
            foreach (var item in adasok)
            {
                Console.WriteLine($"{item.Nap} - {item.RadioAmator}");
            }
        }

        private static void fajlBeolvas()
        {
            try
            {
                using (StreamReader olvas = new StreamReader("veetel.txt"))
                {
                    while (!olvas.EndOfStream)
                    {
                        string[] sor = olvas.ReadLine().Split(' ');
                        int nap = int.Parse(sor[0]);
                        int amator = int.Parse(sor[1]);
                        string uzenet = olvas.ReadLine();
                        var egyAdas = new Adas(nap, amator, uzenet);
                        adasok.Add(egyAdas);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
