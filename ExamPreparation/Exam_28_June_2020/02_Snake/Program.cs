using System;
using System.Collections.Generic;

namespace _02_Snake
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] territory = new char[n, n];

            List<int> burrows = new List<int>();
            int foodQuantity = 0;
            bool haveLeft = false;

            int snakeRow = 0;
            int snakeCol = 0;

            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();

                for (int j = 0; j < row.Length; j++)
                {
                    territory[i, j] = row[j];

                    if (territory[i, j] == 'S')
                    {
                        snakeRow = i;
                        snakeCol = j;
                    }
                    else if (territory[i, j] == 'B')
                    {
                        burrows.Add(i);
                        burrows.Add(j);
                    }
                }
            }

            int firstBurrowRow = 0;
            int firstBurrowCol = 0;
            int secondBurrowRow = 0;
            int secondBurrowCol = 0;

            if (burrows.Count > 0)
            {
                firstBurrowRow = burrows[0];
                firstBurrowCol = burrows[1];
                secondBurrowRow = burrows[2];
                secondBurrowCol = burrows[3];
            }

            string cmd = Console.ReadLine();

            while (true)
            {
                territory[snakeRow, snakeCol] = '.';

                if (cmd == "up")
                {
                    snakeRow--;

                    if (AreValidIndexes(territory, snakeRow, snakeCol))
                    {
                        if (territory[snakeRow, snakeCol] == '*')
                        {
                            foodQuantity++;
                            territory[snakeRow, snakeCol] = 'S';
                        }
                        else if (territory[snakeRow, snakeCol] == 'B')
                        {
                            if (snakeRow == firstBurrowRow && snakeCol == firstBurrowCol)
                            {
                                territory[firstBurrowRow, firstBurrowCol] = '.';

                                snakeRow = secondBurrowRow;
                                snakeCol = secondBurrowCol;

                                territory[snakeRow, snakeCol] = 'S';
                            }
                            else
                            {
                                territory[secondBurrowRow, secondBurrowCol] = '.';

                                snakeRow = firstBurrowRow;
                                snakeCol = firstBurrowCol;

                                territory[snakeRow, snakeCol] = 'S';
                            }
                        }
                        else
                        {
                            territory[snakeRow, snakeCol] = 'S';
                        }
                    }
                    else
                    {
                        haveLeft = true;
                        break;
                    }
                }
                else if (cmd == "down")
                {
                    snakeRow++;

                    if (AreValidIndexes(territory, snakeRow, snakeCol))
                    {
                        if (territory[snakeRow, snakeCol] == '*')
                        {
                            foodQuantity++;
                            territory[snakeRow, snakeCol] = 'S';
                        }
                        else if (territory[snakeRow, snakeCol] == 'B')
                        {
                            if (snakeRow == firstBurrowRow && snakeCol == firstBurrowCol)
                            {
                                territory[firstBurrowRow, firstBurrowCol] = '.';

                                snakeRow = secondBurrowRow;
                                snakeCol = secondBurrowCol;

                                territory[snakeRow, snakeCol] = 'S';
                            }
                            else
                            {
                                territory[secondBurrowRow, secondBurrowCol] = '.';

                                snakeRow = firstBurrowRow;
                                snakeCol = firstBurrowCol;

                                territory[snakeRow, snakeCol] = 'S';
                            }
                        }
                        else
                        {
                            territory[snakeRow, snakeCol] = 'S';
                        }
                    }
                    else
                    {
                        haveLeft = true;
                        break;
                    }
                }
                else if (cmd == "left")
                {
                    snakeCol--;

                    if (AreValidIndexes(territory, snakeRow, snakeCol))
                    {
                        if (territory[snakeRow, snakeCol] == '*')
                        {
                            foodQuantity++;
                            territory[snakeRow, snakeCol] = 'S';
                        }
                        else if (territory[snakeRow, snakeCol] == 'B')
                        {
                            if (snakeRow == firstBurrowRow && snakeCol == firstBurrowCol)
                            {
                                territory[firstBurrowRow, firstBurrowCol] = '.';

                                snakeRow = secondBurrowRow;
                                snakeCol = secondBurrowCol;

                                territory[snakeRow, snakeCol] = 'S';
                            }
                            else
                            {
                                territory[secondBurrowRow, secondBurrowCol] = '.';

                                snakeRow = firstBurrowRow;
                                snakeCol = firstBurrowCol;

                                territory[snakeRow, snakeCol] = 'S';
                            }
                        }
                        else
                        {
                            territory[snakeRow, snakeCol] = 'S';
                        }
                    }
                    else
                    {
                        haveLeft = true;
                        break;
                    }
                }
                else if (cmd == "right")
                {
                    snakeCol++;

                    if (AreValidIndexes(territory, snakeRow, snakeCol))
                    {
                        if (territory[snakeRow, snakeCol] == '*')
                        {
                            foodQuantity++;
                            territory[snakeRow, snakeCol] = 'S';
                        }
                        else if (territory[snakeRow, snakeCol] == 'B')
                        {
                            if (snakeRow == firstBurrowRow && snakeCol == firstBurrowCol)
                            {
                                territory[firstBurrowRow, firstBurrowCol] = '.';

                                snakeRow = secondBurrowRow;
                                snakeCol = secondBurrowCol;

                                territory[snakeRow, snakeCol] = 'S';
                            }
                            else
                            {
                                territory[secondBurrowRow, secondBurrowCol] = '.';

                                snakeRow = firstBurrowRow;
                                snakeCol = firstBurrowCol;

                                territory[snakeRow, snakeCol] = 'S';
                            }
                        }
                        else
                        {
                            territory[snakeRow, snakeCol] = 'S';
                        }
                    }
                    else
                    {
                        haveLeft = true;
                        break;
                    }
                }

                if (foodQuantity >= 10)
                {
                    break;
                }

                cmd = Console.ReadLine();
            }

            if (haveLeft)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(territory[i, j]);
                }

                Console.WriteLine();
            }
        }
        private static bool AreValidIndexes(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
