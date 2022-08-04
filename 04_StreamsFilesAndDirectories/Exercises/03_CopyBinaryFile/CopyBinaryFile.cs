using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\copyMe.png";
            string outputPath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputPath, outputPath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream stream = new FileStream(inputFilePath, FileMode.Open))
            {
                using (FileStream writer = new FileStream(outputFilePath, FileMode.Create)) 
                { 
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int currByte = stream.Read(buffer, 0, buffer.Length);

                        if (currByte <= 0)
                        {
                            break;
                        } 
                        
                        writer.Write(buffer, 0, buffer.Length); 
                    }
                }
            }
        }
    }
}
