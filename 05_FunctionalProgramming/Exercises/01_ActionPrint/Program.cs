using System;

namespace _01_ActionPoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> print = (x) => Console.WriteLine(string.Join("\n", x));
            print(names);
        }
    }
}
