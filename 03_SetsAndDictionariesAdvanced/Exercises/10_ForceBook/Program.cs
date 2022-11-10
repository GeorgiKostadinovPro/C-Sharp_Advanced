using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_ForceBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string line = string.Empty;

            Dictionary<string, string> forceUsers = new Dictionary<string, string>();
            Dictionary<string, List<string>> forceSideMembers = new Dictionary<string, List<string>>();

            while ((line = Console.ReadLine()) != "Lumpawaroo")
            {

                if (line.Contains("|"))
                {
                    string[] cmdArgs = line
                    .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    string forceSide = cmdArgs[0];
                    string forceUser = cmdArgs[1];

                    if (!forceUsers.ContainsKey(forceUser))
                    {
                        forceUsers.Add(forceUser, forceSide);
                    }
                }
                else if (line.Contains("->"))
                {
                    string[] cmdArgs = line
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    string forceUser = cmdArgs[0];
                    string forceSide = cmdArgs[1];

                    if (!forceUsers.ContainsKey(forceUser))
                    {
                        forceUsers.Add(forceUser, null);
                    }

                    forceUsers[forceUser] = forceSide;

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            foreach (var forceUser in forceUsers)
            {
                if (!forceSideMembers.ContainsKey(forceUser.Value))
                {
                    forceSideMembers.Add(forceUser.Value, new List<string>());
                }

                forceSideMembers[forceUser.Value].Add(forceUser.Key);
            }

            foreach (var forceSide in forceSideMembers.OrderByDescending(s => s.Value.Count).ThenBy(s => s.Key))
            {
                Console.WriteLine($"Side: {forceSide.Key}, Members: {forceSide.Value.Count}");

                foreach (var forceUser in forceSide.Value.OrderBy(u => u))
                {
                    Console.WriteLine($"! {forceUser}");
                }
            }
        }
    }
}
