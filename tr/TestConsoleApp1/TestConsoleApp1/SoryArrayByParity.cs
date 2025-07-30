using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp1
{
    internal class SoryArrayByParity
    {
        public void SortByParity(int[] nums)
        {
            int even = 0;
            int odd = nums.Length - 1;
            while (even <= odd)
            {
                if (nums[even] % 2 == 0) even++;
                else if (nums[odd] % 2 != 0) odd--;
                else if (nums[odd] % 2 == 0 && nums[even] % 2 != 0)
                {
                    int temp = nums[odd];
                    nums[odd] = nums[even];
                    nums[even] = temp;
                    even++; odd--;
                }
            }
            //return nums;
        }
    }
}
