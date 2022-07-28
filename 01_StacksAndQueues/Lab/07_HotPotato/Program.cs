using System;
using System.Collections.Generic;

namespace _07_HotPotato
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] kidsInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(Console.ReadLine());

            Queue<string> kids = new Queue<string>(kidsInput);

            while (kids.Count > 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    string kid = kids.Dequeue();
                    kids.Enqueue(kid);
                }

                string loser = kids.Dequeue();
                Console.WriteLine($"Removed {loser}");
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
