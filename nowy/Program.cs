using System;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 1, 23, 5, 6, 8, 6, 34, 5, 27, 889, 36, 7, 568, 4643 };
            int[] B = { 3, 2, 6, 1, 1 };
            //MergeSort(A, 0, A.Length - 1);
            //MergeSort(B, 0, B.Length - 1);
            QuickSort(A, 0, A.Length - 1);
            QuickSort(B, 0, B.Length - 1);
            foreach (var item in B)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        //QUICKSORT
        static void QuickSort(int[] tablica, int lewy, int prawy)
        {
            if (lewy >= prawy) return;
            int i = Podziel(tablica, lewy, prawy);
            QuickSort(tablica, lewy, i - 1);
            QuickSort(tablica, i + 1, prawy);
        }
        static int Podziel(int[] tablica, int lewy, int prawy)
        {
            int tmp;
            //int klucz = tablica[prawy];
            int i = lewy;   //idziemy od lewej do prawej
            for (int j = lewy; j < prawy; j++)
            {
                if (tablica[j] <= tablica[prawy])
                {
                    tmp = tablica[i];
                    tablica[i] = tablica[j];
                    tablica[j] = tmp;   //zamieniamy t[i] i t[j]
                    i++;
                }
            }
            tmp = tablica[i];
            tablica[i] = tablica[prawy];
            tablica[prawy] = tmp;   //klucz zamieniamy z t[i]
            return i;   //zwracamy index klucza
        }
    }
}
