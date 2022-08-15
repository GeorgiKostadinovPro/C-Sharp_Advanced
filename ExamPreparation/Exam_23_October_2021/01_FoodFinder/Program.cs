using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_FoodFinder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray());

            Stack<char> consonants = new Stack<char>(Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(char.Parse)
               .ToArray());

            int numberOfWordsFound = 0;

            string[] foods = { "pear", "flour", "pork", "olive" };

            while (consonants.Count > 0)
            {
                char vowel = vowels.Peek();
                char consonant = consonants.Pop();

                for (int i = 0; i < foods.Length; i++)
                {
                    if (foods[i].Contains(vowel))
                    {
                        foods[i] = foods[i].Replace(vowel, '1');
                    }

                    if (foods[i].Contains(consonant))
                    {
                        foods[i] = foods[i].Replace(consonant, '1');
                    }
                }

                vowels.Dequeue();
                vowels.Enqueue(vowel);
            }

            for (int i = 0; i < foods.Length; i++)
            {
                int counterOnes = 0;

                for (int j = 0; j < foods[i].Length; j++)
                {
                    if (foods[i][j] == '1')
                    {
                        counterOnes++;
                    }
                }

                if (counterOnes == foods[i].Length)
                {
                    numberOfWordsFound++;
                }
            }

            if (foods[0] == "1111")
            {
                foods[0] = "pear";
            }

            if (foods[1] == "11111")
            {
                foods[1] = "flour";
            }

            if (foods[2] == "1111")
            {
                foods[2] = "pork";
            }

            if (foods[3] == "11111")
            {
                foods[3] = "olive";
            }

            Console.WriteLine($"Words found: {numberOfWordsFound}");

            foreach (var food in foods.Where(f => !f.Contains('1')))
            {
                Console.WriteLine(food);
            }
        }
    }
}
