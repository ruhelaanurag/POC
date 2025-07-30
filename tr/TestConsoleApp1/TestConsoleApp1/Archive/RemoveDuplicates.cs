using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp1
{
    internal class RemoveDuplicates
    {
        public void Remove()
        {
            int[] nums = { 1, 1, 2 };
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            Console.WriteLine(i + 1);
        }
    }
}
