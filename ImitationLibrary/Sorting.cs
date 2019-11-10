using System;

namespace ImitationLibrary
{
    public static class Sorting
    {
        public static void MergeSort<T>(T[] Arr, Func<T, int> Value, int Left, int Right)
        {
            int Middle = (int)Math.Ceiling((double)(Left + Right) / 2);
            if (Right - Left > 1)
            {
                MergeSort(Arr, Value, Left, Middle - 1);
                MergeSort(Arr, Value, Middle, Right);
                Merge(Arr, Left, Linq.Split(Arr, Left, Middle, Right), Value);
            }
            else
            {
                if (Value(Arr[Left]) > Value(Arr[Right]))
                {
                    Swap(Arr, Left, Right);
                }
            }
        }

        private static void Merge<T>(T[] Arr, int Left, T[][] SetsToMerge, Func<T, int> Value)
        {
            int LeftLength = SetsToMerge[0].Length, RightLength = SetsToMerge[1].Length;
            for (int i = Left, iL = 0, iR = 0; iL < LeftLength || iR < RightLength; i++)
            {
                if (iL >= LeftLength) { Arr[i] = SetsToMerge[1][iR]; iR++; }
                else if (iR >= RightLength) { Arr[i] = SetsToMerge[0][iL]; iL++; }
                else if (Value(SetsToMerge[0][iL]) > Value(SetsToMerge[1][iR]))
                {
                    Arr[i] = SetsToMerge[1][iR];
                    iR++;
                }
                else
                {
                    Arr[i] = SetsToMerge[0][iL];
                    iL++;
                }
            }
        }

        private static void Swap<T>(T[] Arr, int i1, int i2)
        {
            T Temp = Arr[i1];
            Arr[i1] = Arr[i2];
            Arr[i2] = Temp;
        }
    }
}