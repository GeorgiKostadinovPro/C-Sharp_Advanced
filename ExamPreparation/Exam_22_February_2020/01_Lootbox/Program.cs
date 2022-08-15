using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_LootBox
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> firstLootBox = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> secondLootBox = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int claimedItems = 0;

            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                int firstItem = firstLootBox.Peek();
                int secondItem = secondLootBox.Pop();

                int sum = firstItem + secondItem;

                if (sum % 2 == 0)
                {
                    claimedItems += sum;
                    firstLootBox.Dequeue();
                }
                else
                {
                    firstLootBox.Enqueue(secondItem);
                }
            }

            if (firstLootBox.Count > 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            else if (secondLootBox.Count > 0)
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
