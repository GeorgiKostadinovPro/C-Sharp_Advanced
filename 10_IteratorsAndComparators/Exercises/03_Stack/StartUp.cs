using CustomStack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "END")
            {
                if (line.Contains("Push"))
                {
                    string[] elements = line
                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1).ToArray();

                    foreach (string element in elements)
                    {
                        stack.Push(int.Parse(element));
                    }
                }
                else if (line == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }

            foreach (var number in stack)
            {
                Console.WriteLine(number);
            }

            foreach (var number in stack)
            {
                Console.WriteLine(number);
            }
        }
    }
}
