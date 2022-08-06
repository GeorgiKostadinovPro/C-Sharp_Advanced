using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_PredicateParty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var namesList = Console.ReadLine()
                .Split()
                .ToList();

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "Party!")
            {
                List<string> tokens = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var predicate = GetPredicate(tokens[1], tokens[2]);

                switch (tokens[0])
                {
                    case "Remove":
                        namesList.RemoveAll(predicate);
                        break;
                    case "Double":
                        {
                            var matches = namesList.FindAll(predicate);
                            if (matches.Count > 0)
                            {
                                var index = namesList.FindIndex(predicate);
                                namesList.InsertRange(index, matches);
                            }

                            break;
                        }
                }
            }

            if (namesList.Count != 0)
            {
                Console.WriteLine(string.Join(", ", namesList) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string commandType, string arg)
        {
            switch (commandType)
            {
                case "StartsWith":
                    return (name) => name.StartsWith(arg);
                case "EndsWith":
                    return (name) => name.EndsWith(arg);
                case "Length":
                    return (name) => name.Length == int.Parse(arg);
                default:
                    throw new ArgumentException("Invalid command type: " + commandType);
            }
        }
    }

}