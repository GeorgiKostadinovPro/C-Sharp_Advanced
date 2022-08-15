using System;
using System.Linq;

namespace _02_TruffleHunter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] forest = new char[size, size];

            int blackTrufflesCount = 0;
            int summerTrufflesCount = 0;
            int whiteTrufflesCount = 0;

            int boarTruffles = 0;

            for (int i = 0; i < size; i++)
            {
                char[] row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < row.Length; j++)
                {
                    forest[i, j] = row[j];
                }
            }

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "Stop the hunt")
            {
                string[] cmdArgs = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmd = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);

                if (cmd == "Collect")
                {

                    if (forest[row, col] == 'B')
                    {
                        blackTrufflesCount++;
                        forest[row, col] = '-';
                    }
                    else if (forest[row, col] == 'S')
                    {
                        summerTrufflesCount++;
                        forest[row, col] = '-';
                    }
                    else if (forest[row, col] == 'W')
                    {
                        whiteTrufflesCount++;
                        forest[row, col] = '-';
                    }
                }
                else if (cmd == "Wild_Boar")
                {
                    string direction = cmdArgs[3];

                    if (direction == "up")
                    {
                        while (row >= 0)
                        {
                            if (forest[row, col] == 'B' || forest[row, col] == 'S' || forest[row, col] == 'W')
                            {
                                boarTruffles++;
                            }

                            forest[row, col] = '-';
                            row -= 2;
                        }
                    }
                    else if (direction == "down")
                    {
                        while (row < size)
                        {
                            if (forest[row, col] == 'B' || forest[row, col] == 'S' || forest[row, col] == 'W')
                            {
                                boarTruffles++;
                            }

                            forest[row, col] = '-';
                            row += 2;
                        }
                    }
                    else if (direction == "left")
                    {
                        while (col >= 0)
                        {
                            if (forest[row, col] == 'B' || forest[row, col] == 'S' || forest[row, col] == 'W')
                            {
                                boarTruffles++;
                            }

                            forest[row, col] = '-';
                            col -= 2;
                        }
                    }
                    else if (direction == "right")
                    {
                        while (col < size)
                        {
                            if (forest[row, col] == 'B' || forest[row, col] == 'S' || forest[row, col] == 'W')
                            {
                                boarTruffles++;
                            }

                            forest[row, col] = '-';
                            col += 2;
                        }
                    }
                }
            }

            Console.WriteLine($"Peter manages to harvest {blackTrufflesCount} black, {summerTrufflesCount} summer, and {whiteTrufflesCount} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarTruffles} truffles.");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(forest[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
