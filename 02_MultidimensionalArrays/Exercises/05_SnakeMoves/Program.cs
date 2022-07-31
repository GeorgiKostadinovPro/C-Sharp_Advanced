using System;
using System.Linq;

namespace _05_SnakeMoves
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string snake = Console.ReadLine();

            string[,] matrix = new string[size[0], size[1]];

            bool leftToRight = true;
            int currIndexOfSnake = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (leftToRight)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = snake[currIndexOfSnake++].ToString();

                        if (currIndexOfSnake == snake.Length)
                        {
                            currIndexOfSnake = 0;
                        }
                    }

                    leftToRight = false;
                }
                else
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        matrix[i, j] = snake[currIndexOfSnake++].ToString();

                        if (currIndexOfSnake == snake.Length)
                        {
                            currIndexOfSnake = 0;
                        }
                    }

                    leftToRight = true;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
