namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath, "*");

            Dictionary<string, Dictionary<string, double>> filesInfo = 
                new Dictionary<string, Dictionary<string, double>>();

            foreach (var fileFullPath in files)
            {
                string fileName = Path.GetFileName(fileFullPath);
                string extension = Path.GetExtension(fileFullPath);
                double size = new FileInfo(fileFullPath).Length / 1024.0;

                if (!filesInfo.ContainsKey(extension))
                {
                    filesInfo.Add(extension, new Dictionary<string,double>());
                }

                filesInfo[extension].Add(fileName, size);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var currExtension in filesInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                string exName = currExtension.Key;
                sb.AppendLine(exName);

                foreach (var innerFiles in currExtension.Value.OrderBy(x => x.Value))
                {
                    string inner = $"--{innerFiles.Key} - {innerFiles.Value}kb";
                    sb.AppendLine(inner);
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";
            File.WriteAllText(path, textContent);
        }

    }
}
