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

        public static T[] Max<T>(T[] Arr, Func<T, int> Value)
        {
            T Top = Arr[0];
            foreach (T item in Arr)
            {
                if (Value(Top) < Value(item)) { Top = item; }
            }
            return Where(Arr, x => Value(x) == Value(Top));
        }

        public static bool Contains<T>(T[] Arr, Func<T, bool> Check)
        {
            foreach (T item in Arr)
            {
                if (Check(item)) { return true; }
            }
            return false;
        }

        public static void Reverse<T>(T[] Arr)
        {
            T Temp; int Length = Arr.Length;
            for (int i = 0; i < (int)Math.Floor((decimal)Length / 2); i++)
            {
                Temp = Arr[i];
                Arr[i] = Arr[Length - i - 1];
                Arr[Length - i - 1] = Temp;
            }
        }

        public static void Sort<T>(T[] Arr, Func<T, int> Value)
        {
            T Temp; bool SwapOccurred = true; int K = 1;
            while (SwapOccurred)
            {
                SwapOccurred = false;
                for (int i = 0; i < Arr.Length - K; i++)
                {
                    if (Value(Arr[i]) > Value(Arr[i + 1]))
                    {
                        Temp = Arr[i];
                        Arr[i] = Arr[i + 1];
                        Arr[i + 1] = Temp;
                        SwapOccurred = true;
                    }
                }
                K++;
            }
        }
    }
}