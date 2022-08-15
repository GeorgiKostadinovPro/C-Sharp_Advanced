using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Scheduling
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> tasksInput = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> threadsInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int value = int.Parse(Console.ReadLine());

            Stack<int> tasks = new Stack<int>(tasksInput);

            Queue<int> threads = new Queue<int>(threadsInput);

            while (tasks.Peek() != value)
            {
                int task = tasks.Peek();
                int thread = threads.Peek();

                if (thread >= task)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {threads.Peek()} killed task {value}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
