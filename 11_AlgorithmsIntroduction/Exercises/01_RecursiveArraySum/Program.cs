using System;
using System.Linq;

namespace _01_RecursiveArraySum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int sum = SumArrayNumbers(numbers, 0);

            Console.WriteLine(sum);
        }

        private static int SumArrayNumbers(int[] numbers, int index)
        {
            if (index == numbers.Length)
            {
                return 0;
            }

            return numbers[index] + SumArrayNumbers(numbers, index + 1);
        }
    }
}