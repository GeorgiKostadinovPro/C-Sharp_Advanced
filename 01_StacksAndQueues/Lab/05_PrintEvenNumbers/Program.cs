using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_PrintEvenNumbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbersInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbers = new Queue<int>(numbersInput);

            Console.WriteLine(string.Join(", ", numbers.Where(x => x % 2 == 0)));
        }
    }
}
