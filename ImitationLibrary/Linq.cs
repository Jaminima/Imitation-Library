using System;

namespace ImitationLibrary
{
    public static class Linq
    {
        public static void ForEach<T>(T[] Arr, Func<T, T> Function)
        {
            if (Arr.Length == 0) { return; }//Ensure Array has items to operate on
            for (int i = 0; i < Arr.Length; i++)
            { //For every item perform the function and overwrite the item in the array
                Arr[i] = Function(Arr[i]);
            }
        }

        public static void ForEach<T>(T[] Arr, Action<T> Function)
        {
            if (Arr.Length == 0) { return; }//Ensure Array has items to operate on
            for (int i = 0; i < Arr.Length; i++)
            { //For every item in the array, perform the function on it
                Function(Arr[i]);
            }
        }

        public static int Count<T>(T[] Arr, Func<T, bool> Check)
        {
            int C = 0;//Store the count
            foreach (T item in Arr)
            {//Increase the count when an item meets the Check
                if (Check(item)) { C++; }
            }
            return C;
        }

        public static T[] Where<T>(T[] Arr, Func<T, bool> Check)
        {
            T[] Set = new T[Count<T>(Arr, Check)];//Create a set as long as the amount of items that meet the case
            int Pos = 0;
            foreach (T item in Arr)
            {//Add each item into the new array if they meet the check
                if (Check(item)) { Set[Pos] = item; Pos++; }
            }
            return Set;
        }

        public static I Sum<T, I>(T[] Arr, Func<T, I> Value) where I : IComparable<I>
        {
            dynamic Sum = 0;//Store the sum
            foreach (T item in Arr)
            {//Add the value of each item into the Sum
                Sum += Value(item);
            }
            return Sum;
        }

        public static T[] Max<T, I>(T[] Arr, Func<T, I> Value) where I : IComparable<I>
        {
            T Top = Arr[0];//Stores the current greatest value
            foreach (T item in Arr)
            {//Check if the item is larger than Top, if it is, replace Top
                if (Value(Top).CompareTo(Value(item))==-1) { Top = item; }
            }
            return Where(Arr, x => Value(x).Equals(Value(Top))); //Return the objects with the largest value
        }

        public static T[] Min<T, I>(T[] Arr, Func<T, I> Value) where I : IComparable<I>
        {
            T Bot = Arr[0];//Stores the current smallest value
            foreach (T item in Arr)
            {//Check if the item is smaller than Bot, if it is, replace Bot
                if (Value(Bot).CompareTo(Value(item))==1) { Bot = item; }
            }
            return Where(Arr, x => Value(x).Equals(Value(Bot)));//Return the objects with the smallest value
        }

        public static bool Contains<T>(T[] Arr, Func<T, bool> Check)
        {
            foreach (T item in Arr)
            {//Check if the item matches the check, and return true if one does
                if (Check(item)) { return true; }
            }
            return false;//If no items match, return false
        }

        public static void Reverse<T>(T[] Arr)
        {
            T Temp;//Store a value during the swap
            int Length = Arr.Length;
            for (int i = 0; i < (int)Math.Floor((decimal)Length / 2); i++)//We only want to itterate through the first half of the array
            {
                Temp = Arr[i];//Store temporarily
                Arr[i] = Arr[Length - i - 1];//Take from the second half of the array and put it in the first half
                Arr[Length - i - 1] = Temp;//Take the temp value into the second half of the array
            }
        }

        public static T[][] Split<T>(T[] Arr, int Start, int Split, int End)
        {
            T[][] Out = new T[2][];//Store the 2 parts of the array
            Out[0] = new T[Split - Start];//Store all values between the start and Split of the arr into the first part of the array
            for (int i = Start; i < Split; i++) { Out[0][i - Start] = Arr[i]; }
            Out[1] = new T[End - Split + 1];//Store all values between the split and end of the arr into the second part of the array
            for (int i = Split; i <= End; i++) { Out[1][i - Split] = Arr[i]; }
            return Out;
        }

        public static void Sort<T, I>(T[] Arr, Func<T, I> Value) where I : IComparable<I>
        {
            if (Arr.Length < 2) { return; }//Ensure Array has items to operate on
            Sorting.MergeSort(Arr, Value, 0, Arr.Length - 1);//Perform merge sort on the whole array
        }
    }
}