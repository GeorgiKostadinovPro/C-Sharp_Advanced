using System;

namespace _02_Bee
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] territory = new char[n, n];

            int beeRow = 0;
            int beeCol = 0;
            int pollinatedFlowers = 0;
            bool isOut = false;

            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();

                for (int j = 0; j < row.Length; j++)
                {
                    territory[i, j] = row[j];

                    if (territory[i, j] == 'B')
                    {
                        beeRow = i;
                        beeCol = j;
                    }
                }
            }

            string cmd = Console.ReadLine();

            while (cmd != "End")
            {
                territory[beeRow, beeCol] = '.';

                if (cmd == "up")
                {
                    beeRow--;

                    if (AreValidIndexes(territory, beeRow, beeCol))
                    {
                        if (territory[beeRow, beeCol] == 'f')
                        {
                            territory[beeRow, beeCol] = 'B';
                            pollinatedFlowers++;
                        }
                        else if (territory[beeRow, beeCol] == 'O')
                        {
                            territory[beeRow, beeCol] = '.';
                            beeRow--;

                            if (AreValidIndexes(territory, beeRow, beeCol))
                            {
                                if (territory[beeRow, beeCol] == 'f')
                                {
                                    pollinatedFlowers++;
                                }

                                territory[beeRow, beeCol] = 'B';
                            }
                            else
                            {
                                isOut = true;
                                break;
                            }
                        }
                        else
                        {
                            territory[beeRow, beeCol] = 'B';
                        }
                    }
                    else
                    {
                        isOut = true;
                        break;
                    }
                }
                else if (cmd == "down")
                {
                    beeRow++;

                    if (AreValidIndexes(territory, beeRow, beeCol))
                    {
                        if (territory[beeRow, beeCol] == 'f')
                        {
                            territory[beeRow, beeCol] = 'B';
                            pollinatedFlowers++;
                        }
                        else if (territory[beeRow, beeCol] == 'O')
                        {
                            territory[beeRow, beeCol] = '.';
                            beeRow++;

                            if (AreValidIndexes(territory, beeRow, beeCol))
                            {
                                if (territory[beeRow, beeCol] == 'f')
                                {
                                    pollinatedFlowers++;
                                }

                                territory[beeRow, beeCol] = 'B';
                            }
                            else
                            {
                                isOut = true;
                                break;
                            }
                        }
                        else
                        {
                            territory[beeRow, beeCol] = 'B';
                        }
                    }
                    else
                    {
                        isOut = true;
                        break;
                    }
                }
                else if (cmd == "left")
                {
                    beeCol--;

                    if (AreValidIndexes(territory, beeRow, beeCol))
                    {
                        if (territory[beeRow, beeCol] == 'f')
                        {
                            territory[beeRow, beeCol] = 'B';
                            pollinatedFlowers++;
                        }
                        else if (territory[beeRow, beeCol] == 'O')
                        {
                            territory[beeRow, beeCol] = '.';
                            beeCol--;

                            if (AreValidIndexes(territory, beeRow, beeCol))
                            {
                                if (territory[beeRow, beeCol] == 'f')
                                {
                                    pollinatedFlowers++;
                                }

                                territory[beeRow, beeCol] = 'B';
                            }
                            else
                            {
                                isOut = true;
                                break;
                            }
                        }
                        else
                        {
                            territory[beeRow, beeCol] = 'B';
                        }
                    }
                    else
                    {
                        isOut = true;
                        break;
                    }
                }
                else if (cmd == "right")
                {
                    beeCol++;

                    if (AreValidIndexes(territory, beeRow, beeCol))
                    {
                        if (territory[beeRow, beeCol] == 'f')
                        {
                            territory[beeRow, beeCol] = 'B';
                            pollinatedFlowers++;
                        }
                        else if (territory[beeRow, beeCol] == 'O')
                        {
                            territory[beeRow, beeCol] = '.';
                            beeCol++;

                            if (AreValidIndexes(territory, beeRow, beeCol))
                            {
                                if (territory[beeRow, beeCol] == 'f')
                                {
                                    pollinatedFlowers++;
                                }

                                territory[beeRow, beeCol] = 'B';
                            }
                            else
                            {
                                isOut = true;
                                break;
                            }
                        }
                        else
                        {
                            territory[beeRow, beeCol] = 'B';
                        }
                    }
                    else
                    {
                        isOut = true;
                        break;
                    }
                }

                cmd = Console.ReadLine();
            }

            if (isOut)
            {
                Console.WriteLine("The bee got lost!");
            }

            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }

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
