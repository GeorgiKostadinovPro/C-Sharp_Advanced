using System;
using System.Linq;

namespace _06_JaggedArrayManipulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jagged = new double[rows][];

            for (var i = 0; i < rows; i++)
            {
                var rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jagged[i] = rowData;
            }

            for (int i = 0; i < jagged.Length - 1; i++)
            {
                if (jagged[i].Length == jagged[i + 1].Length)
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] *= 2;
                    }

                    for (int j = 0; j < jagged[i + 1].Length; j++)
                    {
                        jagged[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] /= 2;
                    }

                    for (int j = 0; j < jagged[i + 1].Length; j++)
                    {
                        jagged[i + 1][j] /= 2;
                    }
                }
            }

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmd = cmdArgs[0];

                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if ((row >= 0 && row < jagged.Length) && (col >= 0 && col < jagged[row].Length))
                {
                    if (cmd == "Add")
                    {
                        jagged[row][col] += value;
                    }
                    else if (cmd == "Subtract")
                    {
                        jagged[row][col] -= value;
                    }
                }
            }

            for (int i = 0; i < jagged.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jagged[i]));
            }
        }
    }
}
