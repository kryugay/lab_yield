using System;
using System.Collections.Generic;
using System.Linq;

namespace yieldlab

{
    public static class myFuncs
    {
        public static void Print<T>(this IEnumerable<T> seq)
        {
            foreach (var x in seq)
                Console.Write(x + " ");
            Console.WriteLine();
        }

        public static IEnumerable<T> Inf<T>(this T s)
        {
            while (true)
                yield return s;
        }

        public static IEnumerable<T> TakeN<T>(this IEnumerable<T> seq, int n)
        {
            int i = 0;
            foreach (var q in seq)
            {
                yield return q;
                i++;
                if (i == n)
                    break;
            }
        }
        public static IEnumerable<T> RepeatInf<T>(this IEnumerable<T> seq)
        {
            while (true)
                foreach (var q in seq)
                    yield return q;
        }

        public static IEnumerable<Tuple<T1, T2>> Pairs<T1, T2>(this IEnumerable<T1> seq1, IEnumerable<T2> seq2)
        {
            for (int i = 0; i < seq1.Count(); i++)
                yield return Tuple.Create(seq1.ElementAt(i), seq2.ElementAt(i));
        }

        public static IEnumerable<int> Even(this IEnumerable<int> seq)
        {
            foreach (var q in seq)
                if (q % 2 == 0)
                    yield return q;
        }

        public static IEnumerable<int> Sq(this IEnumerable<int> seq)
        {
            foreach (var q in seq)
                yield return q * q;
        }

        public static IEnumerable<T> Alter<T>(this IEnumerable<T> seq1, IEnumerable<T> seq2)
        {
            int k = Math.Max(seq1.Count(), seq2.Count());
            for (int i = 0; i < k; i++)
            {
                if (seq1.Count() > i)
                    yield return seq1.ElementAt(i);
                if (seq2.Count() > i)
                    yield return seq2.ElementAt(i);
            }
        }

        public static IEnumerable<Tuple<T, T>> PairsInSeq<T>(this IEnumerable<T> seq)
        {
            for (int i = 0; i < seq.Count() - 1; i++)
                yield return Tuple.Create(seq.ElementAt(i), seq.ElementAt(i + 1));
        }

    }
}
