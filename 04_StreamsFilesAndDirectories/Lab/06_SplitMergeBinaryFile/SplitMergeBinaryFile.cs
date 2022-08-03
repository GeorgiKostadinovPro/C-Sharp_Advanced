namespace SplitMergeBinaryFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using FileStream reader = new FileStream(sourceFilePath, FileMode.Open);
            using FileStream firstWriter = new FileStream(partOneFilePath, FileMode.OpenOrCreate);
            using FileStream secondWriter = new FileStream(partTwoFilePath, FileMode.OpenOrCreate);

            long firstSize = reader.Length / 2;
            long secondSize = reader.Length - firstSize;

            if (secondSize > firstSize)
            {
                (secondSize, firstSize) = (firstSize, secondSize);
            }

            byte[] firstPartBytes = new byte[firstSize];
            reader.Read(firstPartBytes);
            firstWriter.Write(firstPartBytes);

            byte[] secondPartBytes = new byte[secondSize];
            reader.Read(secondPartBytes);
            secondWriter.Write(secondPartBytes);
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using FileStream writer = new FileStream(joinedFilePath, FileMode.Create);
            using FileStream fristReader = new FileStream(partOneFilePath, FileMode.Open);
            byte[] firstPartBytes = new byte[fristReader.Length];
            fristReader.Read(firstPartBytes);
            writer.Write(firstPartBytes);

            using FileStream secondReader = new FileStream(partTwoFilePath, FileMode.Open);
            byte[] secondPartBytes = new byte[secondReader.Length];
            secondReader.Read(secondPartBytes);
            writer.Write(secondPartBytes);
        }
    }
}