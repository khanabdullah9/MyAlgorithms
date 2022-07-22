using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class GetDigitPlace
    {
        public static void Run(int n)
        {
            Console.WriteLine($"Digit at unit's place {n % 10}");
            Console.WriteLine($"Digit at ten's place {(n % 100) / 10}");
            Console.WriteLine($"Digit at hundred's place {(n % 1000) / 100}");
        }
    }
}
