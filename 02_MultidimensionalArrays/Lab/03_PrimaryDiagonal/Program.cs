using System;
using System.Linq;

namespace _03_PrimaryDiagonal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                int[] rowData = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();

                for (int j = 0; j < rowData.Length; j++)
                {
                    matrix[i, j] = rowData[j];
                }
            }

            int sumMainDiagonal = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        sumMainDiagonal += matrix[i, j];
                    }
                }
            }

            Console.WriteLine(sumMainDiagonal);
        }
    }
}
