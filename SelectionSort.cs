using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    internal class SelectionSort
    {
        public static void Sort(int[] container) 
        {
            for (int i=0;i<container.Length;++i) 
            {
                int smallest = container[i];
                for (int j=i+1;j<container.Length;++j) 
                {
                    if (container[j] < smallest)
                    {
                        int temp = smallest;
                        smallest = container[j];
                        container[j] = temp;
                    }
                }
                int temp2 = smallest;
                smallest = container[i];
                container[i] = temp2;
            }
        }
    }
}
