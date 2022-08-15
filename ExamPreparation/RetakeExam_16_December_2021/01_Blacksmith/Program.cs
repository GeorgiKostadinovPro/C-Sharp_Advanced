using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Blacksmith
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> carbon = new Stack<int>(Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray());

            int swordsCount = 0;

            Dictionary<string, int> blacksmithsSwords = new Dictionary<string, int>()
            {
                {"Gladius", 0},
                {"Shamshir", 0},
                {"Katana", 0},
                {"Sabre", 0},
                {"Broadsword", 0},
            };

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int currSteel = steel.Peek();
                int currCarbon = carbon.Peek();

                int mix = currSteel + currCarbon;

                if (mix == 70 || mix == 80 || mix == 90 || mix == 110 || mix == 150)
                {
                    if (mix == 70)
                    {
                        blacksmithsSwords["Gladius"]++;
                    }
                    else if (mix == 80)
                    {
                        blacksmithsSwords["Shamshir"]++;
                    }
                    else if (mix == 90)
                    {
                        blacksmithsSwords["Katana"]++;
                    }
                    else if (mix == 110)
                    {
                        blacksmithsSwords["Sabre"]++;
                    }
                    else if (mix == 150)
                    {
                        blacksmithsSwords["Broadsword"]++;
                    }

                    swordsCount++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else
                {
                    steel.Dequeue();
                    currCarbon += 5;
                    carbon.Pop();
                    carbon.Push(currCarbon);
                }
            }

            if (blacksmithsSwords.Values.Any(s => s > 0))
            {
                Console.WriteLine($"You have forged {swordsCount} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            string steelResult = steel.Count > 0 ? string.Join(", ", steel) : "none";
            Console.WriteLine($"Steel left: {steelResult}");

            string carbonResult = carbon.Count > 0 ? string.Join(", ", carbon) : "none";
            Console.WriteLine($"Carbon left: {carbonResult}");

            foreach (var sword in blacksmithsSwords.Where(s => s.Value > 0).OrderBy(s => s.Key))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }
    }
}
