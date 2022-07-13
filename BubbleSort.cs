using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    internal class BubbleSort
    {
        public static void Sort(int[] container) 
        {
            for (int i=0;i<container.Length;++i)
            {
                for (int j=1; j<container.Length-i;++j) 
                {
                    if (container[j-1] > container[j])
                    {
                        int temp = container[j];
                        container[j] = container[j - 1];
                        container[j - 1] = temp;
                    }
                }
            }
        }
    }
}
