using System;
using System.Linq;

namespace _07_PascalTriangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[lines][];

            for (var row = 0; row < lines; row++)
            {
                pascalTriangle[row] = new long[row + 1];
                pascalTriangle[row][0] = 1;
                pascalTriangle[row][^1] = 1;

                for (int col = 1; col < row; col++)
                {
                    pascalTriangle[row][col] = pascalTriangle[row - 1][col - 1] + pascalTriangle[row - 1][col];
                }
            }

            for (var row = 0; row < lines; row++)
            {
                Console.WriteLine(string.Join(" ", pascalTriangle[row]));
            }
        }
    }
}
