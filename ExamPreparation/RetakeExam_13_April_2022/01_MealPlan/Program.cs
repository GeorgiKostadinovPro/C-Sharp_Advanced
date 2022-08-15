using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_MealPlan
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> mealsTable = new Dictionary<string, int>()
            {
                { "salad", 350 },
                { "soup", 490 },
                { "pasta", 680 },
                { "steak", 790 },
            };

            Queue<string> meals = new Queue<string>(
                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

            Stack<int> caloriesIntakePerDay = new Stack<int>(
                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            int mealsCounter = 0;

            while (meals.Count > 0 && caloriesIntakePerDay.Count > 0)
            {
                string currMeal = meals.Peek();
                int currMealCalories = mealsTable[currMeal];

                int calorieIntakePerDay = caloriesIntakePerDay.Peek();

                if (calorieIntakePerDay > currMealCalories)
                {
                    calorieIntakePerDay -= currMealCalories;
                    caloriesIntakePerDay.Pop();
                    caloriesIntakePerDay.Push(calorieIntakePerDay);
                    meals.Dequeue();
                }
                else if (calorieIntakePerDay < currMealCalories)
                {
                    currMealCalories -= calorieIntakePerDay;
                    caloriesIntakePerDay.Pop();

                    if (caloriesIntakePerDay.Any(x => x > currMealCalories))
                    {
                        int nextDay = caloriesIntakePerDay.Pop();
                        nextDay -= currMealCalories;
                        caloriesIntakePerDay.Push(nextDay);

                    }

                    meals.Dequeue();
                }
                else
                {
                    meals.Dequeue();
                    caloriesIntakePerDay.Pop();
                }

                mealsCounter++;
            }

            if (meals.Count <= 0)
            {
                Console.WriteLine($"John had {mealsCounter} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesIntakePerDay)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsCounter} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
