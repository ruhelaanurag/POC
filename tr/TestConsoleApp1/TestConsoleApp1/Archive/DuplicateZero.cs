using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp1
{
    public class DuplicateZero
    {
        public void dupZero()
        {
            Console.WriteLine("Try programiz.pro");
            int[] arr = new int[] { 1, 0, 2, 3, 0, 4, 5, 0 };
            int[] copy = new int[arr.Length];
            Array.Copy(arr, copy, arr.Length);
            int idx = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int value = copy[idx];
                if (value == 0)
                {
                    arr[i] = value;
                    arr[i + 1] = value;
                    i++;
                }
                else
                {
                    arr[i] = value;
                }
                idx++;
                //foreach (var a in arr)
                //    Console.Write(a + " , ");
                //Console.WriteLine();
            }
            foreach (var a in arr)
                Console.Write(a + " , ");
        }
    }
}
