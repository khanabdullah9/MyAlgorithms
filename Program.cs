using System;
using System.Collections;
using Kruskal;

namespace Algorithms 
{
    public class Program 
    {
        public static void Main() 
        {
            int[,] map = { { 1,0,0,0},
                           { 1,1,0,1},
                           { 0,1,0,0},
                           { 1,1,1,1}};
            Maze problem = new Maze(map);
            problem.Solve();
        }
    }
}