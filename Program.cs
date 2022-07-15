using System;

namespace Algorithms 
{
    public class Program 
    {
        public static void Main() 
        {
            int[] container = {10,9,7,6,4,3};
            Sorting.MergeSort.Sort(container, 0, container.Length-1);
            foreach (int num in container)
            {
                Console.Write(num+" ");
            }
        }
    }
}