using System;
using System.Linq;

namespace _08_Bombs
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

            string[] coordinates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < coordinates.Length; i++)
            {
                string[] currCoordinates = coordinates[i]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(currCoordinates[0]);
                int col = int.Parse(currCoordinates[1]);

                if (matrix[row, col] <= 0)
                {
                    continue;
                }

                int currBombPower = matrix[row, col];

                matrix[row, col] = 0;
               
                if (row - 1 >= 0 && matrix[row - 1, col] > 0)
                {
                    matrix[row - 1, col] -= currBombPower;
                }

                if (row + 1 < size && matrix[row + 1, col] > 0)
                {
                    matrix[row + 1, col] -= currBombPower;
                }

                if (col - 1 >= 0 && matrix[row, col - 1] > 0)
                {
                    matrix[row, col - 1] -= currBombPower;
                }

                if (col + 1 < size && matrix[row, col + 1] > 0)
                {
                    matrix[row, col + 1] -= currBombPower;
                }

                if (row - 1 >= 0 && col - 1 >= 0 && matrix[row - 1, col - 1] > 0)
                {
                    matrix[row - 1, col - 1] -= currBombPower;
                }

                if (row + 1 < size && col - 1 >= 0 && matrix[row + 1, col - 1] > 0)
                {
                    matrix[row + 1, col - 1] -= currBombPower;
                }

                if (row - 1 >= 0 && col + 1 < size && matrix[row - 1, col + 1] > 0)
                {
                    matrix[row - 1, col + 1] -= currBombPower;
                }

                if (row + 1 < size && col + 1 < size && matrix[row + 1, col + 1] > 0)
                {
                    matrix[row + 1, col + 1] -= currBombPower;
                }
            }

            int activeCells = 0;
            int activeCellsSum = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i ,j] > 0)
                    {
                        activeCells++;
                        activeCellsSum += matrix[i, j];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {activeCells}");
            Console.WriteLine($"Sum: {activeCellsSum}");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
