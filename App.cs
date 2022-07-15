using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class App
    {
        public static void Debugger(string type, string description, string class_name, string method, string message)
        {
            switch (type.ToLower())
            {
                case "success":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[{description}] ({class_name}.{method}) : {message}");
                    break;
                case "warning":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"[{description}] ({class_name}.{method}) : {message}");
                    break;
                case "exception":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[{description}] ({class_name}.{method}) : {message}");
                    break;
                case "test":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"[{description}] ({class_name}.{method}) : {message}");
                    break;
                default:
                    Console.WriteLine($"[{description}] ({class_name}.{method}) : {message}");
                    break;
            }
        }
        public static void PrintArray(int[] container)
        {
            foreach (int num in container)
            {
                Console.Write(num + " ");
            }
        }
        public static void Swap(int[] container, int idx1, int idx2)
        {
            int temp = container[idx1];
            container[idx1] = container[idx2];
            container[idx2] = temp;
        }
    }
}
