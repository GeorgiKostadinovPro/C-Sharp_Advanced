using System;

namespace _03_CountUppercaseWords
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Func<string, bool> uppercaseWords = (text) => {
                string[] words = text
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    return char.IsUpper(word[0]);
                }

                return false;
            };

            foreach (var word in text.Split(' '))
            {
                if (uppercaseWords(word))
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
