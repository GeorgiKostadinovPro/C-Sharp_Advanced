using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_EvenTimes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> evenTimes = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!evenTimes.ContainsKey(num))
                {
                    evenTimes.Add(num, 0);
                }

                evenTimes[num]++;
            }

            var result = evenTimes.Where(kvp => kvp.Value % 2 == 0).FirstOrDefault();

            Console.WriteLine(result.Key);

        }
    }
}
