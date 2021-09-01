using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class BoardHelper
    {
        public static int[,] ConvertToBoard(string boardStr, int size)
        {
            if (string.IsNullOrWhiteSpace(boardStr)) return new int[0, 0];

            int[,] board = new int[size, size];
            var elems = boardStr.Split( new char[0], StringSplitOptions.RemoveEmptyEntries).ToList();

            if (elems.Count != size * size) return new int[0,0];
                        
            for (int i = 0; i < elems.Count; i++)
            {
                board[i / size, i % size] = int.Parse( elems.ElementAt(i));
            }

            return board;
        }

        public static int[,] ConvertStrToBoard(string boardStr)
        {
            if (string.IsNullOrWhiteSpace(boardStr)) return new int[0, 0];
            var elems = boardStr.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToList();

            int size = (int)Math.Sqrt(elems.Count);
            if (size < 4) return new int[0, 0];

            if (size != Math.Floor(Math.Sqrt(elems.Count))) return new int[0, 0];

            int[,] board = new int[size, size];
            for (int i = 0; i < elems.Count; i++)
            {
                board[ i / size, i % size] = int.Parse(elems.ElementAt(i));
            }

            return board;
        }

        public static bool IsValidBoard(int[,] board)
        {
            if (board.GetLength(0) != board.GetLength(1))
            {
                return false;
            }
            return true;
        }

        public static void PrintBoard(int[,] board)
        {
            if (!IsValidBoard(board))
            {
                Console.WriteLine("This is not a valid sudoku board!");
                return;
            }

            int size = board.GetLength(0);
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    Console.Write($"{board[r, c]} ");
                }
                Console.WriteLine();
            }
        }

        public static void PrintBoardBeauty(int[,] board)
        {

            if (!IsValidBoard(board)) {
                    Console.WriteLine("This is not a valid sudoku board!");
                    return;
            }

            int size = board.GetLength(0);
            int childSize = (int)Math.Sqrt(size);

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    Console.Write($"{board[r, c]} ");
                    if ((c + 1) % childSize == 0) Console.Write(" ");
                }
                Console.WriteLine();
                if ((r + 1) % childSize == 0) Console.WriteLine();
            }
        }
    }
}
