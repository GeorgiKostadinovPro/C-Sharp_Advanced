using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_MaximumAndMinimumElement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string[] query = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmd = query[0];

                switch (cmd)
                {
                    case "1":
                        stack.Push(int.Parse(query[1]));
                        break;
                    case "2":
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;
                    case "3":
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;
                    case "4":
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                    default:
                        break;
                }

            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
