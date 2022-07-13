using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class PrimeNumber
    {
        public static bool IsPrime(int n)
        {
            bool isPrime = true;
            for (int i = 2; i <= n / 2; ++i)
            {
                if (n%i==0) 
                {
                    isPrime = false;
                }
            }
            return isPrime;
        }
    }
}
