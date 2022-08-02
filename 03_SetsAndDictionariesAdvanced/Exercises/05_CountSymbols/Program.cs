using System;
using System.Collections.Generic;

namespace _05_CountSymbols
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> counter = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!counter.ContainsKey(text[i]))
                {
                    counter.Add(text[i], 0);
                }

                counter[text[i]]++;
            }

            foreach (var ch in counter)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}
