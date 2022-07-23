using System;

namespace Sorting 
{
    internal class QuickSort 
    {
        public int Partition(int[] container, int low, int high) 
        {
            int pivot = container[high];
            int i = low - 1; //keeps track of the number of element sorted//initially none
            for (int j = low; j < high; ++j)
            {
                if (container[j] < pivot) 
                {
                    i++;//making space for the sorted element
                    //Swapping with the unsorted
                    int temp = container[j];
                    container[j] = container[i];
                    container[i] = temp;
                }
            }
            //Now to sort the pivot
            i++;
            int temp2 = container[i];
            container[i] = container[high];
            container[high] = temp2;
            return i;//partition
        }
        public void Sort(int[] container, int low, int high)
        {
            if (low < high)
            {
                int partition = Partition(container,low,high);
                Partition(container,low,partition-1);
                Partition(container, partition + 1, high);
            }
        }
    }
}