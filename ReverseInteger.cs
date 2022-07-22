using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class ReverseInteger
    {
        public static int Reversed(int n)
        {
            int remainder = 0;
            while (n>0) 
            {
                remainder = remainder * 10 + n % 10;
                n = n / 10;
            }
            return remainder;
        }
        
        public static bool IsPalindromeNumber(int n) 
        {
            return n.Equals(Reversed(n));
        }
    }
}
