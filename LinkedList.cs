using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Node 
    {
        public int data;
        public Node next;
        public Node(int data) 
        {
            this.data = data;
        }
    }
    internal class LinkedList
    {
        public Node head;
        public LinkedList() 
        {
            this.head = null;
        }

        public void InsertNode(Node node)
        {
            Node new_node = node;
            if (this.head is null)
            {
                this.head = new_node;
            }
            else 
            {
                new_node.next = this.head;
                this.head = new_node;
                
            }
        }

        public void Traverse() 
        {
            if (this.head is not null)
            {
                Node current_node = this.head;
                Console.WriteLine(current_node.data);
                while (current_node.next is not null) 
                {
                    current_node = current_node.next;
                    Console.WriteLine(current_node.data);
                }
            }
        }
    }
}
