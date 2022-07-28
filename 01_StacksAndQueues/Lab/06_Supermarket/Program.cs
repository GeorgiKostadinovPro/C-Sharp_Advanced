using System;
using System.Collections.Generic;

namespace _06_Supermarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string line = string.Empty;

            Queue<string> customers = new Queue<string>();

            while ((line = Console.ReadLine()) != "End")
            {
                string input = line;

                if (input == "Paid")
                {
                    while (customers.Count > 0)
                    {
                        string customer = customers.Dequeue();
                        Console.WriteLine(customer);
                    }
                }
                else 
                {
                    customers.Enqueue(input);
                }
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
