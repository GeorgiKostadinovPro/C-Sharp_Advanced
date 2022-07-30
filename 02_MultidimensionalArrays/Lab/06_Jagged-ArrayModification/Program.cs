using System;
using System.Linq;

namespace _06_JaggedArrayModification
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[][] matrix = new int[size][];

            for (int i = 0; i < size; i++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = rowData;
            }

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = line.Split(' ');

                string cmd = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (row > matrix.Length - 1 || row < 0)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (col > matrix.ElementAt(row).Length - 1 || col < 0)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (cmd == "Add")
                    {
                        matrix[row][col] += value;
                    }
                    else
                    {
                        matrix[row][col] -= value;
                    }
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }
    }
}
