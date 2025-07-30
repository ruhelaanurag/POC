using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp1
{
    internal class MergeTwoArr
    {
        public void MergeTwo()
        {
            int[] nums1 = new int[] {1,2,3,0,0,0 };
            int m = 3;
            int[] nums2 = new int[] {2,5,6 };
            int n = 3;
            //public void Merge(int[] nums1, int m, int[] nums2, int n)
            //{

            int[] arr = new int[m + n];

            Array.Copy(nums1, arr, m+n);

            int idxn = 0;

            int idxarr = 0;
            int i = 0;
            for (; idxn<n && idxarr<m; i++)

            {
                if (idxn < n)
                {
                    if (arr[idxarr] > nums2[idxn])

                    {

                        nums1[i] = nums2[idxn];

                        idxn++;

                    }

                    else

                    {

                        nums1[i] = arr[idxarr];

                        idxarr++;

                    }
                }
            }
            while (idxn < n)
            {
                nums1[i] = nums2[idxn];
                idxn++;i++;
            }
        }
    }
}
