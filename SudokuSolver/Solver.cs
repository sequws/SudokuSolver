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

        public Solver()  {}


        public bool IsSquareBoard(int[,] board)
        {
            if (board.GetLength(0) != board.GetLength(1))
            {
                return false;
            }

            return true;
        }
    }
}
