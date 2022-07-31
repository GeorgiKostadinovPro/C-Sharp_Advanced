using System;
using System.Linq;

namespace _09_Miner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            char[,] field = new char[size, size];

            int minerRow = 0;
            int minerCol = 0;

            int coalsStarterPack = 0;

            for (int i = 0; i < size; i++)
            {
                char[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < rowData.Length; j++)
                {
                    field[i, j] = rowData[j];

                    if (field[i, j] == 's')
                    {
                        minerRow = i;
                        minerCol = j;
                    }
                    else if (field[i, j] == 'c')
                    {
                        coalsStarterPack++;
                    }
                }
            }

            foreach (var command in commands)
            {
                if (command == "up")
                {
                    if (minerRow - 1 < 0)
                    {
                        continue;
                    }

                    field[minerRow, minerCol] = '*';
                    minerRow--;

                    if (field[minerRow, minerCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                        return;
                    }

                    if (field[minerRow, minerCol] == 'c')
                    {
                        coalsStarterPack--;
                    }

                    field[minerRow, minerCol] = 's';
                }
                else if (command == "down")
                {
                    if (minerRow + 1 >= size)
                    {
                        continue;
                    }

                    field[minerRow, minerCol] = '*';
                    minerRow++;

                    if (field[minerRow, minerCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                        return;
                    }

                    if (field[minerRow, minerCol] == 'c')
                    {
                        coalsStarterPack--;
                    }

                    field[minerRow, minerCol] = 's';
                }
                else if (command == "left")
                {
                    if (minerCol - 1 < 0)
                    {
                        continue;
                    }

                    field[minerRow, minerCol] = '*';
                    minerCol--;

                    if (field[minerRow, minerCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                        return;
                    }

                    if (field[minerRow, minerCol] == 'c')
                    {
                        coalsStarterPack--;
                    }

                    field[minerRow, minerCol] = 's';
                }
                else if (command == "right")
                {
                    if (minerCol + 1 >= size)
                    {
                        continue;
                    }

                    field[minerRow, minerCol] = '*';
                    minerCol++;

                    if (field[minerRow, minerCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                        return;
                    }

                    if (field[minerRow, minerCol] == 'c')
                    {
                        coalsStarterPack--;
                    }

                    field[minerRow, minerCol] = 's';
                }

                if (coalsStarterPack <= 0)
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                    break;
                }
            }
            
            if (coalsStarterPack > 0)
            {
                Console.WriteLine($"{coalsStarterPack} coals left. ({minerRow}, {minerCol})");
            }
        }
    }
}