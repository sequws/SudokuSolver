using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SudokuSolver.Tests
{
    
    public class SolverTest
    {
        [Fact]
        public void IsSquareBoard_BadBoard_False()
        {
            //Arrange
            int[,] badBoard =
            {
                {0,0,1,1 },
                {0,2,3,4 }
            };
            //Act
            Solver solver = new Solver();
            var res = solver.IsSquareBoard(badBoard);

            //Assert
            Assert.False(res);
        }

        [Fact]
        public void IsSquareBoard_Board4x4_True()
        {
            //Arrange
            int[,] badBoard =
            {
                {0,0,1,1 },
                {0,2,3,4 },
                {0,2,3,4 },
                {0,2,3,4 },
            };
            //Act
            Solver solver = new Solver();
            var res = solver.IsSquareBoard(badBoard);

            //Assert
            Assert.True(res);
        }
    }
}
