using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Knapsack
    {
        private int n;//number of items
        private int m;//total capacity
        private int[] weights;
        private int[] profits;
        private int[,] S;//2d array

        public Knapsack(int n, int m, int[] weights, int[] profits) 
        {
            this.n = n; 
            this.m = m;
            this.weights = weights;
            this.profits = profits;
            this.S = new int[n+1, m+1];//as per the theory
            InitializeTable();
        }

        public void InitializeTable() 
        {
            for (int i=0;i<=0;++i)
            {
                for (int j=0;j<m+1;++j)
                {
                    this.S[i,j] = 0;
                }
            }

            for (int k=0;k<n+1;++k) 
            {
                for (int l=0;l<=0;++l) 
                {
                    this.S[k, l] = 0;
                }
            }
        }
        public void Solve() 
        {
            for (int i=1;i<n+1;++i) //for items
            {
                for (int w=1;w<m+1;++w)// for weights
                {
                    if (this.weights[i] <= w)// make sure the weight is within the column weight
                    {
                        int ifNotTaking = this.S[i - 1, w];
                        int ifTaking = this.S[i - 1, w - this.weights[i]] + this.profits[i];
                        this.S[i, w] = Math.Max(ifNotTaking, ifTaking);
                    }
                }
            }
            ShowSolution();
        }

        public void ShowSolution() 
        {
            Console.WriteLine($"Maximum profit: {this.S[n, m]}");
            for (int i = n, w = this.m; i > 0;--i) 
            {
                if (this.S[i,w] !=0 && this.S[i, w] != this.S[i-1,w])
                {
                    Console.WriteLine("Taking item #"+i);
                    w = w - weights[i];
                }
            }
        }

        public void PrintTable() 
        {
            for (int i=0;i<this.n+1;++i) 
            {
                for (int j=0;j<this.m+1;++j)
                {
                    Console.Write(this.S[i,j]+" ");
                }
                Console.WriteLine(" ");
            }
        }
    }
}
//FORMULA: v[i,w] = max(v[i-1,w],v[i-1,w-w[i]]+p[i])
