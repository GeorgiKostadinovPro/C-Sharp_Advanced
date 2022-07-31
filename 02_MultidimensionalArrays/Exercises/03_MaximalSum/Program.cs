using System;
using System.Linq;

namespace _03_MaximalSum
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

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] dataRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < dataRow.Length; j++)
                {
                    matrix[i, j] = dataRow[j];
                }
            }

            int maxSum = int.MinValue;
            int maxSumRowIndex = 0;
            int maxSumColumnIndex = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i < rows - 2 && j < cols - 2)
                    {
                        int currSum = matrix[i, j] + matrix[i + 1, j] + matrix[i + 2, j]
                            + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j + 1] + matrix[i + 2, j + 1]
                            + matrix[i + 1, j + 2] + matrix[i + 2, j + 2];

                        if (currSum > maxSum)
                        {
                            maxSum = currSum;
                            maxSumRowIndex = i;
                            maxSumColumnIndex = j;
                        }
                    }
                }
            }

            Console.WriteLine("Sum = " + maxSum);

            for (int i = maxSumRowIndex; i < maxSumRowIndex + 3; i++)
            {
                for (int j = maxSumColumnIndex; j < maxSumColumnIndex + 3; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
