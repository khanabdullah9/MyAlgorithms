using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class HamiltonianAlgorithm
    {
        private int numOfVertexes;
        private int[] hamiltonianPath;
        private int[,] adjacencyMatrix;

        public void HamiltonianCycle(int[,] adjacencyMatrix) 
        {
            //this.adjacencyMatrix = adjacencyMatrix[0].Length;
        }

        private Boolean FindFeasibleSolution(int position) 
        {
            throw new NotImplementedException();
        }

        private Boolean IsFeasible(int vertex, int actualPosition) 
        {
            throw new NotImplementedException();

        }

        private void ShowHamiltonianPath() 
        {
            Console.WriteLine("Hamiltonian cycle exists: ");
            for (int i=0;i<numOfVertexes;++i) 
            {
                Console.Write(this.hamiltonianPath[i]+" ");
            }
            Console.WriteLine(this.hamiltonianPath[0
                ]);
        }
    }
}
