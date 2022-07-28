using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_SimpleCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] inputExpression = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            Stack<string> expression = new Stack<string>(inputExpression);

            int result = int.Parse(expression.Pop());

            while (expression.Count > 0)
            {
                string @operator = expression.Pop();
                int number = int.Parse(expression.Pop());

                if (@operator == "+")
                {
                    result += number;
                }
                else if (@operator == "-")
                {
                    result -= number;
                }
            }

            Console.WriteLine(result);
        }
    }
}
