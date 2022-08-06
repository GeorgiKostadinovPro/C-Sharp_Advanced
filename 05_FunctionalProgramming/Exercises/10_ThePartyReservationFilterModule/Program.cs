using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_ThePartyReservationFilterModule
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> temp = new List<string>();

            string line = Console.ReadLine();

            var commandLines = new List<string>();

            while (line?.ToLower() != "print")
            {
                string[] tokens = line
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                var currCommand = tokens[1] + ';' + tokens[2];

                switch (tokens[0]?.ToLower())
                {
                    case "add filter":
                        commandLines.Add(currCommand);
                        break;
                    case "remove filter":
                        commandLines.RemoveAll(x => x == currCommand);
                        break;
                    default:
                        throw new ArgumentException("Invalid command: " + tokens[0]);
                }

                line = Console.ReadLine();
            }

            foreach (var currCommand in commandLines)
            {
                var commandTokens = currCommand.Split(";");
                Predicate<string> predicate = GetPredicate(commandTokens[0], commandTokens[1]);
                guests.RemoveAll(predicate);
            }

            Console.WriteLine(string.Join(" ", guests));
        }

        private static Predicate<string> GetPredicate(string command, string arg)
        {
            switch (command?.ToLower())
            {
                case "starts with":
                    return name => name.StartsWith(arg);
                case "ends with":
                    return name => name.EndsWith(arg);
                case "contains":
                    return name => name.Contains(arg);
                case "length":
                    return name => name.Length == int.Parse(arg);
                default:
                    throw new ArgumentException("Invalid command: " + command);
            }
        }
    }
}