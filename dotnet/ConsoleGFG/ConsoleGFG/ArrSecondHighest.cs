using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGFG
{
	public static class Arr_SecondHighest
    {
        public static string input = "28078 19451 935 28892 2242 3570 5480 231";
        //string input = "12 35 1 10 34 1";

        public static int findNumber(int[] arr)
		{
			// Code Here
			int max = -1, smax = -1;
			for (int i = 0; i < arr.Length; i++)
			{
				int curr = arr[i];
				if (curr > max)
				{
					smax = max;
					max = curr;
				}
				if (curr < max && curr > smax)
					smax = curr;
			}
			return smax;
		}
	}
}
