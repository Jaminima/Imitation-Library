using ImitationLibrary;

namespace TestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] A = new int[] { 1, 5, 9, 2 };
            int p = Linq.Count<int>(A, x => x < 6);
            int[] B = Linq.Where<int>(A, x => x < 6);
        }
    }
}