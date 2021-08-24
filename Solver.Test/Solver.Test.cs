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

        #region IsInRow
        [Fact]
        public void IsInRow_NoNumberInRow_False()
        {
            //Arrange
            int[,] badBoard =
            {
                {0,0,1,3 },
                {0,2,3,4 },
                {0,2,3,4 },
                {0,2,3,4 }
            };
            //Act
            Solver solver = new Solver();
            var res = solver.IsInRow(badBoard, 0, 2);

            //Assert
            Assert.False(res);
        }

        [Fact]
        public void IsInRow_NumberInRow_True()
        {
            //Arrange
            int[,] badBoard =
            {
                {0,0,1,3 },
                {0,2,3,4 },
                {0,2,3,4 },
                {0,2,3,4 }
            };
            //Act
            Solver solver = new Solver();
            var res = solver.IsInRow(badBoard, 1, 2);

            //Assert
            Assert.True(res);
        }
        #endregion

        #region IsInColumn
        [Fact]
        public void IsInColum_NumberInColumn_True()
        {
            //Arrange
            int[,] badBoard =
            {
                {0,0,1,3 },
                {0,2,3,4 },
                {0,0,0,4 },
                {0,3,0,1 }
            };
            //Act
            Solver solver = new Solver();
            var res = solver.IsInColumn(badBoard, 1, 2);

            //Assert
            Assert.True(res);
        }

        [Fact]
        public void IsInColum_NoNumberInColumn_False()
        {
            //Arrange
            int[,] badBoard =
            {
                {0,0,1,3 },
                {0,2,3,4 },
                {0,0,0,4 },
                {0,3,0,1 }
            };
            //Act
            Solver solver = new Solver();
            var res = solver.IsInColumn(badBoard, 2, 4);

            //Assert
            Assert.False(res);
        }

        #endregion

        #region IsInChildSquare
        [Fact]
        public void IsInChildSquare_NumberInSquare_True()
        {
            //Arrange
            int[,] badBoard =
            {
                {0,0,0,4 },
                {0,1,0,0 },
                {0,0,3,0 },
                {0,0,0,2 }
            };
            //Act
            Solver solver = new Solver();
            var res = solver.IsInChildSquare(badBoard, 0,0, 1);

            //Assert
            Assert.True(res);
        }

        [Fact]
        public void IsInChildSquare_NoNumberInSquare_False()
        {
            //Arrange
            int[,] badBoard =
            {
                {0,0,0,4 },
                {0,1,0,0 },
                {0,0,3,0 },
                {0,0,0,2 }
            };
            //Act
            Solver solver = new Solver();
            var res = solver.IsInChildSquare(badBoard, 2, 2, 4);

            //Assert
            Assert.False(res);
        }

        [Theory]
        [InlineData(0,0,1,true)]
        [InlineData(0,0,2,false)]
        [InlineData(0,0,3,false)]
        [InlineData(2,2,3,true)]
        [InlineData(2,2,4,false)]
        [InlineData(1,2,4,true)]
        [InlineData(1,2,3,false)]
        public void IsInChildSquare_Multitest(int row,int col, int nr, bool expected)
        {
            int[,] badBoard =
{
                {0,0,0,4 },
                {0,1,0,0 },
                {0,0,3,0 },
                {0,0,0,2 }
            };

            Solver solver = new Solver();
            var res = solver.IsInChildSquare(badBoard, row, col, nr);

            Assert.Equal(expected, res);
        }
        #endregion
    }
}