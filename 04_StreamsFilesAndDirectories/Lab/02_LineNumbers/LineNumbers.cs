namespace LineNumbers
{
    using System.Collections.Generic;
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);

            List<string> lines = new List<string>();

            string text = string.Empty;

            while ((text = reader.ReadLine()) != null)
            {
                lines.Add(text);
            }

            reader.Close();

            StreamWriter writer = new StreamWriter(outputFilePath);

            for (int i = 0; i < lines.Count; i++)
            {
                writer.WriteLine($"{i + 1}. {lines[i]}");
            }

            writer.Close();
        }
    }
}
