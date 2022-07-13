using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    internal class QuickSort
    {
        public static int Partition(int[] container, int high, int low) 
        {
            int i = low, j = high;
            int pivot = container[low];
            while (i < j)
            {
                do
                {
                    i++;
                }
                while (container[i] <= pivot  );
                do
                {
                    j--;
                }
                while (container[j] > pivot);
                if (i < j)
                {
                    int temp1 = container[i];
                    container[i] = container[j];
                    container[j] = temp1;
                }
            }
            int temp2 = container[j];
            container[j] = container[low];
            container[low] = temp2;
            return j;
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
