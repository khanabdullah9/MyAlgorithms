using System;
using System.Collections;
using Kruskal;
using Sorting;

namespace Algorithms 
{
    public class Program 
    {
        public static void Main() 
        {
            int[] nums = { 5,4,3,1,2};
            QuickSort qs = new QuickSort();
            qs.Sort(nums,0,nums.Length-1);
            foreach (var n in nums)
            {
                Console.Write(n+" ");   
            }
        }
    }
}