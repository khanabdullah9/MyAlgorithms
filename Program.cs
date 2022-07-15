using System;

namespace Algorithms 
{
    public class Program 
    {
        public static void Main() 
        {
            int[] container = { 10, 9, 7, 6, 4, 3 };
            int[] container2 = {9,8,7,6,5,4,3,2,1};
            App.PrintArray(container2);
            Console.WriteLine();
            Sorting.QuickSort.GautiQS(container2, 0, container.Length - 1);
            App.PrintArray(container2);
        }
    }
}