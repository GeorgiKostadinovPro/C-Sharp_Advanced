using System;
using System.Linq;

namespace _03_CustomMinFunction
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> min = (x) =>
            {
                int min = int.MaxValue;

                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] < min)
                    {
                        min = x[i];
                    }
                }

                return min;
            };

            Console.WriteLine(min(numbers));
        }
    }
}
