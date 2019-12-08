using System;

namespace ImitationLibrary
{
    public static class Sorting
    {
        public static void MergeSort<T>(T[] Arr, Func<T, int> Value, int Left, int Right)
        {
            int Middle = (int)Math.Ceiling((double)(Left + Right) / 2);//Find the middle index of the array
            if (Right - Left > 1)//Check to see if we have 3 or more values to sort
            {
                MergeSort(Arr, Value, Left, Middle - 1);//Merge sort on the left side
                MergeSort(Arr, Value, Middle, Right);//Merge sort on the right side
                Merge(Arr, Left, Linq.Split(Arr, Left, Middle, Right), Value);//Merge to 2 sides together
            }
            else
            {
                if (Value(Arr[Left]) > Value(Arr[Right]))//Swap the 2 values if they are the wrong way round
                {
                    Swap(Arr, Left, Right);
                }
            }
        }

        private static void Merge<T>(T[] Arr, int Left, T[][] SetsToMerge, Func<T, int> Value)
        {
            int LeftLength = SetsToMerge[0].Length, RightLength = SetsToMerge[1].Length;//Determine the size of the regions we are merging
            for (int i = Left, iL = 0, iR = 0; iL < LeftLength || iR < RightLength; i++)//Iterate until we have merged all values on both regions
            {
                if (iL >= LeftLength) { Arr[i] = SetsToMerge[1][iR]; iR++; }//If one side is completely searched through, just keep itterating the other side
                else if (iR >= RightLength) { Arr[i] = SetsToMerge[0][iL]; iL++; }
                else if (Value(SetsToMerge[0][iL]) > Value(SetsToMerge[1][iR]))
                {//Check if values are in the right place, and move them if they are not, then itterate the appropriate side
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
        {//Swap 2 idexes around
            T Temp = Arr[i1];
            Arr[i1] = Arr[i2];
            Arr[i2] = Temp;
        }
    }
}