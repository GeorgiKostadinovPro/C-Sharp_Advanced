using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_KeyRevolver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeGunBarrel = int.Parse(Console.ReadLine());

            int[] bullets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] locks = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var valueOfIntellegence = int.Parse(Console.ReadLine());

            Stack<int> bulletStack = new Stack<int>(bullets); 
            Queue<int> locksQueue = new Queue<int>(locks);

            var usedBullets = 0; 
            var barrelCount = 0;

            while (bulletStack.Count > 0 && locksQueue.Count > 0)
            {
                if (bulletStack.Peek() <= locksQueue.Peek()) 
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                    bulletStack.Pop();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bulletStack.Pop();

                }

                barrelCount++;

                if (barrelCount == sizeGunBarrel && bulletStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    barrelCount = 0;
                }

                usedBullets++;
            }

            if (bulletStack.Count >= 0 && locksQueue.Count == 0)
            {
                var earn = valueOfIntellegence - (usedBullets * bulletPrice);
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${earn}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
        }
    }
}