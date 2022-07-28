using System;

namespace Trees
{
    internal class DepthFirstSearch
    {
        public Stack<Node> visited;//stores visited nodes
        public Stack<Node> stack;//stores unvisited node's adjacent nodes
        public BinarySearchTree bst;
        public DepthFirstSearch(BinarySearchTree bst) 
        {
            this.bst = bst;
            visited = new Stack<Node>();
            stack = new Stack<Node>();
            Console.WriteLine("Performing depth first search");
        }
        public void DFS() 
        {
            this.visited.Push(this.bst.root);
            if (bst.root.left is not null) { this.stack.Push(this.bst.root.left); }
            if (bst.root.right is not null) { this.stack.Push(this.bst.root.right); }

            while (this.stack.Count != 0)
            {
                Node newNode = stack.Pop();
                this.visited.Push(newNode);
                if (newNode.left is not null) { stack.Push(newNode.left); }
                if (newNode.right is not null) { stack.Push(newNode.right); }
            }

        }

        public void PrintVisited() 
        {
            List<Node> nodes = new List<Node>();
            while (this.visited.Count!=0) 
            {
                nodes.Add(this.visited.Pop()); 
            }
            foreach (var node in nodes) 
            {
                Console.Write($"{node.data} ");
            }
        }
    }
}
