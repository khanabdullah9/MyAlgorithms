using System;
using System.Collections;
using Kruskal;

namespace Algorithms 
{
    public class Program 
    {
        public static void Main() 
        {
            Kruskal.Node n1 = new Kruskal.Node("A");
            Kruskal.Node n2 = new Kruskal.Node("B");
            Kruskal.Node n3 = new Kruskal.Node("C");
            Kruskal.Node n4 = new Kruskal.Node("D");
            Kruskal.Node n5 = new Kruskal.Node("E");
            Kruskal.Node n6 = new Kruskal.Node("F");
            Kruskal.Node n7 = new Kruskal.Node("G");

            Kruskal.Edge e1 = new Kruskal.Edge(2,n1,n2);
            Kruskal.Edge e2 = new Kruskal.Edge(6, n1, n3);
            Kruskal.Edge e3 = new Kruskal.Edge(5, n1, n5);
            Kruskal.Edge e4 = new Kruskal.Edge(10, n1, n6);
            Kruskal.Edge e5 = new Kruskal.Edge(3, n2, n4);
            Kruskal.Edge e6 = new Kruskal.Edge(3, n2, n5);
            Kruskal.Edge e7 = new Kruskal.Edge(1, n3, n4);
            Kruskal.Edge e8 = new Kruskal.Edge(2, n3, n6);
            Kruskal.Edge e9 = new Kruskal.Edge(4, n4, n5);
            Kruskal.Edge e10 = new Kruskal.Edge(5, n4, n7);
            Kruskal.Edge e11 = new Kruskal.Edge(5, n6, n7);

            List<Kruskal.Node> nodes = new List<Kruskal.Node>();
            nodes.Add(n1);
            nodes.Add(n2);
            nodes.Add(n3);
            nodes.Add(n4);
            nodes.Add(n5);
            nodes.Add(n6);
            nodes.Add(n7);

            List<Kruskal.Edge> edges = new List<Kruskal.Edge>();
            edges.Add(e1);
            edges.Add(e2);
            edges.Add(e3);
            edges.Add(e4);
            edges.Add(e5);
            edges.Add(e6);
            edges.Add(e7);
            edges.Add(e8);
            edges.Add(e9);
            edges.Add(e10);
            edges.Add(e11);

            Kruskal.Graph graph = new Kruskal.Graph(nodes,edges);

            Kruskal.Kruskal kruskal = new Kruskal.Kruskal();
            kruskal.Algorithm(graph);
        }
    }
}