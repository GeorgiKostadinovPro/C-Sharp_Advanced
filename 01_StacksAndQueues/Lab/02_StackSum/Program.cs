using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_StackSum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbers = new Stack<int>(inputNumbers);

            while (true)
            {
                string[] cmdArgs = Console.ReadLine()
                    .ToLower()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmd = cmdArgs[0];

                if (cmd == "end")
                {
                    break;
                }

                if (cmd == "add")
                {
                    int firstNumber = int.Parse(cmdArgs[1]);
                    int secondNumber = int.Parse(cmdArgs[2]);

                    numbers.Push(firstNumber);
                    numbers.Push(secondNumber);
                }
                else if (cmd == "remove")
                {
                    int countOfRemovedNums = int.Parse(cmdArgs[1]);

                    if (numbers.Count >= countOfRemovedNums)
                    {
                        for (int i = 0; i < countOfRemovedNums; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }
            }

            int sum = numbers.Sum();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
