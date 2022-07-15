using System;

namespace Algorithms 
{
    public class KnightTour
    {
        private int boardSize;
        private int[,] chessBoard;
        private int[] xMoves = { 2, 1, -1, -2, -2, -1, 1, 2 };
        private int[] yMoves = { 1, 2, 2, 1, -1, -2, -2, -1 };

        public KnightTour(int boardSize)
        {
            this.boardSize = boardSize;
            this.chessBoard = new int[boardSize,boardSize];
            InitializeChessBoard();
        }

        public void InitializeChessBoard() 
        {
            for (int i=0;i<this.boardSize;++i) 
            {
                for (int j=0;j<this.boardSize;++j)
                {
                    this.chessBoard[i, j] = int.MinValue;
                }
            }
        }

        public void Solve() 
        {
            this.chessBoard[0, 0] = 0;
            if (SolveProblem(1, 0, 0))
            {
                ShowSolution();
            }
            else 
            {
                Console.WriteLine("There is no valid solution");
            }
        }

        private bool SolveProblem(int stepCount, int x, int y) 
        {
            if (stepCount == this.boardSize * this.boardSize) 
            {
                return true;
            }
            for (int i=0;i<xMoves.Length;++i) 
            {
                int nextX = x + xMoves[i];
                int nextY = y + yMoves[i];
                if (IsFeasible(nextX, nextY)) 
                {
                    this.chessBoard[nextX, nextY] = stepCount;
                    if (SolveProblem(stepCount+1,nextX, nextY))
                    {
                        return true;
                    }
                    this.chessBoard[nextX, nextY] = int.MinValue;
                }
            }
            return false;
        }

        private bool IsFeasible(int x, int y) 
        {
            if (x<0 || x>=this.boardSize)
            {
                return false;
            }
            if (y < 0 || y >= this.boardSize)
            {
                return false;
            }
            if (this.chessBoard[x,y] != int.MinValue) //it is an visited value
            {
                return false;
            }
            return true;
        }

        private void ShowSolution() 
        {
            for (int i = 0; i < this.boardSize; ++i)
            {
                for (int j = 0; j < this.boardSize; ++j)
                {
                    if (this.chessBoard[i,j]<=9) 
                    {
                        Console.Write(this.chessBoard[i,j]+" ");
                    }
                    Console.Write(this.chessBoard[i, j] + " ");
                }
                Console.WriteLine(" ");
            }
        }
    }
}