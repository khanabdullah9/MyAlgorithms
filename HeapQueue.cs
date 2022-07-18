using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class HeapQueue
    {
        public static void HQ()
        {
            PriorityQueue<string, int> q = new PriorityQueue<string, int>();
            q.Enqueue("Abdullah",1);
            q.Enqueue("Khan",2);
            Console.WriteLine(q.Dequeue());
        }
    }
}
