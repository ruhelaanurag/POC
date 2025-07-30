using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp1
{
    internal class Mountain
    {
        public bool ValidMountainArray()
        {
            int[] arr = new int[] { 0, 3, 2, 1 };

            bool increasing = false;

            bool decreasing = false;

            for (int i = 1; i < arr.Length; i++)

            {

                if (arr[i] > arr[i - 1]) increasing = true;

                else if (arr[i] < arr[i - 1]) decreasing = true;
                else
                return false;

            }

            return increasing && decreasing;

        }

        public void MountainArray()
        {
            int[] nums = { 0, 2, 3, 4, 5, 2, 1, 0 };
            int i = 0;
            int n = nums.Length;
            while (i + 1 < n && nums[i] < nums[i + 1])
            {
                i++;
            }
            if (i == 0 || i == n - 1)
            {
                Console.WriteLine(false);
                return;
            }
            while (i + 1 < n && nums[i] > nums[i + 1])
            {
                i++;
            }
            Console.WriteLine(i == n - 1);
        }   
    }
}
