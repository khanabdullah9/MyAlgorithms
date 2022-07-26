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
            bst.Insert(1);
            bst.Insert(3);
            bst.Insert(7);
            bst.Traverse();
            Console.WriteLine($"Largest data = {bst.GetMax()}");
            Console.WriteLine($"Smallest data = {bst.GetMin()}");
            bst.Remove(root,2);
            bst.Traverse();
        }
    }
}