using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_FashionBoutique
{
    public class Program
    {
        public static void Main(string[] args)
        {
           int[] clothes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int capacityOfRack = int.Parse(Console.ReadLine());

            Stack<int> box = new Stack<int>(clothes);

            int racksCount = 1;

            int sum = 0;

            while (box.Count > 0)
            {
                int cloth = box.Peek();

                sum += cloth;

                if (sum <= capacityOfRack)
                {
                    box.Pop();
                }
                else
                {
                    racksCount++;
                    sum = 0;
                }
            }

            Console.WriteLine(racksCount);
        }
    }
}
