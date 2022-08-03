namespace MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            Queue<string> firstFileText = new Queue<string>(File.ReadAllLines(firstInputFilePath));
            Queue<string> secondFileText = new Queue<string>(File.ReadAllLines(secondInputFilePath));

            List<string> outputResult = new List<string>();

            while (firstFileText.Count > 0 && secondFileText.Count > 0)
            {
                string firstFileLine = firstFileText.Dequeue();
                string secondFileLine = secondFileText.Dequeue();

                outputResult.Add(firstFileLine);
                outputResult.Add(secondFileLine);
            }

            string[] leftIfAny = firstFileText.Count > 0 
                ? firstFileText.ToArray() 
                : secondFileText.ToArray();

            outputResult.AddRange(leftIfAny);

            File.WriteAllLines(outputFilePath, outputResult);
        }
    }
}
