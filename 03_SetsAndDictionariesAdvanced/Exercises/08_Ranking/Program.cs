using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Ranking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();

            var usersContests = new Dictionary<string, Dictionary<string, int>>();

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "end of contests")
            {
                string[] contestsInfo = line
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);

                string contest = contestsInfo[0];
                string password = contestsInfo[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }
            }

            string nextLine = string.Empty;

            while ((nextLine = Console.ReadLine()) != "end of submissions")
            {
                string[] submissions = nextLine
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = submissions[0];
                string password = submissions[1];
                string username = submissions[2];
                int points = int.Parse(submissions[3]);

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest].Equals(password))
                    {
                        if (!usersContests.ContainsKey(username))
                        {
                            usersContests.Add(username, new Dictionary<string, int>());
                        }

                        if (usersContests.ContainsKey(username) && !usersContests[username].ContainsKey(contest))
                        {
                            usersContests[username].Add(contest, points);
                        }

                        if (usersContests.ContainsKey(username) && usersContests[username].ContainsKey(contest))
                        {
                            if (usersContests[username][contest] < points)
                            {
                                usersContests[username][contest] = points;
                            }
                        }
                    }
                }
            }

            string winner = usersContests.OrderByDescending(x => x.Value.Values.Sum()).FirstOrDefault().Key;
            int bestPoints = usersContests.OrderByDescending(x => x.Value.Values.Sum()).FirstOrDefault().Value.Values.Sum();

            Console.WriteLine($"Best candidate is {winner} with total {bestPoints} points.");

            Console.WriteLine("Ranking:");

            foreach (var item in usersContests.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var contest in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}