using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_FlowerWreaths
{
    public class StartUp
    {
        private static int Wreath = 15;

        public static void Main(string[] args)
        {
            int[] liliesSequence = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] rosesSequence = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> lilies = new Stack<int>(liliesSequence);
            Queue<int> roses = new Queue<int>(rosesSequence);

            int storedSum = 0;
            int storedWreathCount = 0;

            int wreathCount = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int sum = lilies.Peek() + roses.Peek();

                if (sum == Wreath)
                {
                    wreathCount++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (sum > 15)
                {
                    lilies.Push(lilies.Pop() - 2);
                }
                else if (sum < 15)
                {
                    storedSum += sum;
                    lilies.Pop();
                    roses.Dequeue();
                }
            }

            while (storedSum >= Wreath)
            {
                storedSum -= Wreath;
                storedWreathCount++;
            }

            if (wreathCount + storedWreathCount >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCount + storedWreathCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - (wreathCount + storedWreathCount)} wreaths more!");
            }
        }
    }
}
