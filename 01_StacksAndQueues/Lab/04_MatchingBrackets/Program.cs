using System;
using System.Collections.Generic;

namespace _04_MatchingBrackets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputExpression = Console.ReadLine();

            Stack<int> expressionIndexes = new Stack<int>();

            for (int i = 0; i < inputExpression.Length; i++)
            {
                char symbol = inputExpression[i];

                if (symbol == '(')
                {
                    expressionIndexes.Push(i);
                }
                else if (symbol == ')')
                {
                    int index = expressionIndexes.Pop();

                    string exp = inputExpression.Substring(index, i - index + 1);
                    Console.WriteLine(exp);
                }
            }
        }
    }
}
