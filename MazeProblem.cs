using System;

namespace Algorithms 
{
    public class Maze 
    {
        private int[,] map;
        private int[,] solution;

        public Maze(int[,] map)
        {
            this.map = map;
            int mapRow = map.GetLength(0);
            int mapCol = map.GetLength(1);
            this.solution = new int[mapRow, mapCol];
        }

        public void Solve() 
        {
            if (SolveProblem(0, 0))
            {
                ShowSolution();
            }
            else 
            {
                Console.WriteLine("There is no solution");
            }
        }
        public bool SolveProblem(int rowIndex, int colIndex) 
        {
            if (IsBaseCase(rowIndex,colIndex))
            {
                return true;//end of the algorithm
            }
            if (IsMoveValid(rowIndex,colIndex)) 
            {
                this.solution[rowIndex, colIndex] = 1;
                if (SolveProblem(rowIndex,colIndex+1))//move right
                {
                    return true;
                }
                if (SolveProblem(rowIndex+1,colIndex)) //move downwards
                {
                    return true;
                }
                //baktracking
                this.solution[rowIndex, colIndex] = 0;
            }
            return false;
        }

        public bool IsMoveValid(int rowIndex, int colIndex) 
        {
            if (rowIndex < 0 || rowIndex > this.map.GetLength(0)-1 ) 
            {
                return false;
            }
            if (colIndex < 0 || colIndex > this.map.GetLength(1)-1)
            {
                return false;
            }
            if (this.map[rowIndex,colIndex] == 0)
            {
                return false;
            }
            return true;
        }
        public bool IsBaseCase(int rowIndex, int colIndex)
        {
            if (rowIndex == this.map.GetLength(0)-1 && colIndex == this.map.GetLength(1)-1)
            {
                this.solution[rowIndex, colIndex] = 1;
                return true;
            }
            return false;
        }
        public void ShowSolution() 
        {
            for (int i=0;i<this.solution.GetLength(0);++i)
            {
                for (int j=0;j<this.solution.GetLength(1); ++j)
                {
                    if (this.solution[i, j] == 1)
                    {
                        Console.Write(" S ");
                    }
                    else 
                    {
                        Console.Write(" - ");
                    }
                }
                Console.WriteLine(" ");
            }
        }
    }
}