using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_FilterByAge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string person = input[0];
                int age = int.Parse(input[1]);

                if (!people.ContainsKey(person))
                {
                    people.Add(person, age);
                }
            }

            string condition = Console.ReadLine();
            int ageCondition = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> checkYounger = (x) => x < ageCondition;

            Action<Dictionary<string, int>> printName = (x) =>
            {
                foreach (var item in x.Keys)
                {
                    Console.WriteLine(item);
                }
            };

            Action<Dictionary<string, int>> printAge = (x) =>
            {
                foreach (var item in x.Values)
                {
                    Console.WriteLine(item);
                }
            };

            Action<Dictionary<string, int>> printFullName = (x) =>
            {
                foreach (var item in x)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            };

            if (condition == "younger")
            {
                people = people.Where(x => checkYounger(x.Value)).ToDictionary(x => x.Key, x => x.Value);
            }
            else if (condition == "older")
            {
                people = people.Where(x => !checkYounger(x.Value)).ToDictionary(x => x.Key, x => x.Value);
            }

            if (format == "name")
            {
                printName(people);
            }
            else if (format == "age")
            {
                printAge(people);
            }
            else if (format == "name age")
            {
                printFullName(people);
            }
        }
    }
}
