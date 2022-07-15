using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    internal class QuickSort
    {
        public static int Partition(int[] intArray, int low, int high)
        {
            int pi = intArray[high];
            int i = (low - 1); // smaller element index
            for (int j = low; j < high; j++)
            {
                // check if current element is less than or equal to pi
                if (intArray[j] <= pi)
                {
                    i++;
                    // swap intArray[i] and intArray[j]
                    int temp1 = intArray[i];
                    intArray[i] = intArray[j];
                    intArray[j] = temp1;
                }
            }
            // swap intArray[i+1] and intArray[high] (or pi)
            int temp2 = intArray[i + 1];
            intArray[i + 1] = intArray[high];
            intArray[high] = temp2;
            return i + 1;
        }
        public static void Sort(int[] container, int low, int high) 
        {
            if (low<high) 
            {
                int partition = Partition(container,high,low);
                Sort(container,low, partition-1);
                Sort(container,low, partition + 1);
            }
        }
    }
}
