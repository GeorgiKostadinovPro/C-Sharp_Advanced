using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_BirthdayCelebration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> guestsEatingCapacities = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> plates = new Stack<int>(Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray());

            int wastedFood = 0;

            while (plates.Count > 0 && guestsEatingCapacities.Count > 0)
            {
                int guest = guestsEatingCapacities.Peek();
                int plate = plates.Pop();

                int reduced = guest - plate;

                if (reduced <= 0)
                {
                    wastedFood += Math.Abs(reduced);
                    guestsEatingCapacities.Dequeue();
                }
                else if (reduced > 0)
                {
                    guest -= plate;
                    int[] items = guestsEatingCapacities.Skip(1).ToArray();
                    guestsEatingCapacities.Clear();
                    guestsEatingCapacities.Enqueue(guest);

                    foreach (var item in items)
                    {
                        guestsEatingCapacities.Enqueue(item);
                    }
                }
            }

            if (guestsEatingCapacities.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            else if (plates.Count == 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guestsEatingCapacities)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
