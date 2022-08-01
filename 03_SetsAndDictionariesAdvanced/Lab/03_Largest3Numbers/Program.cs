using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Largest3Numbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            numbers = numbers.OrderByDescending(x => x).ToArray();

            numbers = numbers.Length > 2 ? numbers.Take(3).ToArray() : numbers;

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
