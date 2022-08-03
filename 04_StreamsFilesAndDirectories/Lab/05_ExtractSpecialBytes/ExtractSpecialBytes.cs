using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ExtractSpecialBytes
{
   
    public class ExtractSpecialBytes
    {
        static void Main(string[] args)
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            byte[] imageBytes = File.ReadAllBytes(binaryFilePath);

            string[] bytesFile = File.ReadAllLines(bytesFilePath);

            List<byte> allBytes = new List<byte>();

            for (int i = 0; i < imageBytes.Length; i++)
            {
                if (bytesFile.Contains(imageBytes[i].ToString()))
                {
                    allBytes.Add(imageBytes[i]);
                }
            }

            File.WriteAllBytes(outputPath, allBytes.ToArray());
        }
    }
}