using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_CountSameValuesInArray
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<double, int> numbersCount = new Dictionary<double, int>();

            double[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                double number = numbers[i];

                if (!numbersCount.ContainsKey(number))
                {
                    numbersCount.Add(number, 0);
                }

                numbersCount[number]++;
            }

            foreach (var numberCount in numbersCount)
            {
                Console.WriteLine($"{numberCount.Key} - {numberCount.Value} times");
            }
        }
    }
}
