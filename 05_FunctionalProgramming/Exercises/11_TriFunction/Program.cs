using System;
using System.Linq;

namespace _11_TriFunction
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .ToArray();

            Func<string, int, bool> baseLogic = (x, y) =>
            {
                int sum = 0;

                for (int i = 0; i < x.Length; i++)
                {
                    sum += (int)x[i];
                }

                if (sum >= y)
                {
                    return true;
                }

                return false;
            };

            names = names.Where(x => baseLogic(x, n)).ToArray();

            Console.WriteLine(names.FirstOrDefault());
        }
    }
}