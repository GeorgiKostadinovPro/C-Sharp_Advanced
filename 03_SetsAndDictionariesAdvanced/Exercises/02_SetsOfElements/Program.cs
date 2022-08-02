using System;
using System.Collections.Generic;

namespace _02_SetsOfElements
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();

            for (int i = 0; i < n + m; i++)
            {
                int el = int.Parse(Console.ReadLine());

                if (i < n)
                {
                    first.Add(el);
                }
                else
                {
                    second.Add(el);
                }
            }

            first.IntersectWith(second);

            Console.WriteLine(string.Join(" ", first));
        }
    }
}