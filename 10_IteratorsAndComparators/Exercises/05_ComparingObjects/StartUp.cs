using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            
            string line = string.Empty;

            while ((line = Console.ReadLine()) != "END")
            {
                string[] personData = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                int age = int.Parse(personData[1]);
                string town = personData[2];

                Person person = new Person(name, age, town);
                people.Add(person);
            }

            int personIndex = int.Parse(Console.ReadLine()) - 1;
            Person personToCompare = people[personIndex];
            people.Remove(personToCompare);
            int equalCounter = 1;
            int nonEqualCounter = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    equalCounter++;
                }
                else
                {
                    nonEqualCounter++;
                }
            }

            if (equalCounter > 1)
            {
                Console.WriteLine($"{equalCounter} {nonEqualCounter} {equalCounter + nonEqualCounter}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
