using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_CupsAndBottles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bottlesWithWater = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> cups = new Queue<int>(cupsCapacity); 
            Stack<int> bottles = new Stack<int>(bottlesWithWater);

            int wastedWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int bottle = bottles.Pop();
                int cup = cups.Peek();

                if (bottle >= cup)
                {
                    cup -= bottle;
                    wastedWater += Math.Abs(cup);
                }
                else
                {
                    cup -= bottle;

                    while (cup > 0)
                    {
                        cup -= bottles.Pop();

                        if (cup > 0)
                        {
                            continue;
                        }

                        wastedWater += Math.Abs(cup);
                    }
                }

                if (cup <= 0)
                {
                    cups.Dequeue();
                }
            }

            string cupsOrBottlesResult = cups.Count > 0 
                ? $"Cups: {string.Join(" ", cups)}" 
                : $"Bottles: {string.Join(" ", bottles)}";

            Console.WriteLine(cupsOrBottlesResult);
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}