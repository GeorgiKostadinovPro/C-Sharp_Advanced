using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_FastFood
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine()); 

            Queue<int> orderQuantity = new Queue<int>(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray());

            int tempSum = 0;

            Console.WriteLine(orderQuantity.Max());

            while (orderQuantity.Count > 0)
            {
                int order = orderQuantity.Peek();
                tempSum += order;
                if (tempSum <= foodQuantity)
                {
                    orderQuantity.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orderQuantity)}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
