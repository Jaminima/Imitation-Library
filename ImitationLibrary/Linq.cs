using System;

namespace ImitationLibrary
{
    public static class Linq
    {
        public static int Count<T>(T[] Arr, Func<T, bool> Check)
        {
            int C = 0;
            foreach (T item in Arr)
            {
                if (Check(item)) { C++; }
            }
            return C;
        }

        public static T[] Where<T>(T[] Arr, Func<T, bool> Check)
        {
            T[] Set = new T[Count<T>(Arr, Check)];
            int Pos = 0;
            foreach (T item in Arr)
            {
                if (Check(item)) { Set[Pos] = item; Pos++; }
            }
            return Set;
        }
    }
}