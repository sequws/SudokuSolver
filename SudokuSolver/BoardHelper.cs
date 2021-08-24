using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class BoardHelper
    {
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
            Console.WriteLine();
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
            Console.WriteLine();
        }
    }
}
