using System;
using System.Collections.Generic;
using ClassLibrary;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var en = Algorithms.GetFibonacciNumbers(10);

            foreach (var n in en)
            {
                Console.WriteLine(n);
            }

            var set = new Set<string>
            {
                "1",
                "2"
            };

            var stack = new ClassLibrary.Stack<int>();
            stack.Push(1);
            stack.Push(2);

            var queue = new ClassLibrary.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            WriteToConsole(set);
            WriteToConsole(stack);
            WriteToConsole(queue);
        }

        private static void WriteToConsole<T>(IEnumerable<T> en)
        {
            Console.WriteLine($"{en.GetType().Name}:");

            foreach (var item in en)
            {
                Console.WriteLine(item);
            }
        } 
    }
}
