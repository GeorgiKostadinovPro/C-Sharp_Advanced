using System;
using System.Linq;

namespace _02_SquaresInMatrix
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

            int squareMatrixCount = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i < rows - 1 && j < cols - 1)
                    {
                        if (matrix[i, j] == matrix[i + 1, j]
                            && matrix[i, j] == matrix[i, j + 1]
                            && matrix[i, j] == matrix[i + 1, j + 1])
                        {
                            squareMatrixCount++;
                        }
                    }
                }
            }

            Console.WriteLine(squareMatrixCount);
        }
    }
}
