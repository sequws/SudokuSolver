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
            SolveSudoku(SampleSudoku.board9x9Easy);
            SolveSudoku(SampleSudoku.board9x9Easy_2);
            SolveSudoku(SampleSudoku.board9x9empty);            
            SolveSudoku(SampleSudoku.board9x9bad);

            Console.WriteLine("Finish");
            Console.ReadLine();
        }

        static void SolveSudoku(int[,] board)
        {
            Solver solver = new Solver();

            Console.WriteLine("Solving: ");
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
