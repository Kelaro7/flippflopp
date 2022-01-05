using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Czipa_Andras_B9UBKB
{
    class Program
    {
        static void Main(string[] args)
        {
            int arusdb = 0;
            Console.Write($"Kérem adja meg az árusok számát (min 5, max 100):");
            do
            {
                arusdb = Convert.ToInt32(Console.ReadLine());
                if (arusdb > 100 || arusdb < 5)
                {
                    Console.WriteLine($"Hibás adat!");
                    Console.Write($"Kérem adja meg az árusok számát újból (min 5, max 100):");
                }
                else
                    Console.WriteLine("");
            }
            while (arusdb > 100 || arusdb < 5);

            int fadb = 0;

            Console.Write($"Kérem adja meg a fa fajták számát (min 3, max 10):");
            do
            {
                fadb = Convert.ToInt32(Console.ReadLine());
                if (fadb > 10 || fadb < 3)
                {
                    Console.WriteLine($"Hibás adat!");
                    Console.Write($"Kérem adja meg a fa fajták számát újból (min 3, max 10):");
                }
                else
                    Console.WriteLine("");
            }
            while (fadb > 10 || fadb < 3);


            StreamReader sr = new StreamReader("fenyok.txt");

            List<string> fenyofajta = new List<string>();

            while (!sr.EndOfStream)
            {
                fenyofajta.Add(sr.ReadLine());
            }

            for (int i = 0; i < fenyofajta.Count; i++)
            {
                Console.WriteLine
                    ($"Sorszám:{i+1} Fenyőfajta: {fenyofajta[i]}");
            }

            Console.WriteLine("");
            Console.WriteLine($"Kérem válassza ki a/az {fadb} db fajta fenyőfa sorszámát!");
            int[] fenyok = new int[fadb];
            string[] valfenyo = new string[fadb];

            
            for (int i = 0; i < fenyok.Length; i++)
            {
                Console.WriteLine($"{i+1 }. fa száma:");
                do
                {
                    fenyok[i] = Convert.ToInt32(Console.ReadLine());

                    if (fenyok[i] > 10 || fenyok[i] < 1)
                    {
                        Console.WriteLine($"Hibás adat!");
                        Console.WriteLine($"Kérem adja meg a fafajta sorszámát újra:");
                    }
                    else
                        Console.WriteLine($"{fenyofajta[fenyok[i]-1]}");
                    
                }
                while (fenyok[i] > 10 || fenyok[i] < 1 );
            }
            Console.WriteLine("Az ön választásai:");
            for (int i = 0; i < fenyok.Length; i++)
            {
                Console.Write($"{fenyofajta[fenyok[i]-1]} | ");
                valfenyo[i] = fenyofajta[fenyok[i]-1];
            }
            Console.WriteLine("");

            // valfenyo-be vannak a választott fák , az ismétlődést nem szűrtem ki


            Random veletlen = new Random();
            
            int[] arusfenyo = new int[arusdb];
            int[] ar = new int[arusdb];
            Console.WriteLine("");
            for (int i = 0; i < arusdb; i++)
            {
                arusfenyo[i] = veletlen.Next(0, valfenyo.Length);
                ar[i] = veletlen.Next(1, 13) * 1000;
                //Console.WriteLine($"{i+1}. Árus. Fenyőfajta: {valfenyo[arusfenyo[i]]} Ár:{ar[i]} FT"); -teszt
            }

            Console.WriteLine("Kérem adja meg a maximális méter árat:");

            int vevoar = 0;

            do
            { 
                vevoar = Convert.ToInt32(Console.ReadLine());

                if (vevoar > 12000 || vevoar < 1000)
                {
                    Console.WriteLine($"Hibás adat!");
                    Console.WriteLine($"Minimum ár 1000 Ft, Maximum ár 12000 Ft!");
                    Console.WriteLine("Kérem adja meg újra az árat!");
                }
                else
                    Console.WriteLine($"Az ön által megadott árért:{vevoar}-FT megvásárolható fák:");
            }
            while (vevoar > 12001 || vevoar < 999);
            Console.WriteLine("");
            for (int i = 0; i < arusdb; i++)
            {
                if (vevoar >= ar[i])
                    Console.WriteLine($"{i + 1}. Árus. | Fenyőfajta: {valfenyo[arusfenyo[i]]} | Ár:{ar[i]} FT");
            }

            //Console.WriteLine($"{i+1}. Árus. Fenyőfajta: {valfenyo[arusfenyo[i]]} Ár:{ar[i]} FT");

            Console.ReadKey();
        }
    }
}
