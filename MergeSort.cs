using System;
using Algorithms;

namespace Sorting 
{
    public class MergeSort 
    {
        public static void Merge(int[] container, int low, int mid ,int high) 
        {
            int[] merged = new int[high-low+1];
            int idx1 = low, idx2 = mid+1, x =0;
            while (idx1 <= mid && idx2 <= high) 
            {
                if (container[idx1] <= container[idx2])
                {
                    merged[x] = container[idx1];
                    x++;//making space for the next element
                    idx1++;//moving to the next element
                }
                else 
                {
                    merged[x] = container[idx2];
                    x++;//making space for the next element
                    idx2++;//moving to the next element
                }
            }
            while (idx1 <= mid)
            {
                merged[x] = container[idx1];
                x++;//making space for the next element
                idx1++;//moving to the next element
            }
            while (idx2 <= high)
            {
                merged[x] = container[idx2];
                x++;//making space for the next element
                idx2++;//moving to the next element
            }
            for (int i=0, j=low; i<merged.Length;i++,j++) 
            {
                container[j] = merged[i];
            }
        }
        public static void Sort(int[] container, int low, int high) 
        {
            if (low<high) 
            {
                int middle = low + (high - low) / 2;
                Sort(container, low, middle);
                Sort(container, middle+1, high);
                Merge(container,low,middle,high);
            }
        }
    }
}