using System;
using System.Diagnostics;

namespace SortowaniePrzezWybieranie
{
    class Program
    {
        static void SelectionSort(int[] tab)
        {
            int tmp = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                for (int n = i; n < tab.Length; n++)
                {
                    if (tab[n] < tab[i])
                    {
                        tmp = tab[n];
                        tab[n] = tab[i];
                        tab[i] = tmp;
                    }
                }
            }
        }
        static int Najmniejszy(int[] tab, int index)
        {
            for (int i = index+1; i < tab.Length; i++)
            {
                if (tab[index] > tab[i])
                {
                    index = i;
                }
            }
            return index;
        }
        static void SelectionSortR(int[] tab, int index)
        {
            if (index == tab.Length)
                return;
            //index - poczatek tablicy
            int najmniejszy = Najmniejszy(tab, index);
            int tmp = tab[index];
            tab[index] = tab[najmniejszy];
            tab[najmniejszy] = tmp;
            SelectionSortR(tab, index + 1);

        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] tab = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                tab[i] = rnd.Next(1, 1000);
            }
            int[] tab1 = new int[1000];
            int[] tab2 = new int[1000];
            Array.Copy(tab, tab1, 1000);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SelectionSort(tab1);
            stopwatch.Stop();
            Console.WriteLine("Sortowanie przez wybieranie (petla): " + stopwatch.ElapsedTicks);
            stopwatch.Reset();
            stopwatch.Start();
            SelectionSortR(tab1,0);
            stopwatch.Stop();
            Console.WriteLine("Sortowanie przez wybieranie (rekurencja): " + stopwatch.ElapsedTicks);
            Console.ReadKey();
        }
    }
}
//Sortowanie przez wybieranie(petla) : 142605
//Sortowanie przez wybieranie(rekurencja) : 96983
//Sortowanie przez wybieranie(petla) : 6345966
//Sortowanie przez wybieranie(rekurencja) : 3645183
