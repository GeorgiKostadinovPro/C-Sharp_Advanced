using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_BasicStackOperations
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

            Stack<int> stack = new Stack<int>(
                Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

            while (numberOfElementsToPop > 0 && stack.Count > 0)
            {
                stack.Pop();
                numberOfElementsToPop--;
            }

            if (stack.Contains(toSearch))
            {
                Console.WriteLine("true");
            }
            else 
            {
                if (stack.Any())
                {
                    Console.WriteLine(stack.Min());
                }
                else 
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
