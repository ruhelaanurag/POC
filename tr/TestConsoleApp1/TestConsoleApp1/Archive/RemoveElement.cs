using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp1
{
    public class RemoveElement
    {
        public void Remove()
        {
            int[] nums = { 3, 2, 2, 3 };
            int val = 3;
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            Console.WriteLine(i);
        }
    }
}
