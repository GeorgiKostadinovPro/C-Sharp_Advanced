using System;
using System.Linq;

namespace _02_SuperMario
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            char[][] maze = new char[size][];

            int marioRow = 0;
            int marioCol = 0;

            for (int i = 0; i < size; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();

                maze[i] = row;

                for (int j = 0; j < maze[i].Length; j++)
                {
                    if (maze[i][j] == 'M')
                    {
                        marioRow = i;
                        marioCol = j;
                    }
                }
            }

            while (true)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmd = cmdArgs[0];
                int bowserRow = int.Parse(cmdArgs[1]);
                int bowserCol = int.Parse(cmdArgs[2]);

                int marioPrevRow = marioRow;
                int marioPrevCol = marioCol;

                maze[bowserRow][bowserCol] = 'B';

                if (cmd == "W")
                {
                    if (marioRow - 1 >= 0)
                    {
                        marioRow--;
                        if (maze[marioRow][marioCol] == 'B')
                        {
                            marioLives -= 2;
                            maze[marioRow][marioCol] = 'M';
                        }
                    }

                    marioLives--;
                }
                else if (cmd == "S")
                {
                    if (marioRow + 1 < size)
                    {
                        marioRow++;
                        if (maze[marioRow][marioCol] == 'B')
                        {
                            marioLives -= 2;
                            maze[marioRow][marioCol] = 'M';
                        }
                    }

                    marioLives--;
                }
                else if (cmd == "A")
                {
                    if (marioCol - 1 >= 0)
                    {
                        marioCol--;
                        if (maze[marioRow][marioCol] == 'B')
                        {
                            marioLives -= 2;
                            maze[marioRow][marioCol] = 'M';
                        }
                    }

                    marioLives--;
                }
                else if (cmd == "D")
                {
                    if (marioCol + 1 < maze[marioRow].Length)
                    {
                        marioCol++;
                        if (maze[marioRow][marioCol] == 'B')
                        {
                            marioLives -= 2;
                            maze[marioRow][marioCol] = 'M';
                        }
                    }

                    marioLives--;
                }

                maze[marioPrevRow][marioPrevCol] = '-';

                if (marioLives <= 0)
                {
                    maze[marioRow][marioCol] = 'X';
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    break;
                }

                if (maze[marioRow][marioCol] == 'P')
                {
                    maze[marioRow][marioCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
                    break;
                }
            }

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(string.Join("", maze[i]));
            }
        }
    }
}
