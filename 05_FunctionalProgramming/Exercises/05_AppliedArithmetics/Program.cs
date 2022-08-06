using System;
using System.Linq;

namespace _05_AppliedArithmetics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            string line = string.Empty;

            Func<int, int> add = (x) => x + 1;
            Func<int, int> multiply = (x) => x * 2;
            Func<int, int> subtract = (x) => x - 1;

            Action<int[]> print = (x) => Console.WriteLine(string.Join(" ", x));

            while ((line = Console.ReadLine()) != "end")
            {
                if (line == "add")
                {
                    numbers = numbers.Select(add).ToArray();
                }
                else if (line == "multiply")
                {
                    numbers = numbers.Select(multiply).ToArray();
                }
                else if (line == "subtract")
                {
                    numbers = numbers.Select(subtract).ToArray();
                }
                else if (line == "print")
                {
                    print(numbers);
                }
            }
        }
    }
}
