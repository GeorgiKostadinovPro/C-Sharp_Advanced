using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_BakeryShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(
                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray());

            Stack<double> flour = new Stack<double>(
               Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(double.Parse).ToArray());

            Dictionary<string, int> bakeryThings = new Dictionary<string, int>()
            {
                { "Croissant", 0},
                { "Muffin", 0},
                { "Baguette", 0},
                { "Bagel", 0},
            };


            while (water.Count > 0 && flour.Count > 0)
            {
                double currWater = water.Peek();
                double currFlour = flour.Peek();

                double mix = currWater + currFlour;

                double waterPercentage = (currWater * 100) / mix;
                double flourPercentage = (currFlour * 100) / mix;

                if (waterPercentage == 50 || waterPercentage == 40 || waterPercentage == 30 || waterPercentage == 20)
                {
                    if (waterPercentage == 50 && flourPercentage == 50)
                    {
                        bakeryThings["Croissant"]++;
                    }
                    else if (waterPercentage == 40 && flourPercentage == 60)
                    {
                        bakeryThings["Muffin"]++;
                    }
                    else if (waterPercentage == 30 && flourPercentage == 70)
                    {
                        bakeryThings["Baguette"]++;
                    }
                    else if (waterPercentage == 20 && flourPercentage == 80)
                    {
                        bakeryThings["Bagel"]++;
                    }

                    water.Dequeue();
                    flour.Pop();
                }
                else
                {
                    double neededRation = currWater * 2;
                    currFlour -= currWater;

                    water.Dequeue();
                    flour.Pop();
                    flour.Push(currFlour);
                    bakeryThings["Croissant"]++;
                }
            }

            foreach (var thing in bakeryThings.Where(b => b.Value > 0).OrderByDescending(b => b.Value).ThenBy(b => b.Key))
            {
                Console.WriteLine($"{thing.Key}: {thing.Value}");
            }

            string waterLeft = water.Count > 0 ? string.Join(", ", water) : "None";
            string flourLeft = flour.Count > 0 ? string.Join(", ", flour) : "None";

            Console.WriteLine($"Water left: {waterLeft}");
            Console.WriteLine($"Flour left: {flourLeft}");
        }
    }
}
