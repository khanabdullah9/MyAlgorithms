using System;

namespace Algorithms 
{
    internal class NQueensProblem 
    {
        private int numberOfQueens;
        private int[,] chessTable;

        public NQueensProblem(int numberOfQueens) 
        {
            this.numberOfQueens = numberOfQueens;
            this.chessTable = new int[numberOfQueens,numberOfQueens];
        }

        public void Solve() 
        {
            if (SetQueen(0))
            {
                PrintBoard();
                //Console.WriteLine("There is A valid solution");
            }
            else 
            {
                Console.WriteLine("There is NO valid solution");
            }
        }
        private bool SetQueen(int colIndex) 
        {
            if (colIndex == this.numberOfQueens) 
            {
                return true;//end of the algorithm
            }
            for (int rowIndex=0;rowIndex<this.numberOfQueens;++rowIndex) 
            {
                if (IsPlaceValid(rowIndex,colIndex))
                {
                    this.chessTable[rowIndex, colIndex] = 1;
                    if (SetQueen(colIndex+1)) 
                    {
                        return true;
                    }
                    //backtrack
                    this.chessTable[rowIndex, colIndex] = 0;
                }
            }
            return false;
        }
        private bool IsPlaceValid(int rowIndex, int colIndex) 
        {
            for (int i=0;i<colIndex;++i) 
            {
                if (this.chessTable[rowIndex,i] == 1) 
                {
                    return false;
                }
            }
            for (int i=rowIndex,j=colIndex;i>=0 && j>=0;i--,j--) 
            {
                if (this.chessTable[i,j] == 1) 
                {
                    return false;
                }
            }
            for (int i=rowIndex, j=colIndex; i<this.numberOfQueens && j>=0;i++,j--)
            {
                if (this.chessTable[i,j] == 1) 
                {
                    return false;
                }
            }
            return true;
        }
        private void PrintBoard() 
        {
            for (int i=0;i<this.numberOfQueens;++i) 
            {
                for (int j=0;j<this.numberOfQueens;++j) 
                {
                    if (this.chessTable[i, j] == 1)
                    {
                        Console.Write(" Q ");
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