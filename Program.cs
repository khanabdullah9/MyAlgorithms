using System;
using System.Collections;

namespace Algorithms 
{
    public class Program 
    {
        public static void Main() 
        {
            Hashtable table = new Hashtable();
            table.Add(0,1);
            table.Add(1,1);
            Console.WriteLine(Fibonacci.SeriesWithMemoization(8,table));
            Console.WriteLine(Fibonacci.SeriesWithTabulation(8, table));
        }
    }
}