using ImitationLibrary;

namespace TestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] A = new int[] { 1, 5, 9, 2 };
            int Count = Linq.Count<int>(A, x => x < 6);
            int[] Where = Linq.Where<int>(A, x => x < 6);
            int Max = Linq.Max<int>(A, x => x);
        }
    }
}