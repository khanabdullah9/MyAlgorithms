using System;

namespace Trees
{
    internal class BreadthFirstSearch
    {
        public Queue<Node> visited;
        public Queue<Node> queue;
        public BinarySearchTree bst;

        public BreadthFirstSearch(BinarySearchTree bst) 
        {
            this.bst = bst;
            visited = new Queue<Node>();
            queue = new Queue<Node>();
            Console.WriteLine("Performing breadth first search....");
        }
        public void BFS() 
        {
            this.visited.Enqueue(bst.root);
            if (this.bst.root.left is not null) { this.queue.Enqueue(this.bst.root.left); }
            if (this.bst.root.right is not null) { this.queue.Enqueue(this.bst.root.right); }
            while (this.queue.Count!=0) 
            {
                Node node = this.queue.Dequeue();
                this.visited.Enqueue(node);
                if (node.left is not null) { this.queue.Enqueue(node.left); }
                if (node.right is not null) { this.queue.Enqueue(node.right); }
            }
        }
        public void PrintVisited()
        {
            List<Node> nodes = new List<Node>();
            while (this.visited.Count!=0) 
            {
                nodes.Add(this.visited.Dequeue());
            }
            foreach (var n in nodes) 
            {
                Console.Write(n.data+" ");
            }
        }
    }
}
