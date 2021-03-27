using System;
using System.Collections.Generic;

namespace yieldlab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Арифметическая прогрессия:");
            var seq = ArProg(10, 2, 1.5);
            seq.Print();

            Console.WriteLine();

            Console.WriteLine("Первые n членов бесконечной последовательности:");
            int r = 7;
            Console.WriteLine("val = 7(int), n = 100:");
            r.Inf().TakeN(100).Print();
            Console.WriteLine();
            string s = "Hello";
            Console.WriteLine("val = Hello(string), n = 7:");
            s.Inf().TakeN(7).Print();

            Console.WriteLine();
            Console.WriteLine("Первые 20 членов бесконечной последовательности случайных чисел:");
            RandomInf().TakeN(20).Print();

            Console.WriteLine();
            Console.WriteLine("Первые 20 членов бесконечной арифметической прогрессии:");
            ArProgInf(1, 2).TakeN(20).Print();

            Console.WriteLine();
            Console.WriteLine("Первые 20 членов бесконечной последовательности чисел Фибоначчи:");
            FibInf().TakeN(20).Print();

            Console.WriteLine();
            Console.WriteLine("seq:");
            seq.Print();
            Console.WriteLine("Первые 20 членов бесконечной последовательности циклически повторяющихся элементов последовательности seq:");
            seq.RepeatInf().TakeN(30).Print();

            Console.WriteLine();
            Console.WriteLine("seq1:");
            var seq1 = ArProg(10, 10, -1);
            seq1.Print();
            Console.WriteLine("seq2:");
            var seq2 = ArProg(10, 1, 1);
            seq2.Print();
            Console.WriteLine("Последовательность пар:");
            seq1.Pairs(seq2).Print();

            Console.WriteLine();
            Console.WriteLine("seq:");
            var seq3 = ArProg(20, 1, 3);
            seq3.Print();
            Console.WriteLine("Отфильтрованная последовательность, состоящая только из четных элементов исходной последовательности целых чисел seq:");
            seq3.Even().Print();

            Console.WriteLine();
            Console.WriteLine("seq:");
            seq3.Print();
            Console.WriteLine("Преобразованная последовательность квадратов значений исходной последовательности целых чисел seq:");
            seq3.Sq().Print();

            Console.WriteLine();
            Console.WriteLine("seq1:");
            seq2.Print();
            Console.WriteLine("seq2:");
            seq3.Print();
            Console.WriteLine("Последовательность чередующихся элементов исходных последовательностей seq1 и seq2:");
            seq2.Alter(seq3).Print();

            Console.WriteLine();
            Console.WriteLine("seq:");
            seq2.Print();
            Console.WriteLine("Последовательность пар рядом стоящих значений в seq:");
            seq2.PairsInSeq().Print();
        }

        public static IEnumerable<double> ArProg(int n, double a0, double d)
        {
            for (int i = 0; i < n; i++)
                yield return a0 + i * d;
        }
        public static IEnumerable<int> ArProg(int n, int a0, int d)
        {
            for (int i = 0; i < n; i++)
                yield return a0 + i * d;
        }

        public static IEnumerable<int> RandomInf()
        {
            Random rand = new Random();
            while (true)
                yield return rand.Next(1, 100);
        }

        public static IEnumerable<double> ArProgInf(double a0, double d)
        {
            var i = a0;
            while (true)
            {
                yield return i;
                i += d;
            }
        }

        public static IEnumerable<int> FibInf()
        {
            int i = 0;
            int ii = 1;
            int s;
            while (true)
            {
                yield return ii;
                s = i;
                i = ii;
                ii += s;
            }
        }
    }
}
