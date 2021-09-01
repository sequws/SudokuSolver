using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Solving built-in examples...");
                SolveSamples();
            }
            else
            {
                if(File.Exists(args[0]))
                {
                    Console.WriteLine("Solving from file...");
                    SolveSudoku(BoardHelper.ConvertStrToBoard(File.ReadAllText(args[0])));
                }
                else
                {
                    Console.WriteLine("Wrong path to file");
                }
            }

            Console.WriteLine("Finish");
            Console.ReadLine();
        }

        private static void SolveSamples()
        {
            SolveSudoku(SampleSudoku.board9x9Easy);
            SolveSudoku(SampleSudoku.board9x9Easy_2);
            SolveSudoku(SampleSudoku.board9x9empty);
            SolveSudoku(SampleSudoku.board9x9bad);
            SolveSudoku(BoardHelper.ConvertToBoard(SampleSudoku.boardInLine16x16, 16));
        }

        static void SolveSudoku(int[,] board)
        {
            Solver solver = new Solver();

            Console.WriteLine("\nSolving: ");
            BoardHelper.PrintBoardBeauty(board);
            solver.Solve(board);

            if (solver.SolutionList.Count > 0)
            {
                int i = 1;
                foreach (var solution in solver.SolutionList)
                {
                    Console.WriteLine($"Soultion {i}:");
                    BoardHelper.PrintBoard(solution);
                    i++;
                }
            }
            else
            {
                Console.WriteLine("No solution found!");
            }
        }
    }
}
