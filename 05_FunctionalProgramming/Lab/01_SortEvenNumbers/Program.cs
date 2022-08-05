using System;
using System.Linq;

namespace _01_SortEvenNumbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[]> func = () => numbers
                             .Where(x => x % 2 == 0)
                             .OrderBy(x => x)
                             .ToArray();

            Console.WriteLine(string.Join(", ", func()));
        }
    }
}
