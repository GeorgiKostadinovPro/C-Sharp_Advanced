using System;
using System.Linq;

namespace _06_ReverseAndExclude
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int n = int.Parse(Console.ReadLine());

            Action<int[]> reverse = (x) => Array.Reverse(x);

            reverse(numbers);

            Predicate<int> filter = (x) => x % n == 0;

            numbers = numbers.Where(x => !filter(x)).ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
