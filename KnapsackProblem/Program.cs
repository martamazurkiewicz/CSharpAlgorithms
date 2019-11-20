using System;

namespace KnapsackProblem
{
    class Zadanie5
    {
        //Zadanie 5(program) 
        //Mamy N przedmiotów. Każdy ma objętość ci.
        //Torba ma pojemność C.
        //Które przedmioty wziąć, aby łączna zawartość torbybyła jak największa?  
        //Oceń złożoność rozwiązania.
        public static void PlecakDynamiczny(int C, int N, int[] objetosci)
        {
            int[,] wartosc = new int[N + 1, C + 1];
            int[,] kroki = new int[N + 1, C + 1];
            for (int rows = 1; rows <=N; rows++)
            {
                for (int columns = 1; columns <= C; columns++)
                {
                    if(wartosc[rows-1,columns]> wartosc[rows,columns-1])
                    {
                        wartosc[rows, columns] = wartosc[rows - 1, columns];
                        kroki[rows, columns] = 1; //przyszlo z gory
                    }
                    else
                    {
                        wartosc[rows, columns] = wartosc[rows, columns-1];
                        kroki[rows, columns] = 2; //przyszlo z lewej
                    }
                    if(columns>=objetosci[rows-1])
                    {
                        if (wartosc[rows - 1, columns - objetosci[rows - 1]] + objetosci[rows - 1] > wartosc[rows, columns])
                        {
                            wartosc[rows, columns] = wartosc[rows - 1, columns - objetosci[rows - 1]] + objetosci[rows - 1];
                            kroki[rows, columns] = 3;
                        }
                    }
                }
            }
            Console.WriteLine(wartosc[N,C]); //najwieksza laczna zawartosc torby
            bool[] przedmioty = new bool[N]; //0-nie bierzemy przedmiotu, 1-bierzemy przedmiot
            for (int i = 0; i < przedmioty.Length; i++)
            {
                przedmioty[i] = false;
            }
            int row = N;
            int column = C;
            while(column>=0 && row>0)
            {
                if (kroki[row, column] == 1)
                    row = row - 1; //wartosc z gory
                if (kroki[row, column] == 2)
                    column = column - 1; //wartosc przyszla z lewej
                if(kroki[row,column]==3)
                {
                    przedmioty[row - 1] = true;
                    column = column - objetosci[row - 1];
                    row = row - 1;
                }
            }
            for (int i = 0; i < przedmioty.Length; i++)
            {
                if(przedmioty[i] == true)
                    Console.WriteLine($"Wzielismy przedmiot nr {i+1} o objetosci {objetosci[i]}");
            }
        }
    }
    class Program
    {
        static (int wartosc, int[,] kroki) KnapsackProblemDynamically(int[] wagi, int[] ceny, int K)
        {
            //K- naszUdzwig
            //n-liczba dostepnych w sklepie przedmiotow
            int n = wagi.Length;
            int[,] wartosc = new int[n + 1, K + 1];
            int[,] kroki = new int[n + 1, K + 1];
            for (int rows = 1; rows <= n; rows++)
            {
                for (int columns = 1; columns <= K; columns++)
                {

                    if (wartosc[rows - 1, columns] >= wartosc[rows, columns - 1])
                    {
                        wartosc[rows, columns] = wartosc[rows - 1, columns];
                        kroki[rows, columns] = 1; //wartosc z gory
                    }
                    else
                    {
                        wartosc[rows, columns] = wartosc[rows, columns - 1];
                        kroki[rows, columns] = 2; //wartosc z lewej
                    }
                    if (columns>= wagi[rows-1])
                    {
                        if (wartosc[rows - 1, columns - wagi[rows - 1]] + ceny[rows - 1] > wartosc[rows, columns])
                        {
                            wartosc[rows, columns] = wartosc[rows - 1, columns - wagi[rows - 1]] + ceny[rows - 1];
                            kroki[rows, columns] = 3; //dodajemy ten przedmiot(wagi[rows-1]) i inny po skosie
                        }
                    }
                }
            }
            return (wartosc[n, K],kroki);
        }
        static void Przedmioty(int[] wagi, int[] ceny, int K, int[,] kroki)
        {
            int n = wagi.Length; //liczba przedmiotow
            int[] przedmioty = new int[n];
            //czy przedmiot wchodzi do rozwiazania (0 - nie wchodzi, 1 - wchodzi)
            for (int i = 0; i < n; i++)
            {
                przedmioty[i] = 0;
            }
            int rows = n;
            int columns = K;
            while(columns>=0 && rows>0)
            {
                if (kroki[rows, columns] == 1) //przyszlo z gory
                    rows = rows - 1;
                else if (kroki[rows, columns] == 2) //przyszlo z lewej
                    columns = columns - 1;
                else if (kroki[rows,columns] == 3) //po skosie
                {
                    przedmioty[rows - 1] = 1; //przedmiot wchodzi do rozwiazania
                    columns = columns - wagi[rows - 1];
                    rows = rows - 1;
                }

            }
            for (int i = 0; i < n; i++)
            {
                if(przedmioty[i]==1)
                { 
                    Console.WriteLine($"przedmiot o wadze {wagi[i]} i wartosci { ceny[i]} w plecaku");
                }
            }
        }
        static void Main(string[] args)
        {
            //gitara, stereo, mp3player, laptop, iphone
            //int[] ceny = { 1500, 3000, 1000, 2000, 2000 };
            //int[] wagi = { 1, 4, 1, 3, 1 };
            //int wartosc = KnapsackProblemDynamically(wagi, ceny, 4).wartosc;
            //int[,] kroki = KnapsackProblemDynamically(wagi, ceny, 4).kroki;
            //Console.WriteLine(wartosc);
            //for (int i = 0; i < kroki.GetLength(0); i++)
            //{
            //    for (int j = 0; j < kroki.GetLength(1); j++)
            //    {
            //        Console.Write(kroki[i,j] + ", ");
            //    }
            //    Console.Write("\n");
            //}
            //Przedmioty(wagi,ceny,4, KnapsackProblemDynamically(wagi, ceny, 4).kroki);
            int[] objetosci = { 1, 4, 5, 1, 3, 8 };
            Zadanie5.PlecakDynamiczny(18, objetosci.Length, objetosci);
            Console.ReadKey();
        }
    }
}
//    4500
//przedmiot o wadze 1 i wartosci 1500 w plecaku
//przedmiot o wadze 1 i wartosci 1000 w plecaku
//przedmiot o wadze 1 i wartosci 2000 w plecaku

//    4500
//0, 0, 0, 0, 0,
//0, 3, 2, 2, 2,
//0, 1, 1, 1, 3,
//0, 1, 3, 2, 1,
//0, 1, 1, 1, 3,
//0, 3, 3, 3, 2,
