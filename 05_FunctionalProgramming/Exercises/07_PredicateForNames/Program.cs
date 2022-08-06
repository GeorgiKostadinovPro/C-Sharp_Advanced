using System;
using System.Linq;

namespace _07_PredicatesForNames
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

            Predicate<string> check = (x) => x.Length <= length;

            Action<string[]> print = (x) =>
            {
                foreach (var item in x)
                {
                    Console.WriteLine(item);
                }
            };

            names = names.Where(x => check(x)).ToArray();

            print(names);
        }
    }
}
