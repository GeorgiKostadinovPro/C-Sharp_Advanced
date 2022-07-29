using System;
using System.Collections.Generic;

namespace _08_BalancedParenthesis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string expressionInput = Console.ReadLine();

            Stack<char> expression = new Stack<char>();

            for (int i = 0; i < expressionInput.Length; i++)
            {
                char bracket = expressionInput[i];

                if (bracket == '(')
                {
                    expression.Push(bracket);
                }
                else if (bracket == ')')
                {
                    if (expression.Count > 0 && expression.Peek() == '(')
                    {
                        expression.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }

                if (bracket == '{')
                {
                    expression.Push(bracket);
                }
                else if (bracket == '}')
                {
                    if (expression.Count > 0 && expression.Peek() == '{')
                    {
                        expression.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }

                if (bracket == '[')
                {
                    expression.Push(bracket);
                }
                else if (bracket == ']')
                {
                    if (expression.Count > 0 && expression.Peek() == '[')
                    {
                        expression.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            if (expression.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else 
            { 
               Console.WriteLine("NO");
            }
        }
    }
}