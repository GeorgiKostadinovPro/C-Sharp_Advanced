using System;
using System.Collections.Generic;

namespace _02_Armory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] armory = new char[size, size];

            int armyOfficerRow = 0;
            int armyOfficerCol = 0;

            int amount = 0;

            List<int> mirrorCoordinates = new List<int>();

            for (int i = 0; i < size; i++)
            {
                string row = Console.ReadLine();

                for (int j = 0; j < row.Length; j++)
                {
                    armory[i, j] = row[j];

                    if (armory[i, j] == 'A')
                    {
                        armyOfficerRow = i;
                        armyOfficerCol = j;
                    }
                    else if (armory[i, j] == 'M')
                    {
                        mirrorCoordinates.Add(i);
                        mirrorCoordinates.Add(j);
                    }
                }
            }

            int firstMirrorRow = 0;
            int firstMirrorCol = 0;

            int secondMirrorRow = 0;
            int secondMirrorCol = 0;

            if (mirrorCoordinates.Count > 0)
            {
                firstMirrorRow = mirrorCoordinates[0];
                firstMirrorCol = mirrorCoordinates[1];

                secondMirrorRow = mirrorCoordinates[2];
                secondMirrorCol = mirrorCoordinates[3];
            }

            bool collected65Price = false;
            bool isLeaving = false;

            string line = Console.ReadLine();

            while (true)
            {
                string cmd = line;

                if (cmd == "up")
                {
                    if (armyOfficerRow - 1 >= 0)
                    {
                        armory[armyOfficerRow, armyOfficerCol] = '-';
                        armyOfficerRow--;

                        if (char.IsDigit(armory[armyOfficerRow, armyOfficerCol]))
                        {
                            amount += armory[armyOfficerRow, armyOfficerCol] - '0';
                            armory[armyOfficerRow, armyOfficerCol] = 'A';
                        }
                        else if (armory[armyOfficerRow, armyOfficerCol] == 'M')
                        {
                            if (armyOfficerRow == firstMirrorRow && armyOfficerCol == firstMirrorCol)
                            {
                                armory[armyOfficerRow, armyOfficerCol] = '-';
                                armory[secondMirrorRow, secondMirrorCol] = 'A';

                                armyOfficerRow = secondMirrorRow;
                                armyOfficerCol = secondMirrorCol;
                            }
                            else if (armyOfficerRow == secondMirrorRow && armyOfficerCol == secondMirrorCol)
                            {
                                armory[armyOfficerRow, armyOfficerCol] = '-';
                                armory[firstMirrorRow, firstMirrorCol] = 'A';

                                armyOfficerRow = firstMirrorRow;
                                armyOfficerCol = firstMirrorCol;
                            }
                        }
                    }
                    else
                    {
                        armory[armyOfficerRow, armyOfficerCol] = '-';
                        isLeaving = true;
                        break;
                    }
                }
                else if (cmd == "down")
                {
                    if (armyOfficerRow + 1 < size)
                    {
                        armory[armyOfficerRow, armyOfficerCol] = '-';
                        armyOfficerRow++;

                        if (char.IsDigit(armory[armyOfficerRow, armyOfficerCol]))
                        {
                            amount += armory[armyOfficerRow, armyOfficerCol] - '0';
                            armory[armyOfficerRow, armyOfficerCol] = 'A';
                        }
                        else if (armory[armyOfficerRow, armyOfficerCol] == 'M')
                        {
                            if (armyOfficerRow == firstMirrorRow && armyOfficerCol == firstMirrorCol)
                            {
                                armory[armyOfficerRow, armyOfficerCol] = '-';
                                armory[secondMirrorRow, secondMirrorCol] = 'A';

                                armyOfficerRow = secondMirrorRow;
                                armyOfficerCol = secondMirrorCol;
                            }
                            else if (armyOfficerRow == secondMirrorRow && armyOfficerCol == secondMirrorCol)
                            {
                                armory[armyOfficerRow, armyOfficerCol] = '-';
                                armory[firstMirrorRow, firstMirrorCol] = 'A';

                                armyOfficerRow = firstMirrorRow;
                                armyOfficerCol = firstMirrorCol;
                            }
                        }
                    }
                    else
                    {
                        armory[armyOfficerRow, armyOfficerCol] = '-';
                        isLeaving = true;
                        break;
                    }
                }
                else if (cmd == "left")
                {
                    if (armyOfficerCol - 1 >= 0)
                    {
                        armory[armyOfficerRow, armyOfficerCol] = '-';
                        armyOfficerCol--;

                        if (char.IsDigit(armory[armyOfficerRow, armyOfficerCol]))
                        {
                            amount += armory[armyOfficerRow, armyOfficerCol] - '0';
                            armory[armyOfficerRow, armyOfficerCol] = 'A';
                        }
                        else if (armory[armyOfficerRow, armyOfficerCol] == 'M')
                        {
                            if (armyOfficerRow == firstMirrorRow && armyOfficerCol == firstMirrorCol)
                            {
                                armory[armyOfficerRow, armyOfficerCol] = '-';
                                armory[secondMirrorRow, secondMirrorCol] = 'A';

                                armyOfficerRow = secondMirrorRow;
                                armyOfficerCol = secondMirrorCol;
                            }
                            else if (armyOfficerRow == secondMirrorRow && armyOfficerCol == secondMirrorCol)
                            {
                                armory[armyOfficerRow, armyOfficerCol] = '-';
                                armory[firstMirrorRow, firstMirrorCol] = 'A';

                                armyOfficerRow = firstMirrorRow;
                                armyOfficerCol = firstMirrorCol;
                            }
                        }
                    }
                    else
                    {
                        armory[armyOfficerRow, armyOfficerCol] = '-';
                        isLeaving = true;
                        break;
                    }
                }
                else if (cmd == "right")
                {
                    if (armyOfficerCol + 1 < size)
                    {
                        armory[armyOfficerRow, armyOfficerCol] = '-';
                        armyOfficerCol++;

                        if (char.IsDigit(armory[armyOfficerRow, armyOfficerCol]))
                        {
                            amount += armory[armyOfficerRow, armyOfficerCol] - '0';
                            armory[armyOfficerRow, armyOfficerCol] = 'A';
                        }
                        else if (armory[armyOfficerRow, armyOfficerCol] == 'M')
                        {
                            if (armyOfficerRow == firstMirrorRow && armyOfficerCol == firstMirrorCol)
                            {
                                armory[armyOfficerRow, armyOfficerCol] = '-';
                                armory[secondMirrorRow, secondMirrorCol] = 'A';

                                armyOfficerRow = secondMirrorRow;
                                armyOfficerCol = secondMirrorCol;
                            }
                            else if (armyOfficerRow == secondMirrorRow && armyOfficerCol == secondMirrorCol)
                            {
                                armory[armyOfficerRow, armyOfficerCol] = '-';
                                armory[firstMirrorRow, firstMirrorCol] = 'A';

                                armyOfficerRow = firstMirrorRow;
                                armyOfficerCol = firstMirrorCol;
                            }
                        }
                    }
                    else
                    {
                        armory[armyOfficerRow, armyOfficerCol] = '-';
                        isLeaving = true;
                        break;
                    }
                }

                if (amount >= 65)
                {
                    collected65Price = true;
                    break;
                }

                line = Console.ReadLine();
            }

            if (isLeaving == true)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else if (collected65Price == true)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {amount} gold coins.");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(armory[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
