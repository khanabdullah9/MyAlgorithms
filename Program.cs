using System;
using System.Collections;
using Kruskal;
using Sorting;
using Trees;

namespace Algorithms 
{
    public class Program 
    {
        public static void Main() 
        {
            Trees.Node root = new Trees.Node(4);
            BinarySearchTree bst = new BinarySearchTree(root);
            bst.Insert(2);
            bst.Insert(7);
            bst.Insert(1);
            bst.Insert(3);
            List<int> rv = bst.RightSideView(root);
            foreach (var n1 in rv)
            {
                Console.Write(n1+" ");
            }
            Console.WriteLine();   
            List<int> lv = bst.LeftSideView(root);
            foreach (var n2 in lv)
            {
                Console.Write(n2 + " ");
            }
        }
    }
}