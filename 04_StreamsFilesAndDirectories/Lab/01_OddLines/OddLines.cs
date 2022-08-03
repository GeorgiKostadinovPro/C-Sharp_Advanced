namespace OddLines
{
    using System.Collections.Generic;
    using System.IO;
	
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);

            List<string> oddLines = new List<string>();

            int lines = 0;

            string text = string.Empty;

            while ((text = reader.ReadLine()) != null)
            {
                if (lines % 2 != 0)
                {
                    oddLines.Add(text);
                }

                lines++;
            }

            reader.Close();

            StreamWriter writer = new StreamWriter(outputFilePath);

            foreach (var line in oddLines)
            {
                writer.WriteLine(line);
            }

            writer.Close();
        }
    }
}
