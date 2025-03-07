using Data;
using System;
using System.Diagnostics;
using System.Threading;

namespace Task
{
    static class T3
    {
        public static void Func3(int N)
        {
            MathFucn mF = new MathFucn();
            FillParam fP = new FillParam();
            PrintText pT = new PrintText();

            // таймер часу
            Stopwatch stopwatch = new Stopwatch();

            // створення локальних змінних
            int[] S = new int[N];
            int[] O = new int[N];
            int[] P = new int[N];
            int[] V = new int[N];
            int[,] MR = new int[N, N];
            int[,] MS = new int[N, N];

            // якщо N менше рівне 4, вводимо з клавіатури
            Console.Write("T3. Input num: ");
            if (N <= 4)
            {
                int num = int.Parse(Console.ReadLine());

                fP.FillVect(N, num, S);
                Console.Write("T3. Input num: ");
                num = int.Parse(Console.ReadLine());
                fP.FillVect(N, num, O);
                Console.Write("T3. Input num: ");
                num = int.Parse(Console.ReadLine());
                fP.FillVect(N, num, P);
                Console.Write("T3. Input num: ");
                num = int.Parse(Console.ReadLine());
                fP.FillVect(N, num, V);
                Console.Write("T3. Input num: ");
                num = int.Parse(Console.ReadLine());
                fP.FillMatr(N, num, MR);
                Console.Write("T3. Input num: ");
                num = int.Parse(Console.ReadLine());
                fP.FillMatr(N, num, MS);
            }
            else
            {
                fP.FillVect(N, 3, S);
                fP.FillVect(N, 3, O);
                fP.FillVect(N, 3, P);
                fP.FillVect(N, 3, V);
                fP.FillMatr(N, 3, MR);
                fP.FillMatr(N, 3, MS);
                Console.WriteLine();
            }

            //Thread.Sleep(3000);

            // запуст таймера часу
            stopwatch.Start();

            // F3: S = (O + P + V) * (MR * MS)
            // додавання векторів O + P
            int[] tempVec1 = mF.AddVector(O, P);
            // додавання векторів |O + P| + V
            int[] tempVec2 = mF.AddVector(tempVec1, V);
            // множення  матриць MR * MS
            int[,] tempMatr = mF.MulMatr(MR, MS);
            // множення вектора на матрицю |(O + P + V)| * |(MR * MS)|
            S = mF.MulVecMatr(tempVec2, tempMatr);

            // зупинка таймеру часу
            stopwatch.Stop();

            // якщо N менше рівне 4, виводимо результат обчислення
            if (N <= 4)
            {
                Console.WriteLine($"T3 END; N: {N}; Time: {stopwatch.ElapsedMilliseconds} ms; Res:");
                pT.PrintVector("S", S);
            }
            else
            {
                Console.WriteLine($"T3 END; N: {N}; Time: {stopwatch.ElapsedMilliseconds} ms; Res:");
                Console.WriteLine($"S[0]: {S[0]}");
            }
        }
    }
}