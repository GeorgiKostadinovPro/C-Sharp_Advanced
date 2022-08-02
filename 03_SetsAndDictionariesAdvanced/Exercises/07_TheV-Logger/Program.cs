using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_The_V_Logger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, List<int>> theVLogger = new Dictionary<string, List<int>>();
            Dictionary<string, List<string>> vloggerFollowings = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> vloggerFollowers = new Dictionary<string, List<string>>();

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "Statistics")
                {
                    Console.WriteLine($"The V-Logger has a total of {theVLogger.Count()} vloggers in its logs.");

                    foreach (var v1 in theVLogger)
                    {
                        foreach (var v2 in vloggerFollowings)
                        {
                            foreach (var v3 in vloggerFollowers)
                            {
                                if (v1.Key == v2.Key && v1.Key == v3.Key)
                                {
                                    theVLogger[v1.Key][0] = vloggerFollowers[v1.Key].Count();
                                    theVLogger[v1.Key][1] = vloggerFollowings[v1.Key].Count();
                                }
                            }
                        }
                    }

                    theVLogger = theVLogger.OrderByDescending(v => v.Value[0]).ThenBy(v => v.Value[1]).ToDictionary(v => v.Key, v => v.Value);
                    var bestVlogger = theVLogger.FirstOrDefault();

                    Console.WriteLine($"1. {bestVlogger.Key} : {bestVlogger.Value[0]} followers, {bestVlogger.Value[1]} following");

                    foreach (var item in vloggerFollowers)
                    {
                        if (item.Key == bestVlogger.Key)
                        {
                            foreach (var v in item.Value.OrderBy(x => x))
                            {
                                Console.WriteLine($"*  {v}");
                            }
                        }
                    }

                    int n = 2;

                    foreach (var item in theVLogger.Skip(1))
                    {
                        Console.WriteLine($"{n}. {item.Key} : {item.Value[0]} followers, {item.Value[1]} following");
                        n++;
                    }

                    break;
                }

                string[] cmdInfo = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string vlogger = cmdInfo[0];

                if (cmd.Contains("joined"))
                {
                    if (!theVLogger.ContainsKey(vlogger))
                    {
                        theVLogger.Add(vlogger, new List<int>(2) { 0, 0 });
                    }

                    if (!vloggerFollowers.ContainsKey(vlogger))
                    {
                        vloggerFollowers.Add(vlogger, new List<string>());
                    }

                    if (!vloggerFollowings.ContainsKey(vlogger))
                    {
                        vloggerFollowings.Add(vlogger, new List<string>());
                    }
                }
                else if (cmd.Contains("followed"))
                {
                    string followingVlogger = cmdInfo[2];

                    if (theVLogger.ContainsKey(vlogger) && theVLogger.ContainsKey(followingVlogger))
                    {
                        if (vlogger != followingVlogger)
                        {
                            if (!vloggerFollowings[vlogger].Any(v => v == followingVlogger))
                            {
                                vloggerFollowings[vlogger].Add(followingVlogger);
                                vloggerFollowers[followingVlogger].Add(vlogger);
                            }
                        }
                    }
                }
            }
        }
    }
}
