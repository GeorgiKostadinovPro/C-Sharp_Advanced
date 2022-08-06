using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_KnightsOfhonor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> print = (x) => Console.WriteLine($"Sir {x}");

            names.ForEach(print);
        }
    }
}
