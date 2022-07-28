using System;
using System.Collections.Generic;

namespace _01_ReverseAString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string str = Console.ReadLine();

            Stack<char> reversedStr = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                reversedStr.Push(str[i]);
            }

            while (reversedStr.Count > 0)
            {
                char currElement = reversedStr.Pop();
                Console.Write(currElement);
            }
        }
    }
}
