using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_PeriodicTable
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> table = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < elements.Length; j++)
                {
                    table.Add(elements[j]);
                }
            }

            Console.WriteLine(string.Join(" ", table.OrderBy(e => e)));
        }
    }
}
