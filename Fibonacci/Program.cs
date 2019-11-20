using System;
using System.Diagnostics;

namespace Fibonacci
{
    class Program
    {
        //traditional recursion
        static int Fibonacci(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        //memoization
        static int Fibonacci(int n, int[] memo)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            else if(memo[n]==0)
                memo[n]=Fibonacci(n - 1, memo) + Fibonacci(n - 2, memo);
            return memo[n];
        }
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            int[] memo = new int[41];
            stopwatch.Start();
            int i = Fibonacci(40);
            stopwatch.Stop();
            Console.WriteLine(i + " " + stopwatch.ElapsedTicks);
            stopwatch.Reset();
            stopwatch.Start();
            i = Fibonacci(40, memo);
            stopwatch.Stop();
            Console.WriteLine(i + " " + stopwatch.ElapsedTicks);
            Console.ReadKey();
        }
    }
//recursion: 102334155 elapsed ticks: 16738941
//memoization: 102334155 elapsed ticks: 1531
}
