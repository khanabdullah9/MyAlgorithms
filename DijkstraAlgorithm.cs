using System;
using System.Collections;

namespace DijkstraAlgorithm 
{
    public class Node 
    {
        public string name;
        public Node predecessor;
        public ArrayList adjacentNodes;
        public int priority;
        public bool isVisited;
        public int minDistance = int.MaxValue;

        public Node(string name, int priority) 
        {
            this.name = name;
            this.priority = priority;
        }
    }

    public class Edge 
    {
        public int weight;
        public Node startNode;
        public Node targetNode;

        public Edge(int weight, Node startNode, Node targetNode) 
        {
            this.weight = weight;
            this.startNode = startNode;
            this.targetNode = targetNode;
        }
    }

    public class Algorithm
    {
        PriorityQueue<Node, int> heapq;
        public Algorithm(PriorityQueue<Node, int> heapq)
        {
            this.heapq = heapq;
        }
        public void Calculate(Node firstNode) 
        {
            this.heapq.Enqueue(firstNode, firstNode.priority);
            while (heapq.Count != 0)
            {
                Node actualNode = this.heapq.Dequeue();
                if (actualNode.isVisited)
                {
                    continue;
                }
                foreach (Edge edge in actualNode.adjacentNodes)
                {
                    var u = edge.startNode;
                    var v = edge.targetNode;
                    int new_distance = u.minDistance + edge.weight;
                    if (new_distance < v.minDistance)
                    {
                        v.minDistance = new_distance;
                        v.predecessor = u;
                    }
                    heapq.Enqueue(v,v.priority);
                }
            }
        }

        public void GetShortestPath(Node node) 
        {
            Console.WriteLine($"The shortest path to {node} is as follows");
            var actualNode = node;
            Console.WriteLine(node.name);
            while (actualNode.predecessor is not null)
            {
                actualNode = actualNode.predecessor;
                Console.WriteLine(actualNode.name);
            }
        }
    }
}

//public static void Main()
//{
//    DijkstraAlgorithm.Node n1 = new DijkstraAlgorithm.Node("A", 0);
//    DijkstraAlgorithm.Node n2 = new DijkstraAlgorithm.Node("B", 1);
//    DijkstraAlgorithm.Node n3 = new DijkstraAlgorithm.Node("C", 7);
//    DijkstraAlgorithm.Node n4 = new DijkstraAlgorithm.Node("D", 2);
//    DijkstraAlgorithm.Node n5 = new DijkstraAlgorithm.Node("E", 8);
//    DijkstraAlgorithm.Node n6 = new DijkstraAlgorithm.Node("F", 6);
//    DijkstraAlgorithm.Node n7 = new DijkstraAlgorithm.Node("G", 3);
//    DijkstraAlgorithm.Node n8 = new DijkstraAlgorithm.Node("H", 5);

//    DijkstraAlgorithm.Edge e1 = new DijkstraAlgorithm.Edge(5, n1, n2);
//    DijkstraAlgorithm.Edge e2 = new DijkstraAlgorithm.Edge(8, n1, n8);
//    DijkstraAlgorithm.Edge e3 = new DijkstraAlgorithm.Edge(9, n1, n5);
//    DijkstraAlgorithm.Edge e4 = new DijkstraAlgorithm.Edge(15, n2, n4);
//    DijkstraAlgorithm.Edge e5 = new DijkstraAlgorithm.Edge(12, n2, n3);
//    DijkstraAlgorithm.Edge e6 = new DijkstraAlgorithm.Edge(4, n2, n8);
//    DijkstraAlgorithm.Edge e7 = new DijkstraAlgorithm.Edge(7, n8, n3);
//    DijkstraAlgorithm.Edge e8 = new DijkstraAlgorithm.Edge(6, n8, n6);
//    DijkstraAlgorithm.Edge e9 = new DijkstraAlgorithm.Edge(5, n5, n6);
//    DijkstraAlgorithm.Edge e10 = new DijkstraAlgorithm.Edge(4, n5, n7);
//    DijkstraAlgorithm.Edge e11 = new DijkstraAlgorithm.Edge(20, n5, n7);
//    DijkstraAlgorithm.Edge e12 = new DijkstraAlgorithm.Edge(1, n6, n3);
//    DijkstraAlgorithm.Edge e13 = new DijkstraAlgorithm.Edge(13, n6, n7);
//    DijkstraAlgorithm.Edge e14 = new DijkstraAlgorithm.Edge(3, n3, n4);
//    DijkstraAlgorithm.Edge e15 = new DijkstraAlgorithm.Edge(11, n3, n7);
//    DijkstraAlgorithm.Edge e16 = new DijkstraAlgorithm.Edge(9, n4, n7);

//    n1.adjacentNodes.Add(e1);
//    n1.adjacentNodes.Add(e2);
//    n1.adjacentNodes.Add(e3);
//    n2.adjacentNodes.Add(e4);
//    n2.adjacentNodes.Add(e5);
//    n2.adjacentNodes.Add(e6);
//    n8.adjacentNodes.Add(e7);
//    n8.adjacentNodes.Add(e8);
//    n5.adjacentNodes.Add(e9);
//    n5.adjacentNodes.Add(e10);
//    n5.adjacentNodes.Add(e11);
//    n6.adjacentNodes.Add(e12);
//    n6.adjacentNodes.Add(e13);
//    n3.adjacentNodes.Add(e14);
//    n3.adjacentNodes.Add(e15);
//    n4.adjacentNodes.Add(e16);

//    PriorityQueue<DijkstraAlgorithm.Node, int> heapq = new PriorityQueue<DijkstraAlgorithm.Node, int>();
//    DijkstraAlgorithm.Algorithm algorithm = new DijkstraAlgorithm.Algorithm(heapq);
//    algorithm.Calculate(n1);
//    algorithm.GetShortestPath(n8);
//}