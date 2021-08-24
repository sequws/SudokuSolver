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

            int[,] boardEasy9x9 =
{
                {9,5,4,0,0,0,7,0,0 },
                {8,3,0,0,0,0,0,0,9 },
                {0,0,0,0,8,1,0,0,3 },
                {3,0,0,0,6,2,5,0,8 },
                {0,0,2,0,0,0,9,1,7 },
                {0,0,0,4,0,0,0,0,0 },
                {0,8,0,0,0,3,1,7,0 },
                {4,0,9,5,0,0,0,0,0 },
                {0,7,0,2,0,0,6,0,0 }

            };

            int[,] board4x4 =
{
                {3,2,1,4 },
                {4,0,2,0 },
                {1,4,3,2 },
                {2,3,4,1 }
            };

            int[,] board4x4_1 =
{
                {0,0,1,2 },
                {0,0,3,0 },
                {2,0,0,0 },
                {0,3,0,0 }
            };

            int[,] boarBad =
            {
                {2,3,0,0,0 },
                {0,1,0,0,0 }
            };

            BoardHelper.PrintBoardBeauty(board4x4_1);

            Solver solver = new Solver();
            solver.Solve(board4x4_1);

            if(solver.SolutionList.Count > 0)
            {
                Console.WriteLine("Solutions: ");
                int i = 0;
                foreach(var solution in solver.SolutionList)
                {
                    Console.WriteLine($"Soultion {i}:");
                    BoardHelper.PrintBoard(solution);
                    i++;
                }
            } else
            {
                Console.WriteLine("No solution found!");
            }

            Console.WriteLine("Finsh");

            //BoardHelper.PrintBoard(boardEasy);
            //BoardHelper.PrintBoardBeauty(boardEasy);
            //BoardHelper.PrintBoardBeauty(board4x4);
            //BoardHelper.PrintBoard(boarBad);

            Console.ReadLine();
        }

    }
}
