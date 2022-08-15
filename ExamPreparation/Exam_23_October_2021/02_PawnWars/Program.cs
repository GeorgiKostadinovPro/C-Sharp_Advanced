using System;

namespace _02_PawnWars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            char[,] chessBoard = new char[8, 8];

            int whitePawnRow = 0;
            int whitePawnCol = 0;

            int blackPawnRow = 0;
            int blackPawnCol = 0;

            string[,] chessTemplateBoard = new string[8, 8]
            {
                { "a8","b8","c8","d8","e8","f8","g8","h8" },
                { "a7","b7","c7","d7","e7","f7","g7","h7" },
                { "a6","b6","c6","d6","e6","f6","g6","h6" },
                { "a5","b5","c5","d5","e5","f5","g5","h5" },
                { "a4","b4","c4","d4","e4","f4","g4","h4" },
                { "a3","b3","c3","d3","e3","f3","g3","h3" },
                { "a2","b2","c2","d2","e2","f2","g2","h2" },
                { "a1","b1","c1","d1","e1","f1","g1","h1" },

            };

            for (int i = 0; i < chessBoard.GetLength(0); i++)
            {
                string row = Console.ReadLine();

                for (int j = 0; j < row.Length; j++)
                {
                    chessBoard[i, j] = row[j];

                    if (chessBoard[i, j] == 'w')
                    {
                        whitePawnRow = i;
                        whitePawnCol = j;
                    }
                    else if (chessBoard[i, j] == 'b')
                    {
                        blackPawnRow = i;
                        blackPawnCol = j;
                    }
                }
            }

            while (true)
            {
                if (whitePawnRow - 1 >= 0 && whitePawnCol - 1 >= 0 && chessBoard[whitePawnRow - 1, whitePawnCol - 1] == 'b')
                {
                    Console.WriteLine($"Game over! White capture on {chessTemplateBoard[whitePawnRow - 1, whitePawnCol - 1]}.");
                    break;
                }
                else if (whitePawnRow - 1 >= 0 && whitePawnCol + 1 < chessBoard.GetLength(0) && chessBoard[whitePawnRow - 1, whitePawnCol + 1] == 'b')
                {
                    Console.WriteLine($"Game over! White capture on {chessTemplateBoard[whitePawnRow - 1, whitePawnCol + 1]}.");
                    break;
                }

                if (whitePawnRow - 1 >= 0)
                {
                    chessBoard[whitePawnRow, whitePawnCol] = '-';
                    whitePawnRow--;
                    chessBoard[whitePawnRow, whitePawnCol] = 'w';

                }

                if (whitePawnRow == 0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {chessTemplateBoard[whitePawnRow, whitePawnCol]}.");
                    break;
                }

                if (blackPawnRow + 1 < chessBoard.GetLength(0) && blackPawnCol - 1 >= 0 && chessBoard[blackPawnRow + 1, blackPawnCol - 1] == 'w')
                {
                    Console.WriteLine($"Game over! Black capture on {chessTemplateBoard[blackPawnRow + 1, blackPawnCol - 1]}.");
                    break;
                }
                else if (blackPawnRow + 1 < chessBoard.GetLength(0) && blackPawnCol + 1 < chessBoard.GetLength(0) && chessBoard[blackPawnRow + 1, blackPawnCol + 1] == 'w')
                {
                    Console.WriteLine($"Game over! Black capture on {chessTemplateBoard[blackPawnRow + 1, blackPawnCol + 1]}.");
                    break;
                }

                if (blackPawnRow + 1 < chessBoard.GetLength(0))
                {
                    chessBoard[blackPawnRow, blackPawnCol] = '-';
                    blackPawnRow++;
                    chessBoard[blackPawnRow, blackPawnCol] = 'b';
                }

                if (blackPawnRow == chessBoard.GetLength(0) - 1)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {chessTemplateBoard[blackPawnRow, blackPawnCol]}.");
                    break;
                }
            }

        }
    }
}
