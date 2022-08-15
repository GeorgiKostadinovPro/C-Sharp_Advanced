using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Masterchef
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, string> dishes = new Dictionary<int, string>()
            {
                { 150, "Dipping sauce"  },
                { 250, "Green salad" },
                { 300, "Chocolate cake" },
                { 400, "Lobster" },
            };

            Dictionary<string, int> dishesCount = new Dictionary<string, int>()
            {
                { "Dipping sauce", 0 },
                { "Green salad", 0},
                { "Chocolate cake", 0},
                { "Lobster", 0},
            };

            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            Stack<int> freshnessLevels = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

            while (ingredients.Count > 0 && freshnessLevels.Count > 0)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                int multiplication = ingredients.Peek() * freshnessLevels.Peek();

                if (dishes.ContainsKey(multiplication))
                {
                    string value = dishes[multiplication];
                    dishesCount[value]++;
                    ingredients.Dequeue();
                    freshnessLevels.Pop();
                }
                else
                {
                    freshnessLevels.Pop();
                    int currIngredient = ingredients.Dequeue();
                    ingredients.Enqueue(currIngredient + 5);
                }
            }

            if (dishesCount["Dipping sauce"] > 0 && dishesCount["Green salad"] > 0
                && dishesCount["Chocolate cake"] > 0 && dishesCount["Lobster"] > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var dish in dishesCount.Where(d => d.Value > 0).OrderBy(d => d.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}
