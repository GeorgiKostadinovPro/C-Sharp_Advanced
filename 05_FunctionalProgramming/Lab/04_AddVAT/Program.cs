using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_AddVAT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Func<string, double> parser = (el) => double.Parse(el);
            Func<double, double> VAT = (el) => el + el * 0.2;

            List<double> prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .Select(VAT)
                .ToList();

            prices.ForEach(price => Console.WriteLine($"{price:f2}"));
        }
    }
}
