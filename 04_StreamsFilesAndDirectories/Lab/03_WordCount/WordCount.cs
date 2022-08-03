namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            string[] words = File.ReadAllText(wordsFilePath)
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] text = File.ReadAllLines(textFilePath);

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].ToLower();

                if (!wordCounts.ContainsKey(word))
                {
                    wordCounts.Add(word, 0);
                }

                int wordCount = text.Count(t => t.ToLower().Contains(word));

                wordCounts[word] = wordCount;
            }

            StreamWriter writer = new StreamWriter(outputFilePath);

            foreach (var word in wordCounts.OrderByDescending(w => w.Value))
            {
                writer.WriteLine($"{word.Key} - {word.Value}");
            }

            writer.Close();
        }
    }
}
