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
        #region IsSquareBoard
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

        [Fact]
        public void IsSquareBoard_Board5x5_True()
        {
            //Arrange
            int[,] badBoard =
            {
                {0,0,1,1,0 },
                {0,2,3,4,0 },
                {0,2,3,4,0 },
                {0,2,3,4,0 },
                {0,2,3,4,0 }
            };
            //Act
            Solver solver = new Solver();
            var res = solver.IsSquareBoard(badBoard);

            //Assert
            Assert.True(res);
        }
        #endregion

        #region IsValidBoard
        [Fact]
        public void IsValidBoard_Board4x4_True()
        {
            //Arrange
            int[,] badBoard =
            {
                {0,0,1,1 },
                {0,2,3,4 },
                {0,2,3,4 },
                {0,2,3,4 }
            };
            //Act
            Solver solver = new Solver();
            var res = solver.IsValidBoard(badBoard);

            //Assert
            Assert.True(res);
        }

        [Fact]
        public void IsValidBoard_Board5x5_False()
        {
            //Arrange
            int[,] badBoard =
            {
                {0,0,1,1,0 },
                {0,2,3,4,0 },
                {0,2,3,4,0 },
                {0,2,3,4,0 },
                {0,2,3,4,0 }
            };
            //Act
            Solver solver = new Solver();
            var res = solver.IsValidBoard(badBoard);

            //Assert
            Assert.False(res);
        }

        [Theory]
        [InlineData(1,false)]
        [InlineData(2,false)]
        [InlineData(3,false)]
        [InlineData(4,true)]
        [InlineData(5,false)]
        [InlineData(9,true)]
        [InlineData(16,true)]
        [InlineData(20,false)]
        [InlineData(25, true)]
        [InlineData(36, true)]
        public void IsValidBoard_Multitest(int size, bool expected)
        {
            //Arrange
            int[,] badBoard = new int[size, size];

            //Act
            Solver solver = new Solver();
            var res = solver.IsValidBoard(badBoard);

            //Assert
            Assert.Equal(expected,res );
        }
        #endregion
    }
}
