using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms;

namespace Sorting
{
    internal class QuickSort
    {
        public static int Partition(int[] container, int low, int high)
        {
            int pivot = container[low], i=low, j=high;
            int temp;
            while (i<j) 
            {
                do
                {
                    i++;
                }
                while (container[i] <= pivot);
                do
                {
                    j--;
                }
                while (container[j] > pivot);
                if (i<j) 
                {
                    temp = container[i];
                    container[i] = container[j];
                    container[j] = temp;
                }
            }
            temp = container[low];
            container[low] = container[j];
            container[j] = container[low];
            return j;
        }
        public static void Sort(int[] container, int low, int high) 
        {
            if (low<high) 
            {
                int partition = Partition(container,high,low);
                //App.Debugger("test","TEST","QuickSort","Sort",$"partition={partition}");
                Sort(container,low, partition-1);
                Sort(container, partition + 1 , high);
            }
        }

        /*WORST CASE THE PIVOT IS THE LARGEST ELEMENT*/
        public static void GautiQS(int[] container, int low, int high)
        {
            int indexOfPivot = high;
            int pivot = container[indexOfPivot];
            for (int i=0;i<container.Length/2;++i) 
            {
                if (i.Equals(indexOfPivot))
                {
                    continue;//Do not disturb the pivot//Work around the pivot
                }
                if (container[i] > pivot)
                {
                    int n = container.Length - 1;
                    App.Swap(container,i,n-i);
                }
            }
        }
    }
}
