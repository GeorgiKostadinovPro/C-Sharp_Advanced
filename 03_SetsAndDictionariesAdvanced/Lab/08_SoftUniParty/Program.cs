using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_SoftUniParty
{

    public class Program
    {
        public static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "END")
            {
                string guest = line;

                if (line == "PARTY")
                {
                    while ((guest = Console.ReadLine()) != "END")
                    {
                       if (guests.Contains(guest))
                       {
                           guests.Remove(guest);
                       }
                    }

                    break;
                }

                guests.Add(guest);
            }

            Console.WriteLine(guests.Count);

            string[] vipGuests = guests
                .Where(g => char.IsDigit(g[0]))
                .ToArray();

            string[] regularGuests = guests
                .Where(g => !char.IsDigit(g[0]))
                .ToArray();

            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regularGuests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
