using System;
using System.Collections;
using Kruskal;

namespace Algorithms 
{
    public class Program 
    {
        public static void Main() 
        {
            Kruskal.Node vertex1 = new Kruskal.Node("A", null);
            Kruskal.Node vertex2 = new Kruskal.Node("B", null);
            Kruskal.Node vertex3 = new Kruskal.Node("C", null);
            Kruskal.Node vertex4 = new Kruskal.Node("D", null);
            Kruskal.Node vertex5 = new Kruskal.Node("E", null);
            Kruskal.Node vertex6= new Kruskal.Node("F",  null);
            Kruskal.Node vertex7 = new Kruskal.Node("G", null);

            Kruskal.Edge edge1 = new Kruskal.Edge(2, vertex1, vertex2);
            Kruskal.Edge edge2 = new Kruskal.Edge(6, vertex1, vertex3);
            Kruskal.Edge edge3 = new Kruskal.Edge(5, vertex1, vertex5);
            Kruskal.Edge edge4 = new Kruskal.Edge(10, vertex1, vertex6);
            Kruskal.Edge edge5 = new Kruskal.Edge(3, vertex2, vertex4);
            Kruskal.Edge edge6 = new Kruskal.Edge(3, vertex2, vertex5);
            Kruskal.Edge edge7 = new Kruskal.Edge(1, vertex3, vertex4);
            Kruskal.Edge edge8 = new Kruskal.Edge(2, vertex3, vertex6);
            Kruskal.Edge edge9 = new Kruskal.Edge(4, vertex4, vertex5);
            Kruskal.Edge edge10 = new Kruskal.Edge(5, vertex4, vertex7);
            Kruskal.Edge edge11 = new Kruskal.Edge(5, vertex6, vertex7);

            List<Kruskal.Node> graphNodes = new List<Kruskal.Node>();
            graphNodes.Add(vertex1);
            graphNodes.Add(vertex2);
            graphNodes.Add(vertex3);
            graphNodes.Add(vertex4);
            graphNodes.Add(vertex5);
            graphNodes.Add(vertex6);
            graphNodes.Add(vertex7);

            List<Kruskal.Edge> graphEdges = new List<Kruskal.Edge>();
            graphEdges.Add(edge1);
            graphEdges.Add(edge2);
            graphEdges.Add(edge3);
            graphEdges.Add(edge4);
            graphEdges.Add(edge5);
            graphEdges.Add(edge6);
            graphEdges.Add(edge7);
            graphEdges.Add(edge8);
            graphEdges.Add(edge9);
            graphEdges.Add(edge10);
            graphEdges.Add(edge11);

            Kruskal.Graph graph = new Kruskal.Graph(graphNodes, graphEdges);

            Kruskal.Kruskal kruskal = new Kruskal.Kruskal();
            kruskal.Algorithm(graph);
        }
    }
}