using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_ListOfPredicates
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[] dividers = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(double.Parse)
               .ToArray();

            double[] nums = new double[n];

            int indx = 0;

            for (double i = 1; i <= n; i++)
            {
                nums[indx++] = i;
            }

            Func<double[], double[], HashSet<double>> filter = (x, y) =>
            {
                var result = new HashSet<double>();

                for (int i = 0; i < x.Length; i++)
                {
                    bool divisible = true;

                    for (int j = 0; j < y.Length; j++)
                    {
                        if (x[i] % y[j] != 0)
                        {
                            divisible = false;
                            break;
                        }
                    }

                    if (divisible == true)
                    {
                        result.Add(x[i]);
                    }
                }

                return result;
            };


            Console.WriteLine(string.Join(" ", filter(nums, dividers)));
        }
    }
}
