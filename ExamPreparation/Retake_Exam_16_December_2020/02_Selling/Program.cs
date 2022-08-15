using System;
using System.Collections.Generic;

namespace _02_Selling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] bakery = new char[size, size];

            List<int> pillarCoordiantes = new List<int>();

            int bakerRow = 0;
            int bakerCol = 0;

            int dollarsToCollect = 0;

            for (int i = 0; i < size; i++)
            {
                string row = Console.ReadLine();

                for (int j = 0; j < row.Length; j++)
                {
                    bakery[i, j] = row[j];

                    if (bakery[i, j] == 'S')
                    {
                        bakerRow = i;
                        bakerCol = j;
                    }
                    else if (bakery[i, j] == 'O')
                    {
                        pillarCoordiantes.Add(i);
                        pillarCoordiantes.Add(j);
                    }
                }
            }

            int firstPillarRow = 0;
            int firstPillarCol = 0;
            int secondPillarRow = 0;
            int secondPillarCol = 0;


            if (pillarCoordiantes.Count > 0)
            {
                firstPillarRow = pillarCoordiantes[0];
                firstPillarCol = pillarCoordiantes[1];
                secondPillarRow = pillarCoordiantes[2];
                secondPillarCol = pillarCoordiantes[3];
            }

            bool isOutOfBakery = false;

            while (true)
            {
                string cmd = Console.ReadLine();

                bakery[bakerRow, bakerCol] = '-';

                if (cmd == "up")
                {
                    bakerRow--;

                    if (bakerRow >= 0)
                    {
                        if (IsDigit(bakery, bakerRow, bakerCol))
                        {
                            dollarsToCollect += bakery[bakerRow, bakerCol] - '0';
                            bakery[bakerRow, bakerCol] = 'S';
                        }
                        else if (IsPillar(bakery, bakerRow, bakerCol))
                        {
                            if (bakerRow == firstPillarRow && bakerCol == firstPillarCol)
                            {
                                bakery[bakerRow, bakerCol] = '-';
                                bakery[secondPillarRow, secondPillarCol] = 'S';

                                bakerRow = secondPillarRow;
                                bakerCol = secondPillarCol;
                            }
                            else
                            {
                                bakery[bakerRow, bakerCol] = '-';
                                bakery[firstPillarRow, firstPillarCol] = 'S';

                                bakerRow = firstPillarRow;
                                bakerCol = firstPillarCol;
                            }
                        }
                        else
                        {
                            bakery[bakerRow, bakerCol] = 'S';
                        }
                    }
                    else
                    {
                        isOutOfBakery = true;
                        break;
                    }
                }
                else if (cmd == "down")
                {
                    bakerRow++;

                    if (bakerRow < size)
                    {
                        if (IsDigit(bakery, bakerRow, bakerCol))
                        {
                            dollarsToCollect += bakery[bakerRow, bakerCol] - '0';
                            bakery[bakerRow, bakerCol] = 'S';
                        }
                        else if (IsPillar(bakery, bakerRow, bakerCol))
                        {
                            if (bakerRow == firstPillarRow && bakerCol == firstPillarCol)
                            {
                                bakery[bakerRow, bakerCol] = '-';
                                bakery[secondPillarRow, secondPillarCol] = 'S';

                                bakerRow = secondPillarRow;
                                bakerCol = secondPillarCol;
                            }
                            else
                            {
                                bakery[bakerRow, bakerCol] = '-';
                                bakery[firstPillarRow, firstPillarCol] = 'S';

                                bakerRow = firstPillarRow;
                                bakerCol = firstPillarCol;
                            }
                        }
                        else
                        {
                            bakery[bakerRow, bakerCol] = 'S';
                        }
                    }
                    else
                    {
                        isOutOfBakery = true;
                        break;
                    }
                }
                else if (cmd == "left")
                {
                    bakerCol--;

                    if (bakerCol >= 0)
                    {
                        if (IsDigit(bakery, bakerRow, bakerCol))
                        {
                            dollarsToCollect += bakery[bakerRow, bakerCol] - '0';
                            bakery[bakerRow, bakerCol] = 'S';
                        }
                        else if (IsPillar(bakery, bakerRow, bakerCol))
                        {
                            if (bakerRow == firstPillarRow && bakerCol == firstPillarCol)
                            {
                                bakery[bakerRow, bakerCol] = '-';
                                bakery[secondPillarRow, secondPillarCol] = 'S';

                                bakerRow = secondPillarRow;
                                bakerCol = secondPillarCol;
                            }
                            else
                            {
                                bakery[bakerRow, bakerCol] = '-';
                                bakery[firstPillarRow, firstPillarCol] = 'S';

                                bakerRow = firstPillarRow;
                                bakerCol = firstPillarCol;
                            }
                        }
                        else
                        {
                            bakery[bakerRow, bakerCol] = 'S';
                        }
                    }
                    else
                    {
                        isOutOfBakery = true;
                        break;
                    }
                }
                else if (cmd == "right")
                {
                    bakerCol++;

                    if (bakerCol < size)
                    {
                        if (IsDigit(bakery, bakerRow, bakerCol))
                        {
                            dollarsToCollect += bakery[bakerRow, bakerCol] - '0';
                            bakery[bakerRow, bakerCol] = 'S';
                        }
                        else if (IsPillar(bakery, bakerRow, bakerCol))
                        {
                            if (bakerRow == firstPillarRow && bakerCol == firstPillarCol)
                            {
                                bakery[bakerRow, bakerCol] = '-';
                                bakery[secondPillarRow, secondPillarCol] = 'S';

                                bakerRow = secondPillarRow;
                                bakerCol = secondPillarCol;
                            }
                            else
                            {
                                bakery[bakerRow, bakerCol] = '-';
                                bakery[firstPillarRow, firstPillarCol] = 'S';

                                bakerRow = firstPillarRow;
                                bakerCol = firstPillarCol;
                            }
                        }
                        else
                        {
                            bakery[bakerRow, bakerCol] = 'S';
                        }
                    }
                    else
                    {
                        isOutOfBakery = true;
                        break;
                    }
                }

                if (dollarsToCollect >= 50)
                {
                    break;
                }
            }

            if (isOutOfBakery)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {dollarsToCollect}");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(bakery[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static bool IsPillar(char[,] bakery, int bakerRow, int bakerCol)
        {
            return bakery[bakerRow, bakerCol] == 'O';
        }

        private static bool IsDigit(char[,] bakery, int bakerRow, int bakerCol)
        {
            return char.IsDigit(bakery[bakerRow, bakerCol]);
        }
    }
}
