using System;
using System.Diagnostics;

namespace NajwiekszyElementRekurencyjnie
{
    class Program
    {
        static int Najwiekszy(int[] tab, int index)
        {
            if (index == tab.Length - 1)
                return tab[index];
            //index idzie od 0 do konca tablicy
            int najwiekszy = Najwiekszy(tab, index + 1);
            if (tab[index] > najwiekszy)
                return tab[index];
            else
                return najwiekszy;
        }
        static int Najwiekszy(int[] tab)
        {
            int najwiekszy = tab[0];
            for (int i = 1; i < tab.Length; i++)
            {
                if (tab[i] > najwiekszy)
                    najwiekszy = tab[i];
            }
            return najwiekszy;
        }
        static void Main(string[] args)
        {
            //int[] tab = { 12, 4, 6, 3, 2, 4, 5, 67, 89, 975, 23, 68, 95, 2, 1, 0, 0, 54 };
            //Console.WriteLine(Najwiekszy(tab,0));
            //Console.WriteLine(Najwiekszy(tab));
            //Console.ReadKey();
            Random rnd = new Random();
            int[] tab = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                tab[i] = rnd.Next(1, 1000);
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine(Najwiekszy(tab, 0));
            stopwatch.Stop();
            Console.WriteLine("Najwiekszy rekurencyjnie: " + stopwatch.ElapsedTicks);
            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine(Najwiekszy(tab));
            stopwatch.Stop();
            Console.WriteLine("Najwiekszy iteracyjnie: " + stopwatch.ElapsedTicks);
            Console.ReadKey();
        }
        //999
        //Najwiekszy rekurencyjnie: 194336
        //999
        //Najwiekszy iteracyjnie: 4632
    }
}
