namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] data = File.ReadAllLines(inputFilePath);

            char[] symbols = { '.', ',', '!', '?', ':', '-', '\'', '"', '(', ')', '[', ']', ';' };

            string[] result = new string[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                int currSignsCount = 0;
                int currLettersCount = 0;

                foreach (var symbol in symbols)
                {
                    currSignsCount += data[i].Count(e => e == symbol);
                }

                for (int j = 0; j < data[i].Length; j++)
                {
                    if (char.IsLetter(data[i][j]))
                    {
                        currLettersCount++;
                    }
                }

                string line = $"Line {i+1} :{data[i]}({currLettersCount})({currSignsCount})";
                result[i] = line;
            }

            File.WriteAllLines(outputFilePath, result);
        }
    }
}
