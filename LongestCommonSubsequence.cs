using System;
using System.Text;

namespace Algorithms
{
    internal class LongestCommonSubsequence
    {
        private int[,] table;
        private string s1;
        private string s2;

        public LongestCommonSubsequence(string s1, string s2)
        {
            this.s1 = s1;
            this.s2 = s2;
            this.table = new int[s1.Length + 1, s2.Length + 1];
            //InitializeTable();
        }

        public void InitializeTable()
        {
            for (int a = 0; a < this.table.GetLength(0); ++a)
            {
                this.table[a, 0] = 0;
            }
            for (int b = 0; b < this.table.GetLength(1); ++b)
            {
                this.table[0, b] = 0;
            }
        }

        public void Solve()
        {
            SolveProblem();
            Console.WriteLine(FindLCS());
            PrintTable();
        }
        public void SolveProblem()
        {
            for (int r = 1; r < this.s1.Length + 1; ++r)
            {
                for (int c = 1; c < this.s2.Length + 1; ++c)
                {
                    if (this.s1[r - 1] == this.s2[c - 1])
                    {
                        this.table[r, c] = 1 + this.table[r - 1, c - 1];
                    }
                    else
                    {
                        this.table[r, c] = Math.Max(this.table[r - 1, c], this.table[r, c - 1]);
                    }
                }
            }
        }

        public string FindLCS()
        {
            string lcs = string.Empty;
            int m = s1.Length;
            int n = s2.Length;
            while (m > 0 && n > 0)
            {
                if (this.table[m - 1, n] == this.table[m, n - 1])//If the number above and the number to the left are same move diagonally to left (one step)
                {
                    lcs += this.s2[n - 1];
                    m--; n--;
                }
                else if (this.table[m - 1, n] > this.table[m, n - 1]) //If the cell one above has greater value than the cell one to the left move one cell above
                {
                    m--;
                }
                else
                {
                    n--;
                }
            }
            return Reverse(lcs);
        }

        public void PrintTable()
        {
            Console.WriteLine("The table looks like");
            for (int x = 0; x < this.table.GetLength(0); ++x)
            {
                for (int y = 0; y < this.table.GetLength(1); ++y)
                {
                    Console.Write(this.table[x, y] + " ");
                }
                Console.WriteLine(" ");
            }
        }

        public string Reverse(string s)
        {
            string str = string.Empty;
            for (int x = s.Length - 1; x >= 0; x--)
            {
                str += s[x].ToString();
            }
            return str;
        }
    }
}
/*
 How to traverse the table?
Start from the bottom right most cell.
If the cell above and the cell to the left have the same value then
move to the cell one above and one to the left (diagonally upward)
If the numbers are different then move to the left.
The cells from where you had to move diagonally will give you the 
LCS.
 */