using System;
using System.Collections.Generic;
using System.Text;

namespace _09_SimpleTextEditor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> previousVersions = new Stack<string>();

            StringBuilder result = new StringBuilder();

            previousVersions.Push(result.ToString());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmd = cmdArgs[0];

                if (cmd == "1")
                {
                    string str = cmdArgs[1];

                    result.Append(str);
                    previousVersions.Push(result.ToString());
                }
                else if (cmd == "2")
                {
                    int count = int.Parse(cmdArgs[1]);

                    result.Remove(result.Length - count, count);
                    previousVersions.Push(result.ToString());
                }
                else if (cmd == "3")
                {
                    int index = int.Parse(cmdArgs[1]);
                    char character = result[index - 1];
                    Console.WriteLine(character);
                }
                else if (cmd == "4")
                {
                    previousVersions.Pop();
                    result = new StringBuilder();
                    result.Append(previousVersions.Peek());
                }
            }
        }
    }
}