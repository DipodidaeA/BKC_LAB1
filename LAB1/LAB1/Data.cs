using System;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace Data
{
    // клас математичних функцій
    class MathFucn
    {
        // додає два вектори, повертає вектор
        public int[] AddVector(int[] A, int[] B)
        {
            int N = A.Length;
            int[] R = new int[N];

            for (int i = 0; i < N; i++)
            {
                R[i] = A[i] + B[i];
            }

            return R;
        }

        // Множення вектора на матриць, повертає вектор
        public int[] MulVecMatr(int[] A, int[,] B)
        {
            int N = A.Length;
            int H2 = B.GetLength(1);
            int[] res = new int[H2];

            for (int i = 0; i < H2; i++)
            {
                for (int k = 0; k < N; k++)
                {
                    res[i] += A[k] * B[k, i];
                }
            }

            return res;
        }

        // віднімання матриць, повертає матрицю
        public int[,] SubMatr(int[,] A, int[,] B)
        {
            int N = A.GetLength(0);
            int[,] R = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    R[i, j] = A[i, j] - B[i, j];
                }
            }

            return R;
        }

        // множення матриць, повертає матрицю
        public int[,] MulMatr(int[,] A, int[,] B)
        {
            int H1 = A.GetLength(0);
            int N = A.GetLength(1);
            int H2 = B.GetLength(1);
            int[,] res = new int[H1, H2];

            for (int i = 0; i < H1; i++)
            {
                for (int j = 0; j < H2; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        res[i, j] += A[i, k] * B[k, j];
                    }
                }
            }

            return res;
        }

        // сортування рядків матриць, повертає відсортовану за рядками матрицю
        public int[,] SortLineMatr(int[,] A)
        {
            int N = A.GetLength(0);
            // створення масив результат
            int[,] R = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                // тимчасовий масив для радка що сортується
                int[] tempArr = new int[N];

                // Копіюємо елементи рядка матриці у тимчасовий масив
                for (int j = 0; j < N; j++)
                {
                    tempArr[j] = A[i, j];
                }

                // Сортуємо тимчасовий масив
                Array.Sort(tempArr);

                // Записуємо відсортовані елементи у масив результат
                for (int j = 0; j < N; j++)
                {
                    R[i, j] = tempArr[j];
                }
            }

            return R;
        }
    }

    // клас для заповенння векторів та матриць для функцій
    class FillParam
    {
        // заповнення для вектора
        public void FillVect(int N, int num, int[] A)
        {
            for (int i = 0; i < N; i++)
            {
                A[i] = num;
            }
        }

        public void FillMatr(int N, int num, int[,] MA)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    MA[i, j] = num;
                }
            }
        }
    }

    // клас для виводу векторів та матриць
    class PrintText
    {
        // для виводу вектора
        public void PrintVector(string NameV, int[] V)
        {
            int N = V.Length;

            Console.WriteLine(NameV + ": ");

            for (int i = 0; i < N; i++)
            {
                Console.Write(V[i] + " ");
                Thread.Sleep(250);
            }
            Console.WriteLine();
        }

        // для виводу матириці
        public void PrintMATR(string NameMA, int[,] MA)
        {
            int N1 = MA.GetLength(0);
            int N2 = MA.GetLength(1);

            Console.WriteLine(NameMA + ": ");

            for (int i = 0; i < N1; i++)
            {
                for (int j = 0; j < N2; j++)
                {
                    Console.Write(MA[i, j] + " ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
            }

        }
    }
}