using Data;
using System;
using System.Diagnostics;
using System.Threading;

namespace Task
{
    static class T1
    {
        public static void Func1(int N)
        {
            MathFucn mF = new MathFucn();
            FillParam fP = new FillParam();
            PrintText pT = new PrintText();

            // таймер часу
            Stopwatch stopwatch = new Stopwatch();
            // запуст таймера часу
            stopwatch.Start();

            // створення локальних змінних
            int[] E = new int[N];
            int[] A = new int[N];
            int[] B = new int[N];
            int[] C = new int[N];
            int[] D = new int[N];
            int[,] MA = new int[N,N];
            int[,] MD = new int[N,N];

            // якщо N менше рівне 4, вводимо з клавіатури
            Console.Write("T1. Input num: ");
            if (N <= 4)
            {
                int num = int.Parse(Console.ReadLine());

                fP.FillVect(N, num, E);
                Console.Write("T1. Input num: ");
                num = int.Parse(Console.ReadLine());
                fP.FillVect(N, num, A);
                Console.Write("T1. Input num: ");
                num = int.Parse(Console.ReadLine());
                fP.FillVect(N, num, B);
                Console.Write("T1. Input num: ");
                num = int.Parse(Console.ReadLine());
                fP.FillVect(N, num, C);
                Console.Write("T1. Input num: ");
                num = int.Parse(Console.ReadLine());
                fP.FillVect(N, num, D);
                Console.Write("T1. Input num: ");
                num = int.Parse(Console.ReadLine());
                fP.FillMatr(N, num, MA);
                Console.Write("T1. Input num: ");
                num = int.Parse(Console.ReadLine());
                fP.FillMatr(N, num, MD);
            }
            else 
            {
                fP.FillVect(N, 1, E);
                fP.FillVect(N, 1, A);
                fP.FillVect(N, 1, B);
                fP.FillVect(N, 1, C);
                fP.FillVect(N, 1, D);
                fP.FillMatr(N, 1, MA);
                fP.FillMatr(N, 1, MD);
                Console.WriteLine();
            }

            Thread.Sleep(3000);

            // F1: E = A + B + C + D * (MA * MD)
            // множення матриць (MA * MD)
            int[,] tempMatr =  mF.MulMatr(MA, MD);
            // множення вектора на матрицю D * |(MA * MD)|
            int[] tempVec1 = mF.MulVecMatr(D, tempMatr);
            // додавання векторів C + |D * (MA * MD)|
            int[] tempVec2 = mF.AddVector(tempVec1, C);
            // додавання векторів B + |C + D * (MA * MD)|
            int[] tempVec3 = mF.AddVector(tempVec2, B);
            // додавання векторів A + |B + C + D * (MA * MD)|
            E = mF.AddVector(tempVec3, A);

            // зупинка таймеру часу
            stopwatch.Stop();

            // якщо N менше рівне 4, виводимо результат обчислення
            if (N <= 4)
            {
                Console.WriteLine($"T1 END; N: {N}; Time: {stopwatch.ElapsedMilliseconds} ms; Res:");
                pT.PrintVector("E", E);
            }
            else
            {
                Console.WriteLine($"T1 END; N: {N}; Time: {stopwatch.ElapsedMilliseconds} ms");
            }
        }
    }
}