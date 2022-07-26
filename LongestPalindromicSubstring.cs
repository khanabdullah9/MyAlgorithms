using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class LongestPalindromicSubstring
    {
        public int Find(string s) 
        {
            bool[,] table = new bool[s.Length,s.Length];
            int maxLength = 1;
            for (int i=0;i<s.Length;++i) //substrings of length 1
            {
                table[i, i] = true;
            }
            int start = 0;
            for (int i=0;i<s.Length-1; ++i) 
            {
                if (s[i] == s[i+1]) 
                {
                    table[i, i + 1] = true;
                    start = i;
                    maxLength = 2;
                }
            }
            for (int l=3;l<=s.Length;l++) //length of l
            {
                for (int i=0;i<s.Length-l+1;++i)//use +1 or <=
                {
                    int j = i + l - 1;
                    if (table[i+1,j-1] && s[i] == s[j])
                    {
                        table[i, j] = true;
                        if (l > maxLength)
                        {
                            maxLength = l;
                            start = i;
                        }
                    }
                }
            }
            Console.WriteLine($"Longest palindromic string from {s} is {s.Substring(start, start + maxLength - 1)}");
            PrintTable(table);
            return maxLength;
        }
        public void PrintTable(bool[,] table) 
        {
            Console.WriteLine("Table looks like: ");
            for (int i=0;i<table.GetLength(0);++i) 
            {
                for (int j=0;j<table.GetLength(1);++j) 
                {
                    Console.Write(Convert.ToInt32(table[i,j])+" ");
                }
                Console.WriteLine(" ");
            }
        }
    }
}
