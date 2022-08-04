namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);

            string line = string.Empty;
            int n = 0;

            StringBuilder sb = new StringBuilder();

            while ((line = reader.ReadLine()) != null)
            {
                if (n % 2 == 0)
                {
                    string replaced = ReplaceSymbols(line);
                    replaced = ReverseWords(replaced);
                    sb.AppendLine(replaced);
                }

                n++;
            }

            return sb.ToString().TrimEnd();   
        }
        private static string ReverseWords(string line)
        {
            var result = line.Split(' ').Reverse();
            return string.Join(" ", result);
        }

        private static string ReplaceSymbols(string line)
        {
            char[] symbolstoReplace = { '.', ',', '-', '!', '?' };

            string result = string.Empty;

            for (int i = 0; i < line.Length; i++)
            {
                if (symbolstoReplace.Contains(line[i]))
                {
                    line = line.Replace(line[i], '@');
                    result = line;
                }
            }

            return result;
        }
    }

}
