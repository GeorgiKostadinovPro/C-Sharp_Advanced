using System;
using System.Linq;

namespace _02_Garden
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] garden = new int[size[0], size[1]];

            for (int i = 0; i < size[0]; i++)
            {
                for (int j = 0; j < size[1]; j++)
                {
                    garden[i, j] = 0;
                }
            }

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = coordinates[0];
                int col = coordinates[1];

                if (!AreValidIndexes(garden, row, col))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                garden[row, col] = 1;

                int rowForUp = row - 1;
                int rowForDown = row + 1;
                int colForLeft = col - 1;
                int colForRight = col + 1;

                while (rowForUp >= 0)
                {
                    garden[rowForUp, col]++;
                    rowForUp--;
                }

                while (rowForDown < garden.GetLength(0))
                {
                    garden[rowForDown, col]++;
                    rowForDown++;
                }

                while (colForLeft >= 0)
                {
                    garden[row, colForLeft]++;
                    colForLeft--;
                }

                while (colForRight < garden.GetLength(1))
                {
                    garden[row, colForRight]++;
                    colForRight++;
                }
            }

            for (int i = 0; i < size[0]; i++)
            {
                for (int j = 0; j < size[1]; j++)
                {
                    Console.Write(garden[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool AreValidIndexes(int[,] garden, int row, int col)
        {
            return row >= 0 && row < garden.GetLength(0) && col >= 0 && col < garden.GetLength(1);
        }
    }
}
