using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Cooking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray());

            Dictionary<string, int> food = new Dictionary<string, int>()
            {
                { "Bread", 0 },
                { "Cake", 0 },
                { "Pastry", 0 },
                { "Fruit Pie", 0 },
            };

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int liquid = liquids.Peek();
                int ingredient = ingredients.Peek();

                int sum = liquid + ingredient;

                if (sum == 25 || sum == 50 || sum == 75 || sum == 100)
                {
                    if (sum == 25)
                    {
                        food["Bread"]++;
                    }
                    else if (sum == 50)
                    {
                        food["Cake"]++;
                    }
                    else if (sum == 75)
                    {
                        food["Pastry"]++;
                    }
                    else
                    {
                        food["Fruit Pie"]++;
                    }

                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    ingredient += 3;
                    ingredients.Pop();
                    ingredients.Push(ingredient);
                }
            }

            if (food["Bread"] >= 1 && food["Cake"] >= 1 && food["Pastry"] >= 1 && food["Fruit Pie"] >= 1)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            string liquidsResult = liquids.Count > 0 ? string.Join(", ", liquids) : "none";
            string ingredientsResult = ingredients.Count > 0 ? string.Join(", ", ingredients) : "none";

            Console.WriteLine($"Liquids left: {liquidsResult}");
            Console.WriteLine($"Ingredients left: {ingredientsResult}");

            foreach (var f in food.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{f.Key}: {f.Value}");
            }
        }
    }
}
