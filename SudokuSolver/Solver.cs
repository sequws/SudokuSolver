using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Solver
    {
        public List<int[,]> SolutionList => solutionList;
        List<int[,]> solutionList = new List<int[,]>();
        bool isSolved = false;

        public Solver()  {}

        public bool Solve(int[,] board)
        {
            if (!IsValidBoard(board)) return false;
            var size = board.GetLength(0);

            //BoardHelper.PrintBoardBeauty(board);
            //Console.ReadLine();

            for (int r =0; r < size; r++)
            {
                for( int c=0; c < size; c++)
                {
                    for( int nr = 1; nr <= size; nr++)
                    {
                        // only one solution
                        if (isSolved) return true; 

                        if (board[r, c] == 0)
                        {
                            if(!IsInRow(board,r,nr) 
                                && !IsInColumn(board,c,nr)
                                && !IsInChildSquare(board,r,c,nr))
                            {
                                board[r, c] = nr;

                                if (CheckSolution(board))
                                {
                                    int[,] solution = board.Clone() as int[,];
                                    solutionList.Add(solution);
                                    isSolved = true;
                                    return true;
                                }
                                else
                                {
                                    Solve(board.Clone() as int[,]);
                                }
                            }
                        }                        
                    }
                }
            }                      

            return true;
        }

        public bool CheckSolution(int[,] board)
        {
            for (int y = 0; y < board.GetLength(0); y++)
            {
                for (int x = 0; x < board.GetLength(0); x++)
                {
                    if (board[y, x] == 0) return false;
                }
            }

            return true;
        }

        public bool IsInRow(int[,] board, int row, int nr)
        {
            for(int i =0; i < board.GetLength(0); i++)
            {
                if (board[row, i] == nr) return true;
            }
            return false;
        }

        public bool IsInColumn(int[,] board, int col, int nr)
        {
            for(int i =0; i < board.GetLength(0); i++)
            {
                if (board[i, col] == nr) return true;
            }
            return false;
        }

        public bool IsInChildSquare(int[,] board, int row, int col,int nr)
        {
            int size = board.GetLength(0);
            int childSize = (int)Math.Sqrt(size);

            int childX = (col) / childSize;
            int childY = (row) / childSize;

            for(int r = 0; r < childSize; r ++)
            {
                for( int c = 0; c < childSize; c++)
                {
                    if( board[ childY*childSize + r, childX*childSize +c] == nr)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsSquareBoard(int[,] board)
        {
            if (board.GetLength(0) != board.GetLength(1))
            {
                return false;
            }

            return true;
        }

        public bool IsValidBoard(int[,] board)
        {
            var size = board.GetLength(0);
            if (size < 4) return false;
            if (!IsSquareBoard(board)) return false;     
            
            return Math.Sqrt(size) == Math.Floor(Math.Sqrt(size));
        }
    }
}
