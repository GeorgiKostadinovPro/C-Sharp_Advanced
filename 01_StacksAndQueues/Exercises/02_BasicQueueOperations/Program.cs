using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_BasicQueueOperations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] data = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int numberOfElementsToPush = data[0];
            int numberOfElementsToPop = data[1];
            int toSearch = data[2];

            Queue<int> queue = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

            while (numberOfElementsToPop > 0 && queue.Count > 0)
            {
                queue.Dequeue();
                numberOfElementsToPop--;
            }

            if (queue.Contains(toSearch))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Any())
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
    
}
