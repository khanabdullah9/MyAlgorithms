using System;
using System.Collections;
using Kruskal;

namespace Algorithms 
{
    public class Program 
    {
        public static void Main() 
        {
            int n = 3;
            int m = 50;
            int[] weights = { 0, 10, 20, 30 };
            int[] profits = { 0, 60, 100, 120 };
            Knapsack knapsack = new Knapsack(n,m,weights,profits);
            knapsack.Solve();
            knapsack.PrintTable();
        }
    }
}