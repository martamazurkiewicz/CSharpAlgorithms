using System;
using System.Diagnostics;

namespace BinarySearch
{
    class Program
    {
        static int BinarySearch(int[] arr, int start, int finish, int targetValue)
        {
            if (start >= finish)
            {
                return (arr[start] == targetValue) ? start : -1;
            }
            int mid = (start + finish) / 2;
            return (arr[mid]>=targetValue)? BinarySearch(arr, start, mid, targetValue):BinarySearch(arr, mid + 1, finish, targetValue);
            //return (start >= finish) ? ((arr[start] == targetValue) ? start : -1) : ((arr[(start + finish) / 2] >= targetValue) ? BinarySearch(arr, start, (start + finish) / 2, targetValue) : BinarySearch(arr, ((start + finish) / 2) + 1, finish, targetValue));
        }
        static int BinarySearch(int[] arr, int targetValue)
        {
            int start = 0;
            int finish = arr.Length-1;
            int mid = (start + finish) / 2;
            while(start<finish)
            {
                if (targetValue <= arr[mid])
                    finish = mid;
                else
                    start = mid+1;
                mid = (start + finish) / 2;
            }
            if (targetValue == arr[start])
                return start;
            else
                return -1;
        }
        static void Main(string[] args)
        {
            int[] tab = { 1,4,5,6,7,8,11,14,15,16,19,20,24,27,33,37,40 };
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine(BinarySearch(tab, 0, tab.Length-1, 24));
            stopwatch.Stop();
            Console.WriteLine("Szukanie binarne, rekurencja: " + stopwatch.ElapsedTicks);
            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine(BinarySearch(tab, 0, tab.Length-1, 4));
            stopwatch.Stop();
            Console.WriteLine("Szukanie binarne, rekurencja: " + stopwatch.ElapsedTicks);
            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine(BinarySearch(tab, 0, tab.Length-1, 21));
            stopwatch.Stop();
            Console.WriteLine("Szukanie binarne, rekurencja: " + stopwatch.ElapsedTicks);
            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine(BinarySearch(tab, 24));
            stopwatch.Stop();
            Console.WriteLine("Szukanie binarne, iteracja: " + stopwatch.ElapsedTicks);
            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine(BinarySearch(tab, 4));
            stopwatch.Stop();
            Console.WriteLine("Szukanie binarne, iteracja: " + stopwatch.ElapsedTicks);
            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine(BinarySearch(tab, 21));
            stopwatch.Stop();
            Console.WriteLine("Szukanie binarne, iteracja: " + stopwatch.ElapsedTicks);
            Console.ReadKey();
        }
    }
}
//12
//Szukanie binarne, rekurencja: 232603
//1
//Szukanie binarne, rekurencja: 1419
//-1
//Szukanie binarne, rekurencja: 19357
//12
//Szukanie binarne, iteracja: 3377
//1
//Szukanie binarne, iteracja: 1201
//-1
//Szukanie binarne, iteracja: 2579
