using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Factorial
    {
        public static int Factorials(int n) 
        {
            if (n == 1) 
            {
                return n;
            }
            if (n == 0) 
            {
                return 1;
            }
            return n * Factorials(n - 1);
        }
    }
}
