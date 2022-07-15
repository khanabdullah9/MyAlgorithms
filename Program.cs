using System;

namespace Algorithms 
{
    public class Program 
    {
        public static void Main() 
        {
            for (int i=1;i<=10;++i) 
            {
                Console.WriteLine($"Trying for {i}");
                KnightTour problem = new KnightTour(i);
                problem.Solve();
            }
        }
    }
}