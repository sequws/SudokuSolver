using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SudokuSolver.Tests
{
    public class BoardHelperTest
    {
        [Fact]
        public void ConvertStrToBoard_Board2x2IsTooSmall_True()
        {
            //Arrange
            string boardStr = "0 0 1 2";
            //Act
            var res = BoardHelper.ConvertStrToBoard(boardStr);           
            // Assert
            int[,] expect = new int[0, 0];
            Assert.True( res.Cast<int>().SequenceEqual(expect.Cast<int>()));
        }

        [Fact]
        public void ConvertStrToBoard_Board3x3IsTooSmall_True()
        {
            string boardStr = "0 0 1   0 0 0  3 4 0";

            var res = BoardHelper.ConvertStrToBoard(boardStr);
            int[,] expect = new int[0, 0];

            Assert.True(res.Cast<int>().SequenceEqual(expect.Cast<int>()));
        }

        [Fact]
        public void ConvertStrToBoard_WrongLength_False()
        {
            string boardStr = "0 0 1   0 0 0  3 4 0  0 1 2";

            var res = BoardHelper.ConvertStrToBoard(boardStr);
            int[,] expect = new int[0, 0];

            Assert.True(res.Cast<int>().SequenceEqual(expect.Cast<int>()));
        }

        [Fact]
        public void ConvertStrToBoard_Board4x4_True()
        {
            string boardStr = "0 0 1 2  0 0 0 0  3 4 0 0  0 0 0 0";

            var res = BoardHelper.ConvertStrToBoard(boardStr);
            int[,] expect = {
               {0, 0, 1, 2},
               {0, 0, 0, 0 },
               {3, 4, 0, 0 },
               {0, 0, 0, 0 }
            };

            Assert.True(res.Cast<int>().SequenceEqual(expect.Cast<int>()));
        }
    }
}

