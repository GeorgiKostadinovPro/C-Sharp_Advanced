using System;
using System.Linq;

namespace _05_SquareWithMaximumSum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int i = 0; i < size[0]; i++)
            {
                var rowData = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < rowData.Length; j++)
                {
                    matrix[i, j] = rowData[j];
                }
            }

            SquareWithMaximumSum(matrix);
        }

        private static void SquareWithMaximumSum(int[,] matrix)
        {
            int maxSum = int.MinValue;
            int maxRowIndex = 0;
            int maxColIndex = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i + 1 < matrix.GetLength(0) && j + 1 < matrix.GetLength(1))
                    {
                        int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];

                        if (sum > maxSum)
                        {
                            maxSum = sum;
                            maxRowIndex = i;
                            maxColIndex = j;
                        }
                    }
                }
            }

            for (int i = maxRowIndex; i < maxRowIndex + 2; i++)
            {
                for (int j = maxColIndex; j < maxColIndex + 2; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
