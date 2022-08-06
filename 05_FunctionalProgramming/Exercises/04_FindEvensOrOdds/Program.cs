using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_FindEvenOrOdds
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string cmd = Console.ReadLine();

            Predicate<int> isEven = x => x % 2 == 0;

            Func<int[], string, List<int>> func = (x, y) =>
            {
                var result = new List<int>();

                for (int i = x[0]; i <= x[x.Length - 1]; i++)
                {
                    result.Add(i);
                }

                if (cmd == "even")
                {
                    result = result.Where(x => isEven(x)).ToList();
                }
                else
                {
                    result = result.Where(x => !isEven(x)).ToList();
                }

                return result;
            };

            Console.WriteLine(string.Join(" ", func(bounds, cmd)));
        }
    }
}
