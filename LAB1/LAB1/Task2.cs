using Data;
using System;
using System.Diagnostics;
using System.Threading;

namespace Task
{
    static class T2
    {
        public static void Func2(int N)
        {
            MathFucn mF = new MathFucn();
            FillParam fP = new FillParam();
            PrintText pT = new PrintText();

            // таймер часу
            Stopwatch stopwatch = new Stopwatch();

            // створення локальних змінних
            int[,] MG = new int[N, N];
            int[,] MF = new int[N, N];
            int[,] MH = new int[N, N];
            int[,] MK = new int[N, N];

            // якщо N менше рівне 4, вводимо з клавіатури
            Console.Write("T2. Input num: ");
            if (N <= 4)
            {
                int num = int.Parse(Console.ReadLine());

                fP.FillMatr(N, num, MG);
                Console.Write("T2. Input num: ");
                num = int.Parse(Console.ReadLine());
                fP.FillMatr(N, num, MF);
                Console.Write("T2. Input num: ");
                num = int.Parse(Console.ReadLine());
                fP.FillMatr(N, num, MH);
                Console.Write("T2. Input num: ");
                num = int.Parse(Console.ReadLine());
                fP.FillMatr(N, num, MK);
            }
            else
            {
                fP.FillMatr(N, 2, MG);
                fP.FillMatr(N, 2, MF);
                fP.FillMatr(N, 2, MH);
                fP.FillMatr(N, 2, MK);
                Console.WriteLine();
            }

            //Thread.Sleep(3000);

            // запуст таймера часу
            stopwatch.Start();

            // F2: MG = SORT(MF - MH * MK)
            // множення матриць MH * MK
            int[,] tempMatr1 = mF.MulMatr(MH, MK);
            // віднімання матриць MF - |MH * MK|
            int[,] tempMatr2 = mF.SubMatr(MF, tempMatr1);
            // розтування матриці по рядках SORT(|MF - MH * MK|)
            MG = mF.SortLineMatr(tempMatr2);

            // зупинка таймеру часу
            stopwatch.Stop();

            // якщо N менше рівне 4, виводимо результат обчислення
            if (N <= 4)
            {
                Console.WriteLine($"T2 END; N: {N}; Time: {stopwatch.ElapsedMilliseconds} ms; Res:");
                pT.PrintMATR("MG", MG);
            }
            else
            {
                Console.WriteLine($"T2 END; N: {N}; Time: {stopwatch.ElapsedMilliseconds} ms; Res:");
                Console.WriteLine($"MG[0]: {MG[0,0]}");
            }
        }
    }
}