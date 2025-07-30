using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp1
{
    internal class ReplaceOnRight
    {
        public void ReplaceElements(int[] arr)
        {
            //17, 18, 5, 4, 6, 1
            int max = arr[arr.Length - 1];
            arr[arr.Length - 1] = -1;
            //arr[arr.Length - 1] = max;
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                int temp = arr[i];
                arr[i] = max;
                if (temp > max)
                {
                    max = temp;
                }
            }
        }
    }
}
