using System;

namespace _02_TheBattleOfTheFiveArmies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int armyArmor = int.Parse(Console.ReadLine());

            int rows = int.Parse(Console.ReadLine());

            char[][] middleEarth = new char[rows][];

            int armyRow = 0;
            int armyCol = 0;

            for (int i = 0; i < rows; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                middleEarth[i] = row;

                for (int j = 0; j < middleEarth[i].Length; j++)
                {
                    if (middleEarth[i][j] == 'A')
                    {
                        armyRow = i;
                        armyCol = j;
                    }
                }
            }

            while (true)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmd = cmdArgs[0];
                int orcsRow = int.Parse(cmdArgs[1]);
                int orcsCol = int.Parse(cmdArgs[2]);

                middleEarth[orcsRow][orcsCol] = 'O';

                if (cmd == "up")
                {
                    armyArmor--;

                    if (armyRow - 1 >= 0)
                    {
                        middleEarth[armyRow][armyCol] = '-';
                        armyRow--;

                        if (middleEarth[armyRow][armyCol] == 'O')
                        {
                            armyArmor -= 2;
                            middleEarth[armyRow][armyCol] = 'A';
                        }
                        else if (middleEarth[armyRow][armyCol] == '-')
                        {
                            middleEarth[armyRow][armyCol] = 'A';
                        }
                    }
                }
                else if (cmd == "down")
                {
                    armyArmor--;

                    if (armyRow + 1 < rows)
                    {
                        middleEarth[armyRow][armyCol] = '-';
                        armyRow++;

                        if (middleEarth[armyRow][armyCol] == 'O')
                        {
                            armyArmor -= 2;
                            middleEarth[armyRow][armyCol] = 'A';
                        }
                        else if (middleEarth[armyRow][armyCol] == '-')
                        {
                            middleEarth[armyRow][armyCol] = 'A';
                        }
                    }
                }
                else if (cmd == "left")
                {
                    armyArmor--;

                    if (armyCol - 1 >= 0)
                    {
                        middleEarth[armyRow][armyCol] = '-';
                        armyCol--;

                        if (middleEarth[armyRow][armyCol] == 'O')
                        {
                            armyArmor -= 2;
                            middleEarth[armyRow][armyCol] = 'A';
                        }
                        else if (middleEarth[armyRow][armyCol] == '-')
                        {
                            middleEarth[armyRow][armyCol] = 'A';
                        }
                    }
                }
                else if (cmd == "right")
                {
                    armyArmor--;

                    if (armyCol + 1 < middleEarth[armyRow].Length)
                    {
                        middleEarth[armyRow][armyCol] = '-';
                        armyCol++;

                        if (middleEarth[armyRow][armyCol] == 'O')
                        {
                            armyArmor -= 2;
                            middleEarth[armyRow][armyCol] = 'A';
                        }
                        else if (middleEarth[armyRow][armyCol] == '-')
                        {
                            middleEarth[armyRow][armyCol] = 'A';
                        }
                    }
                }

                if (middleEarth[armyRow][armyCol] == 'M')
                {
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
                    middleEarth[armyRow][armyCol] = '-';
                    break;
                }

                if (armyArmor <= 0)
                {
                    middleEarth[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    break;
                }
            }

            for (int i = 0; i < middleEarth.Length; i++)
            {
                Console.WriteLine(string.Join("", middleEarth[i]));
            }
        }
    }
}

