using System;
using System.Linq;

namespace _04_SymbolInMatrix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[,] matrix = new string[size, size];

            for (int i = 0; i < size; i++)
            {
                string rowData = Console.ReadLine();

                for (int j = 0; j < rowData.Length; j++)
                {
                    matrix[i, j] = rowData[j].ToString();
                }
            }

            string symbol = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == symbol)
                    {
                        found = true;
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
