using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGFG
{
    internal class ArrPushZeroToEnd
    {
        public static string input = "0 0 1 3 5 0 2";
        //public static string input = "1 2 0 4 3 0 5 0";

        public static void pushZerosToEnd(int[] arr)
        {
            int s = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0) //find next non-zero element
                {
                    s = i;
                    while (arr[s] == 0 && s < arr.Length - 1) s++;
                    //replace
                    arr[i] = arr[s];
                    arr[s] = 0;
                    i = s;
                }
            }
        }
        public static void pushZerosToEnd_One(int[] arr)
        {
            int end = arr.Length-1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i >= end) return;
                if (arr[i] == 0)
                {
                    arr[i] = arr[end];
                    arr[end] = 0;
                    end--;
                }
                while (arr[end] == 0 && end > i) end--;

            }
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
        }
    }
}
