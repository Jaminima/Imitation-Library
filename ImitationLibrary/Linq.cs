using System;

namespace ImitationLibrary
{
    public static class Linq
    {
        public static void ForEach<T>(T[] Arr, Func<T, T> Function)
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                Arr[i] = Function(Arr[i]);
            }
        }

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

        public static int Sum<T>(T[] Arr, Func<T, int> Value)
        {
            int Sum = 0;
            foreach (T item in Arr)
            {
                Sum += Value(item);
            }
            return Sum;
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

        public static T[] Min<T>(T[] Arr, Func<T, int> Value)
        {
            T Bot = Arr[0];
            foreach (T item in Arr)
            {
                if (Value(Bot) > Value(item)) { Bot = item; }
            }
            return Where(Arr, x => Value(x) == Value(Bot));
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

        public static T[][] Split<T>(T[] Arr, int Start, int Split, int End)
        {
            T[][] Out = new T[2][];
            Out[0] = new T[Split - Start];
            for (int i = Start; i < Split; i++) { Out[0][i - Start] = Arr[i]; }
            Out[1] = new T[End - Split + 1];
            for (int i = Split; i <= End; i++) { Out[1][i - Split] = Arr[i]; }
            return Out;
        }

        public static void Sort<T>(T[] Arr, Func<T, int> Value)
        {
            Sorting.MergeSort(Arr, Value, 0, Arr.Length - 1);
        }
    }
}