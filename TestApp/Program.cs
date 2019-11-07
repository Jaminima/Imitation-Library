using ImitationLibrary;

namespace TestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] A = new int[] { 1, 5, 9, 2 };
            int Count = Linq.Count(A, x => x < 6);
            int[] Where = Linq.Where(A, x => x < 6);
            int[] Max = Linq.Max(A, x => x);
            Linq.Sort(A, x => x);
            Linq.Reverse(A);
        }
    }
}