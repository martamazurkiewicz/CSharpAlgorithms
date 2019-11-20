using System;
using System.Diagnostics;

namespace Kolokwium1
{
    class Program
    {
        static void zadanie3Stabilnie(int[] tab)
        {
            //mamy tylko trzy mozliwe wartosci
            int[] wartosci = { tab[0], 0, 0 }; //jakie elementy ma tablica
            int[] trzyWartosci = new int[3]; //ile tych elementow ma tablica
            int[] nowa = new int[tab.Length];
            trzyWartosci[0] = 1;
            bool boolean = false;
            for (int i = 1; i < tab.Length - 1; i++)
            {
                if (tab[i] != wartosci[0] && boolean == false)
                {
                    wartosci[1] = tab[i];
                    boolean = true;
                    continue;
                }
                if (tab[i] != wartosci[0] && tab[i] != wartosci[1])
                {
                    wartosci[2] = tab[i];
                    break;
                }
            }
            for (int i = 0; i < 2; i++)
            {
                if (wartosci[i] > wartosci[i + 1])
                {
                    int tmp = wartosci[i];
                    wartosci[i] = wartosci[i + 1];
                    wartosci[i + 1] = tmp;
                }
            }
            for (int i = 1; i < tab.Length; i++)
            {
                if (tab[i] == wartosci[0])
                    trzyWartosci[0]++;
                else if (tab[i] == wartosci[1])
                    trzyWartosci[1]++;
                else
                    trzyWartosci[2]++;
            }

            //stabilny
            int iterator1 = 0;
            int iterator2 = trzyWartosci[1];
            int iterator3 = trzyWartosci[1] + trzyWartosci[2];
            for (int i = 0; i < tab.Length - 1; i++)
            {
                if (tab[i] == wartosci[0])
                {
                    nowa[iterator1] = wartosci[0];
                    iterator1++;
                    continue;
                }
                if (tab[i] == wartosci[1])
                {
                    nowa[iterator2] = wartosci[1];
                    iterator2++;
                    continue;
                }
                if (tab[i] == wartosci[2])
                {
                    nowa[iterator3] = wartosci[2];
                    iterator3++;
                }
            }
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = nowa[i];
            }
        }
        static void zadanie3NieStabilnie(int[] tab)
        {
            //mamy tylko trzy mozliwe wartosci
            int[] wartosci = { tab[0], 0, 0 }; //jakie elementy ma tablica
            int[] trzyWartosci = new int[3]; //ile tych elementow ma tablica
            int[] nowa = new int[tab.Length];
            trzyWartosci[0] = 1;
            bool boolean = false;
            for (int i = 1; i < tab.Length - 1; i++)
            {
                if (tab[i] != wartosci[0] && boolean == false)
                {
                    wartosci[1] = tab[i];
                    boolean = true;
                    continue;
                }
                if (tab[i] != wartosci[0] && tab[i] != wartosci[1])
                {
                    wartosci[2] = tab[i];
                    break;
                }
            }
            for (int i = 0; i < 2; i++)
            {
                if (wartosci[i] > wartosci[i + 1])
                {
                    int tmp = wartosci[i];
                    wartosci[i] = wartosci[i + 1];
                    wartosci[i + 1] = tmp;
                }
            }
            for (int i = 1; i < tab.Length; i++)
            {
                if (tab[i] == wartosci[0])
                    trzyWartosci[0]++;
                else if (tab[i] == wartosci[1])
                    trzyWartosci[1]++;
                else
                    trzyWartosci[2]++;
            }

            //niestabilnie
            int index = 0;
            for (int i = 0; i < 3; i++)
            {
                while (trzyWartosci[i] > 0)
                {
                    nowa[index] = wartosci[i];
                    index++;
                    trzyWartosci[i]--;
                }
            }
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = nowa[i];
            }
        }
        static (int,int) zadanie4(int[] tab, int poczatek, int koniec, int x) //zwraca i takie ze przedział (a[i], a[i+1]>, w którym mieści się x
        {
            if (x <= tab[0])
                return (0,0);
            if (x > tab[tab.Length - 1])
                return (tab.Length - 1, tab.Length - 1);
            //przy powyzszych zalozeniach element nie moze byc mniejszy / wiekszy od skrajnych wartosci tablicy
            if (koniec-poczatek==1)
                return (poczatek, koniec);
            int mid = (koniec+poczatek) / 2;
            if (x < tab[mid])
                return zadanie4(tab, poczatek, mid, x);
            else
                return zadanie4(tab, mid, koniec, x);
        }
        static void Main(string[] args)
        {
            ////int[] tab = { 1, 3, 2, 1, 3, 2, 2, 2, 2, 3, 3, 1, 1, 3, 1, 3, 1, 2, 3, 1, 1, 3, 2, 2, 3 };
            ////zadanie3Stabilnie(tab);
            //Random rand = new Random();
            //int[] tab = new int[1000];
            //for (int i = 0; i < 1000; i++)
            //{
            //    tab[i] = rand.Next(1, 4);
            //}
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //zadanie3NieStabilnie(tab);
            //stopwatch.Stop();
            //stopwatch.Reset();

            //stopwatch.Start();
            //zadanie3NieStabilnie(tab);
            //stopwatch.Stop();
            ////foreach (var item in tab)
            ////{
            ////    Console.Write(item + ", ");
            ////}
            //Console.WriteLine("Elapsed ticks: " + stopwatch.ElapsedTicks);
            //stopwatch.Reset();

            //int[] tab1 = new int[10000];
            //for (int i = 0; i < 10000; i++)
            //{
            //    tab1[i] = rand.Next(1, 4);
            //}
            //stopwatch.Start();
            //zadanie3NieStabilnie(tab1);
            //stopwatch.Stop();
            //Console.WriteLine("Elapsed ticks: " + stopwatch.ElapsedTicks);
            //stopwatch.Reset();

            //int[] tab2 = new int[100000];
            //for (int i = 0; i < 100000; i++)
            //{
            //    tab2[i] = rand.Next(1, 4);
            //}
            //stopwatch.Start();
            //zadanie3NieStabilnie(tab2);
            //stopwatch.Stop();
            //Console.WriteLine("Elapsed ticks: " + stopwatch.ElapsedTicks);
            int[] tab = { 1, 5, 6, 7, 8, 11, 22, 34, 36, 37, 42 };
            Console.WriteLine($"tab[{zadanie4(tab,0,tab.Length-1,45).Item1}], tab[{ zadanie4(tab, 0, tab.Length - 1, 45).Item2}]");
            Console.ReadKey();
        }
    }
}
//Elapsed ticks: 185
//Elapsed ticks: 2665
//Elapsed ticks: 23591
