using ImitationLibrary;
using System;

namespace TestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Random Rnd = new Random();

            int[] A = new int[100] ;

            for (int i = 0; i < A.Length; i++) { A[i] = Rnd.Next(1, 5000); }

            int Count = Linq.Count(A, x => x < 6);
            int[] Where = Linq.Where(A, x => x < 6);
            int[] Max = Linq.Max(A, x => x);
            Linq.Sort(A, x => x);
            Linq.Reverse(A);
        }
    }
}