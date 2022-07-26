using System;

namespace Trees 
{
    internal class Node 
    {
        public int data;
        public Node left;//child
        public Node right;//child
        public Node parent;

        public Node(int data, Node parent=null)
        {
            this.data = data;
            this.parent = parent;
            this.left = null;
            this.right = null;
        }
    }
    internal class BinarySearchTree 
    {
        public Node root;
        public BinarySearchTree(Node root)
        {
            this.root = root;
        }
        public void Insert(int data) 
        {
            if (this.root is null)//BST is empty
            {
                Node newNode = new Node(data);
                this.root = newNode;
            }
            else 
            {
                InsertNode(this.root, data);
            }
        }
        public void InsertNode(Node node, int data) 
        {
            if (data < node.data)
            {
                if (node.left is not null)//data must go to the left subtree
                {
                    InsertNode(node.left, data);//calling the function recursively untill we find empty space
                }
                else if (node.left is null)
                {
                    Node newNode = new Node(data);
                    newNode.parent = node;
                    node.left = newNode;
                }
            }
            else if (data > node.data)//data must go to the right subtree
            {
                if (node.right is not null)
                {
                    InsertNode(node.right, data);//calling the function recursively untill we find empty space
                }
                else if (node.right is null)
                {
                    Node newNode = new Node(data);
                    newNode.parent = node;
                    node.right = newNode;
                }
            }
        }
        public void Traverse() 
        {
            if (this.root is not null)
            {
                Console.WriteLine("Inorder traversal....");
                InOrder(this.root);
            }
        }
        public void InOrder(Node node) 
        {
            if (node.left is not null)
            {
                InOrder(node.left);
            }
            Console.WriteLine(node.data);
            if (node.right is not null)
            {
                InOrder(node.right);
            }
        }
        public int GetMax() 
        {
            if (this.root is null) 
            {
                return 0;
            }
            var max = RightMost(this.root);
            return max;
        }
        public int RightMost(Node node) 
        {
            Node actual = node;
            while (actual.right is not null)
            {
                actual = actual.right;
            }
            return actual.data;
        }
        public int GetMin() 
        {
            if (this.root is null)
            {
                return 0;
            }
            var min = LeftMost(this.root);
            return min;
        }
        public int LeftMost(Node node) 
        {
            Node actual = node;
            while (actual.left is not null) 
            {
                actual = actual.left;
            }
            return actual.data;
        }

        /*
         * Remove a node from the BST
         * params: node: Node where the Method stands now
         * data: data we want to remove
         */
        public void Remove(Node node, int data)
        {
            if (data < node.data)
            {
                Remove(node.left, data);
            }
            else if (data > node.data)
            {
                Remove(node.right, data);
            }
            else if (data == this.root.data) //data belongs to the root node
            {
                Console.WriteLine($"Removing root node....");
                Node predecessor = GetPredecessor();
                //swapping root node with predecessor
                Node temp = this.root;
                this.root = predecessor;
                predecessor = temp;
                //predecessor = null;
            }
            else if (data == node.data)//node has been found
            {
                if (node.left is null && node.right is null)//leaf node
                {
                    Console.WriteLine($"Removing a leaf node....");
                    Node parent = node.parent;//parent of the current node
                    if (parent is not null && parent.left == node) //setting the node's parent node's child node to null
                    {
                        parent.left = null;
                    }
                    else if (parent is not null && parent.right == node)
                    {
                        parent.right = null;
                    }
                }
                else if (node.left is not null && node.right is null)//node with left node only               
                {
                    Console.WriteLine($"Removing with only left node....");
                    Node parent = node.parent;//parent of the current node
                    node.left.parent = parent;
                    if (parent is not null && parent.left == node) //setting the node's parent node's child node to null
                    {
                        parent.left = null;
                    }
                    if (parent is not null && parent.right == node)
                    {
                        parent.right = null;
                    }
                }
                else if (node.left is null && node.right is not null)//node with right node only
                {
                    Console.WriteLine($"Removing with only right node....");
                    Node parent = node.parent;
                    node.right.parent = parent;
                    if (parent is not null)
                    {
                        if (parent.left == node)
                        {
                            parent.left = null;
                        }
                        else if (parent.right == node)
                        {
                            parent.right = null;
                        }
                    }
                }
                else if (node.left is not null && node.right is not null)//node with both children
                {
                    Console.WriteLine($"Removing with both nodes....");
                    Node parent = node.parent;
                    Console.WriteLine($"{node.left.data} and {node.right.data}");
                    node.right.parent = parent;
                    node.left.parent = parent;
                    if (parent is not null)
                    {
                        if (parent.left == node)
                        {
                            parent.left = null;
                        }
                        else if (parent.right == node)
                        {
                            parent.right = null;
                        }
                    }
                }
            }
        }

        /*
         * Return the right most node in the left sub tree
         */
        public Node GetPredecessor() 
        {
            Node start = this.root;
            while (start.left is not null) 
            {
                start = start.left;
            }
            Node actual = start.parent;
            while (actual.right is not null)
            {
                actual = actual.right;
            }
            return actual;
        }
    }
}
/*Conditions for removing a node
1) If the node is a leaf node simply remove the node
2) If the node has children:
    2a) If the node has one right child:
        then point the right child to its grand parent node
    2b) If the node has one left child:
        then point the left child to its grand parent node
    2c) If the node has both children:
        then point those children to their grand parent node
3) If the node is the root node:
    3a) Swap it with the predecessor (right most node in the left subtree)
    3b) Swap it with the successor (left most node in the right subtree)
 */