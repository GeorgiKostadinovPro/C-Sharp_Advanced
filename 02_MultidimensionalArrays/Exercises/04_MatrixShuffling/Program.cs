using System;
using System.Linq;

namespace _04_MatrixShuffling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] matrixRowsCols = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int rows = matrixRowsCols[0];
            int cols = matrixRowsCols[1];

            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] dataRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < dataRow.Length; j++)
                {
                    matrix[i, j] = dataRow[j];
                }
            }

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmd = cmdArgs[0];

                if (cmd == "swap" && cmdArgs.Length == 5)
                {
                    int row1 = int.Parse(cmdArgs[1]);
                    int col1 = int.Parse(cmdArgs[2]);
                    int row2 = int.Parse(cmdArgs[3]);
                    int col2 = int.Parse(cmdArgs[4]);

                    if (row1 < rows && col1 < cols && row2 < rows && col2 < cols)
                    {
                        string temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;

                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < cols; j++)
                            {
                                Console.Write($"{matrix[i, j]} ");
                            }

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
