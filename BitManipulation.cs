using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class BitManipulation
    {
        public static int CountBits(int n) 
        {
            int count = 0;
            while (n>0)
            {
                count++;
                /*
                 * right shift divides the number by 2
                 * left shift double the number
                 */
                n = n >> 1;
            }
            return count;
        }
    }
}
