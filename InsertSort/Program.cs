using System;

namespace InsertSort
{
    class Program
    {
        static void InsertSort(int[] tab)
        {
            for (int i = 1; i < tab.Length; i++)
            {
                int klucz = tab[i];
                int j = i;
                while(j>0 && tab[j-1] > klucz)
                {
                    tab[j] = tab[j - 1];
                    j--;
                }
                tab[j] = klucz;
            }
        }
        static void Main(string[] args)
        {
            int[] tab = { 1, 4, 6, 8, 2, 4, 6, 8, 0, 12, 7 };
            InsertSort(tab);
            foreach (var item in tab)
            {
                Console.Write(item + ", ");
            }
            Console.ReadKey();
        }
    }
}
