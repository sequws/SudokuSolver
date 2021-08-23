using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] boardEasy =
            {
                {2,0,5,0,0,9,0,0,4},
                {0,0,0,0,0,0,3,0,7},
                {7,0,0,8,5,6,0,1,0},
                {4,5,0,7,0,0,0,0,0},
                {0,0,9,0,0,0,1,0,0},
                {0,0,0,0,0,2,0,8,5},
                {0,2,0,4,1,8,0,0,6},
                {6,0,8,0,0,0,0,0,0},
                {1,9,0,2,0,0,7,0,8}
            };

            int[,] boarBad =
            {
                {2,3,0,0,0 },
                {0,1,0,0,0 }
            };

            PrintBoard(boardEasy);
            PrintBoard(boarBad);

            Console.ReadLine();
        }


        static void PrintBoard(int[,] board)
        {
            if(board.GetLength(0) != board.GetLength(1))
            {
                Console.WriteLine("This is not a valid sudoku board!");
                return;
            }

            int size = board.GetLength(0);
            for(int r =0; r< size; r++)
            {
                for(int c=0; c< size; c++)
                {
                    Console.Write( $"{board[r,c]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
