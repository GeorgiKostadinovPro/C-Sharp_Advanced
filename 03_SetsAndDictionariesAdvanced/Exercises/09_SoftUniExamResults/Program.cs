using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_SoftUniExamResults
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> userPoints = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] info = input.Split('-', StringSplitOptions.RemoveEmptyEntries);

                string user = info[0];
                string languageOrBan = info[1];

                if (languageOrBan == "banned")
                {
                    userPoints.Remove(user);
                    continue;
                }

                int points = int.Parse(info[2]);

                if (!userPoints.ContainsKey(user))
                {
                     userPoints.Add(user, 0);
                }

                userPoints[user] = Math.Max(userPoints[user], points);

                if (!submissions.ContainsKey(languageOrBan))
                {
                    submissions.Add(languageOrBan, 0);
                }

                submissions[languageOrBan] += 1;
            }

            Console.WriteLine("Results:");
            foreach (var kvp in userPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var kvp in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }

        }
    }
}
