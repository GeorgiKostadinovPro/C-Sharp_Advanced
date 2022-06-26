using System;

namespace _02_WallDestroyer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] wall = new char[n, n];

            int vankoRow = 0;
            int vankoCol = 0;
            bool gotElectrocuted = false;
            int holesCount = 1;
            int hitRodes = 0;

            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();

                for (int j = 0; j < row.Length; j++)
                {
                    wall[i, j] = row[j];

                    if (wall[i, j] == 'V')
                    {
                        vankoRow = i;
                        vankoCol = j;
                    }
                }
            }

            string cmd = string.Empty;

            while ((cmd = Console.ReadLine()) != "End")
            {
                if (cmd == "up")
                {
                    if (vankoRow - 1 < 0)
                    {
                        continue;
                    }
                    
                    if (wall[vankoRow - 1, vankoCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow - 1}, {vankoCol}]!");
                        holesCount--;
                    }

                    if (wall[vankoRow - 1, vankoCol] == 'R')
                    {
                        hitRodes++;
                        Console.WriteLine("Vanko hit a rod!");
                        continue;
                    }

                    wall[vankoRow, vankoCol] = '*';
                    holesCount++;

                    if (wall[vankoRow - 1, vankoCol] == 'C')
                    {
                        wall[vankoRow - 1, vankoCol] = 'E';
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
                        for (int i = 0; i < wall.GetLength(0); i++)
                        {
                            for (int j = 0; j < wall.GetLength(1); j++)
                            {
                                Console.Write(wall[i, j]);
                            }

                            Console.WriteLine();
                        }
                        return;
                    }

                    wall[vankoRow - 1, vankoCol] = 'V';
                    vankoRow--;
                }
                else if (cmd == "down")
                {
                     if (vankoRow + 1 >= wall.GetLength(0))
                     {
                         continue;
                     }
                    
                     if (wall[vankoRow + 1, vankoCol] == '*')
                     {
                         Console.WriteLine($"The wall is already destroyed at position [{vankoRow + 1}, {vankoCol}]!");
                         holesCount--;
                     }

                     if (wall[vankoRow + 1, vankoCol] == 'R')
                     {
                         hitRodes++;
                         Console.WriteLine("Vanko hit a rod!");
                         continue;
                     }

                     wall[vankoRow, vankoCol] = '*';
                     holesCount++;

                     if (wall[vankoRow + 1, vankoCol] == 'C')
                     {
                         wall[vankoRow + 1, vankoCol] = 'E';
                         Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
                         for (int i = 0; i < wall.GetLength(0); i++)
                         {
                             for (int j = 0; j < wall.GetLength(1); j++)
                             {
                                 Console.Write(wall[i, j]);
                             }

                             Console.WriteLine();
                         }
                         return;
                     }

                     wall[vankoRow + 1, vankoCol] = 'V';
                     vankoRow++;
                }
                else if (cmd == "left")
                {
                    if (vankoCol - 1 < 0)
                    {
                        continue;
                    } 
                    
                    if (wall[vankoRow, vankoCol - 1] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol - 1}]!");
                        holesCount--;
                    }

                    if (wall[vankoRow, vankoCol - 1] == 'R')
                    {
                        hitRodes++;
                        Console.WriteLine("Vanko hit a rod!");
                        continue;
                    }

                    wall[vankoRow, vankoCol] = '*';
                    holesCount++;

                    if (wall[vankoRow, vankoCol - 1] == 'C')
                    {
                        wall[vankoRow, vankoCol - 1] = 'E';
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
                        for (int i = 0; i < wall.GetLength(0); i++)
                        {
                            for (int j = 0; j < wall.GetLength(1); j++)
                            {
                                Console.Write(wall[i, j]);
                            }

                            Console.WriteLine();
                        }
                        return;
                    }

                    wall[vankoRow, vankoCol - 1] = 'V';
                    vankoCol--;
                }
                else if (cmd == "right")
                {
                    if (vankoCol + 1 >= wall.GetLength(1))
                    {
                        continue;
                    }
                    
                    if (wall[vankoRow, vankoCol + 1] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol + 1}]!");
                        holesCount--;
                    }

                    if (wall[vankoRow, vankoCol + 1] == 'R')
                    {
                        hitRodes++;
                        Console.WriteLine("Vanko hit a rod!");
                        continue;
                    }

                    wall[vankoRow, vankoCol] = '*';
                    holesCount++;

                    if (wall[vankoRow, vankoCol + 1] == 'C')
                    {
                        wall[vankoRow, vankoCol + 1] = 'E';
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
                        for (int i = 0; i < wall.GetLength(0); i++)
                        {
                            for (int j = 0; j < wall.GetLength(1); j++)
                            {
                                Console.Write(wall[i, j]);
                            }

                            Console.WriteLine();
                        }
                        return;
                    }

                    wall[vankoRow, vankoCol + 1] = 'V';
                    vankoCol++;
                }
            }

            Console.WriteLine($"Vanko managed to make {holesCount} hole(s) and he hit only {hitRodes} rod(s).");

            for (int i = 0; i < wall.GetLength(0); i++)
            {
                for (int j = 0; j < wall.GetLength(1); j++)
                {
                    Console.Write(wall[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
