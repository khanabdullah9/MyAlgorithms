using System;

namespace Algorithms 
{
    public class Program 
    {
        public static void Main() 
        {
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);
            Node n5 = new Node(5);

            LinkedList linkedList = new LinkedList();
            linkedList.InsertNode(n1);
            linkedList.InsertNode(n2);
            linkedList.InsertNode(n3);
            linkedList.InsertNode(n4);
            linkedList.InsertNode(n5);

            linkedList.Traverse();
        }
    }
}