using System;
using System.Linq;

namespace _01_DiagonalDifference
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
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

            int sumMainDiagonal = 0;
            int sumSecondaryDiagonal = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        sumMainDiagonal += matrix[i, j];
                    }

                    if ((i + j) == (size - 1))
                    {
                        sumSecondaryDiagonal += matrix[i, j];
                    }
                }
            }

            Console.WriteLine(Math.Abs(sumMainDiagonal - sumSecondaryDiagonal));

        }
    }
}
