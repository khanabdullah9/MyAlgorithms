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

        public DisjointSet() 
        {
            
        }

        public DisjointSet(List<Node> nodes, Node rootNode)
        {
            this.nodes = nodes;
            this.rootNode = rootNode;
        }

        /*
         * Initially each node is a disjoint set on its own
         */
        public List<DisjointSet> InitialDS()
        {
            DisjointSet disjointSet;
            List<DisjointSet> lstDS = new List<DisjointSet>();
            foreach (var node in this.nodes) 
            {
                List<Node> newNode = new List<Node>();
                newNode.Add(node);
                disjointSet = new DisjointSet(newNode,node);
                lstDS.Add(disjointSet);
            }
            return lstDS;
        }

        /*
         * Merge two sets
         */
        public static DisjointSet Union(DisjointSet ds1, DisjointSet ds2) 
        {
            List<Node> newNodes = new List<Node>();
            foreach (var n1 in ds1.nodes) //NullReferenceException
            {
                newNodes.Add(n1);
            }
            foreach (var n2 in ds2.nodes)
            {
                newNodes.Add(n2);
            }
            DisjointSet unionDS = new DisjointSet(newNodes,newNodes.ElementAt(0));
            return unionDS;
        }

        public static bool IsIn(DisjointSet ds, Node node)
        {
            bool op = false;
            foreach (var n in ds.nodes)
            {
                if (n==node) 
                {
                    op = true;
                }
            }
            return op;
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
            MinimumSpanningTree mst = new MinimumSpanningTree();
            DisjointSet ds1,ds2;
            ds1 = new DisjointSet(nodes, nodes[0]);//Making indivisual disjoint sets
            List<DisjointSet> AllDisjointSets = ds1.InitialDS();

            //Use the IsIn() boolean method
            foreach (var ds in AllDisjointSets)
            {
                foreach (var e in edges) 
                {
                    if (!(DisjointSet.IsIn(ds, e.startNode) && DisjointSet.IsIn(ds, e.targetNode)))
                    {
                        /*THEY WILL NOT FORM A CYCLE IN THE MST*/
                        var dsStartNode = AllDisjointSets.Where(ds => ds.nodes.Count == 1 && ds.nodes.Contains(e.startNode)).Select(ds => ds).FirstOrDefault();
                        var dsTargetNode = AllDisjointSets.Where(ds => ds.nodes.Count == 1 && ds.nodes.Contains(e.targetNode)).Select(ds => ds).FirstOrDefault();

                        DisjointSet newDS = DisjointSet.Union(dsStartNode, dsTargetNode);
                        AllDisjointSets.Add(newDS);
                        List<Edge> mst2 = new List<Edge>();
                        mst2.Add(e);
                        AllDisjointSets.Remove(dsStartNode);
                        AllDisjointSets.Remove(dsTargetNode);

                        //mst.ShowMST();
                        foreach (var e2 in mst2) 
                        {
                            Console.WriteLine("S     T");
                            Console.WriteLine(e2.startNode + "  -  " + e2.targetNode);
                        }
                    }
                }
            }
        }
    }
}