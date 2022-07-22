using System;

namespace Kruskal 
{
    public class Edge
    {
        public int weight;
        public Node startNode;
        public Node targetNode;

        public Edge(int weight,Node startNode, Node targetNode)
        {
            this.weight = weight;
            this.startNode = startNode;
            this.targetNode = targetNode;
        }

        public static void Sort(List<Edge> edges) 
        {
            for (int i=0;i<edges.Count();++i) 
            {
                int smallestIdx = i;//index of the edge with the smallest weight
                for (int j=i+1;j<edges.Count();++j) 
                {
                    if (edges[j].weight < edges[smallestIdx].weight)
                    {
                        int t1 = j;
                        j = smallestIdx;
                        smallestIdx = t1;
                    }
                }
                //swap the edge
                var t2 = edges[i];
                edges[i] = edges[smallestIdx];
                edges[smallestIdx] = t2;
            }
        }
    }
    public class Node
    {
        public string name;
        public Node rootNode;

        public Node(string name, Node rootNode)
        {
            this.name = name;
            this.rootNode = rootNode;
        }

        public Node(string name) 
        {
            this.name = name;
            this.rootNode = null;
        }
    }
    public class DisjointSet 
    {
        public List<Node> nodes;
        public Node rootNode;
        public List<DisjointSet> allDisjointSets;//Pool of disjoint sets

        public DisjointSet(){}

        public DisjointSet(List<Node> nodes, Node rootNode)
        {
            this.nodes = nodes;
            this.rootNode = rootNode;
        }

        public DisjointSet(List<Node> nodes)
        {
            this.nodes = nodes;
        }

        /*
         * Initially each node is a disjoint set on its own
         */
        public void InitialDS(List<Node> nodes)
        {
            foreach (var node in nodes) 
            {
                List<Node> newNode = new List<Node>();
                newNode.Add(node);
                DisjointSet disjointSet = new DisjointSet(newNode,node);//initially the nodes itself is a root node
                this.allDisjointSets.Add(disjointSet);//adding the disjoint set to the pool of disjoint sets
            }
        }

        /*
         * Merge two sets to form a new DisjointSet
         * params: ds1, ds2: DisjointSet objects
         */
        public DisjointSet Union(DisjointSet ds1, DisjointSet ds2) 
        {
            List<Node> newNodes = new List<Node>();
            foreach (var n1 in ds1.nodes)
            {
                newNodes.Add(n1);
            }
            foreach (var n2 in ds2.nodes)
            {
                newNodes.Add(n2);
            }
            foreach (var node in newNodes)//assigning a root node to each node
            {
                node.rootNode = newNodes.ElementAt(0);
            }
            DisjointSet unionDS = new DisjointSet(newNodes);
            this.allDisjointSets.Add(unionDS);//adding the disjoint set to the DisjointSet Pool
            return unionDS;
        }

        /*
         * Merge two nodes to form a new DisjointSet
         * params: n1, n2: Node objects
         */
        public DisjointSet Union(Node n1, Node n2)
        {
            List<Node> newNodes = new List<Node>();
            newNodes.Add(n1);
            newNodes.Add(n2);
            foreach (var node in newNodes)//assigning a root node to each node
            {
                node.rootNode = newNodes.ElementAt(0);
            }
            DisjointSet newDS = new DisjointSet(newNodes);
            this.allDisjointSets.Add(newDS);//adding the disjoint set to the DisjointSet Pool//NullReferenceObjectException
            return newDS;           
        }

        public DisjointSet IsIn(Node node) 
        {
            DisjointSet disjointSet = null;
            foreach (var ds in allDisjointSets) 
            {
                foreach (var n in ds.nodes)
                {
                    if (node == n) 
                    {
                        disjointSet = ds;
                    }
                }
            }
            return disjointSet;
        }
    }
    public class Graph 
    {
        public List<Node> nodes;
        public List<Edge> edges;

        public Graph(List<Node> nodes, List<Edge> edges) 
        {
            this.nodes = nodes;
            this.edges = edges;
        }
    }
    public class MinimumSpanningTree 
    {
        public List<Edge> mst;

        public void AddToMST(Edge edge) 
        {
            this.mst.Add(edge);
        }

        public void ShowMST() 
        {
            foreach (var edge in this.mst) 
            {
                Console.WriteLine("S     T");
                Console.WriteLine(edge.startNode+"  -  "+edge.targetNode);
            }
        }
    }
    public class Kruskal 
    {
        public void Algorithm(Graph graph) 
        {
            List<Node> nodes = graph.nodes;
            List<Edge> edges = graph.edges;
            DisjointSet initialDS = new DisjointSet();
            //initialDS.InitialDS(nodes);//initially each node is a disjoint set on its own
            List<Edge> mst = new List<Edge>();
            DisjointSet ds1,ds2;
            Edge.Sort(edges);//sorting the edges in the ascending order of their weights
            foreach (var edge in edges)
            {
                if (edge.startNode.rootNode != edge.targetNode.rootNode)
                {
                    mst.Add(edge);
                    ds1 = new DisjointSet();
                    DisjointSet startNodeDS = ds1.IsIn(edge.startNode);//retrieveing the disjoint set where the nodes belong
                    DisjointSet targetNodeDS = ds1.IsIn(edge.targetNode);
                    ds1.Union(startNodeDS,targetNodeDS);//Performing union operation the two disjoint set
                }
                if (edge.startNode.rootNode is null || edge.targetNode.rootNode is null)//when they are single node disjoint sets//newly instantiated nodes
                {
                    mst.Add(edge);
                    ds2 = new DisjointSet().Union(edge.startNode, edge.targetNode);
                }
            }
            Console.WriteLine("S - T");
            foreach (var edge in mst)
            {
                Console.WriteLine($"{edge.startNode.name} - {edge.targetNode.name}");
            }
        }
    }
}
//Data
//Kruskal.Node vertex1 = new Kruskal.Node("A");
//Kruskal.Node vertex2 = new Kruskal.Node("B");
//Kruskal.Node vertex3 = new Kruskal.Node("C");
//Kruskal.Node vertex4 = new Kruskal.Node("D");
//Kruskal.Node vertex5 = new Kruskal.Node("E");
//Kruskal.Node vertex6 = new Kruskal.Node("F");
//Kruskal.Node vertex7 = new Kruskal.Node("G");

//Kruskal.Edge edge1 = new Kruskal.Edge(2, vertex1, vertex2);
//Kruskal.Edge edge2 = new Kruskal.Edge(6, vertex1, vertex3);
//Kruskal.Edge edge3 = new Kruskal.Edge(5, vertex1, vertex5);
//Kruskal.Edge edge4 = new Kruskal.Edge(10, vertex1, vertex6);
//Kruskal.Edge edge5 = new Kruskal.Edge(3, vertex2, vertex4);
//Kruskal.Edge edge6 = new Kruskal.Edge(3, vertex2, vertex5);
//Kruskal.Edge edge7 = new Kruskal.Edge(1, vertex3, vertex4);
//Kruskal.Edge edge8 = new Kruskal.Edge(2, vertex3, vertex6);
//Kruskal.Edge edge9 = new Kruskal.Edge(4, vertex4, vertex5);
//Kruskal.Edge edge10 = new Kruskal.Edge(5, vertex4, vertex7);
//Kruskal.Edge edge11 = new Kruskal.Edge(5, vertex6, vertex7);

//List<Kruskal.Node> graphNodes = new List<Kruskal.Node>();
//graphNodes.Add(vertex1);
//graphNodes.Add(vertex2);
//graphNodes.Add(vertex3);
//graphNodes.Add(vertex4);
//graphNodes.Add(vertex5);
//graphNodes.Add(vertex6);
//graphNodes.Add(vertex7);

//List<Kruskal.Edge> graphEdges = new List<Kruskal.Edge>();
//graphEdges.Add(edge1);
//graphEdges.Add(edge2);
//graphEdges.Add(edge3);
//graphEdges.Add(edge4);
//graphEdges.Add(edge5);
//graphEdges.Add(edge6);
//graphEdges.Add(edge7);
//graphEdges.Add(edge8);
//graphEdges.Add(edge9);
//graphEdges.Add(edge10);
//graphEdges.Add(edge11);

//Kruskal.Graph graph = new Kruskal.Graph(graphNodes, graphEdges);

//Kruskal.Kruskal kruskal = new Kruskal.Kruskal();
//kruskal.Algorithm(graph);

//C - D - 1
//A - B - 2
//C - F - 2
//B - D - 3
//B - E - 3
//D - G - 5

/*
 * STEPS
 * Form indivisual disjoint sets from each node in the graph
 * Pick an edge from the graph and check if its start node and target node lie in the same disjoint set
 * If not then add the edge in the minimum spanning tree and add its two nodes in the same disjoint set
 */