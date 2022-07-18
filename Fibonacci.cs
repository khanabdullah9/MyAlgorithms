using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Fibonacci
    {
        public static int Series(int n)
        {
            if (n <= 1){return n;}
            else {return Fibonacci.Series(n-2) + Fibonacci.Series(n-1);}
        }
        /*
	     * Dynamic programming has O(N) running time complexity since the element is already present 
	     * in the table. But the space complexity increases in DP.
	     * */
        //top-down approach
        public static int SeriesWithMemoization(int n, Hashtable table)
        {
            if (!table.ContainsKey(n))
            {
                table.Add(n,SeriesWithMemoization(n-1,table)+SeriesWithMemoization(n-2,table));
            }
            return (int)table[n];
        }

        //bottom-up approach
        public static int SeriesWithTabulation(int n, Hashtable table)
        {
            for (int i = 2; i <= n; ++i)
            {
                try 
                {
                    table.Add(i, (int)table[i - 1] + (int)table[i - 2]);
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return (int)table[n];
        }
    }
}
