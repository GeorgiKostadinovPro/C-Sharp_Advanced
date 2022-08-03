namespace FolderSize
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);

            double size = directoryInfo.EnumerateFiles("*", SearchOption.AllDirectories).Sum(f => f.Length);

            size /= 1024;

            File.WriteAllText(outputFilePath, size.ToString());
        }
    }
}
