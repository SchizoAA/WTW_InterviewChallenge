using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WTW_InterviewChallenge.Game;

namespace WTW_InterviewChallenge.Test
{
    [TestClass]
    public class TicTacToeTests
    {
        private TicTacToe gameboard_3x3 = new TicTacToe(3);
        private TicTacToe gameboard_4x4 = new TicTacToe(4);
        private TicTacToe gameboard_6x6 = new TicTacToe(6);
        private TicTacToe gameboard_12x12 = new TicTacToe(12);
        private TicTacToe gameboard_100x100 = new TicTacToe(100);

        [TestMethod]
        public void Test_TicTacToe_InvalidPlayer()
        {
            gameboard_3x3 = new TicTacToe(3);
            Assert.ThrowsException<InvalidOperationException>(() => gameboard_3x3.PlacePiece(0, 0, 3));
        }

        [TestMethod]
        public void Test_TicTacToe_RowOutOfRange()
        {
            gameboard_3x3 = new TicTacToe(3);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => gameboard_3x3.PlacePiece(5, 0, 1));
        }

        [TestMethod]
        public void Test_TicTacToe_ColumnOutOfRange()
        {
            gameboard_3x3 = new TicTacToe(3);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => gameboard_3x3.PlacePiece(0, 5, 1));
        }

        [TestMethod]
        public void Test_TicTacToe_InvalidMove()
        {
            gameboard_3x3 = new TicTacToe(3);
            gameboard_3x3.PlacePiece(0, 0, 1);
            Assert.ThrowsException<InvalidOperationException>(() => gameboard_3x3.PlacePiece(0, 0, 2),"A player has already claimed this space.");
        }

        [TestMethod]
        public void Test_TicTacToe_3x3_PlacePiece()
        {
            gameboard_3x3 = new TicTacToe(3);
            var result = gameboard_3x3.PlacePiece(2, 0, 1);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test_TicTacToe_3x3_P1Win_Vertical()
        {
            gameboard_3x3 = new TicTacToe(3);
            gameboard_3x3.PlacePiece(0, 0, 1);
            gameboard_3x3.PlacePiece(1, 0, 1);
            var result = gameboard_3x3.PlacePiece(2, 0, 1);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test_TicTacToe_3x3_P1Win_Horizontal()
        {
            gameboard_3x3 = new TicTacToe(3);
            gameboard_3x3.PlacePiece(0, 0, 1);
            gameboard_3x3.PlacePiece(0, 1, 1);
            var result = gameboard_3x3.PlacePiece(0, 2, 1);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test_TicTacToe_3x3_P1Win_Diagonal()
        {
            gameboard_3x3 = new TicTacToe(3);
            gameboard_3x3.PlacePiece(0, 0, 1);
            gameboard_3x3.PlacePiece(1, 1, 1);
            var result = gameboard_3x3.PlacePiece(2, 2, 1);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test_TicTacToe_3x3_P2Win_Vertical()
        {
            gameboard_3x3 = new TicTacToe(3);
            gameboard_3x3.PlacePiece(0, 0, 2);
            gameboard_3x3.PlacePiece(1, 0, 2);
            var result = gameboard_3x3.PlacePiece(2, 0, 2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_TicTacToe_3x3_P2Win_Horizontal()
        {
            gameboard_3x3 = new TicTacToe(3);
            gameboard_3x3.PlacePiece(0, 0, 2);
            gameboard_3x3.PlacePiece(0, 1, 2);
            var result = gameboard_3x3.PlacePiece(0, 2, 2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_TicTacToe_3x3_P2Win_Diagonal()
        {
            gameboard_3x3 = new TicTacToe(3);
            gameboard_3x3.PlacePiece(0, 0, 2);
            gameboard_3x3.PlacePiece(1, 1, 2);
            var result = gameboard_3x3.PlacePiece(2, 2, 2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_TicTacToe_3x3_P2Win_Simulated()
        {
            gameboard_3x3 = new TicTacToe(3);
            gameboard_3x3.PlacePiece(0, 1, 1);
            gameboard_3x3.PlacePiece(2, 0, 2);
            gameboard_3x3.PlacePiece(0, 0, 1);
            gameboard_3x3.PlacePiece(0, 2, 2);
            gameboard_3x3.PlacePiece(1, 0, 1);
            var result = gameboard_3x3.PlacePiece(1, 1, 2);
            Assert.AreEqual(2, result);
            Assert.ThrowsException<InvalidOperationException>(() => gameboard_3x3.PlacePiece(2, 1, 1), "The game has concluded.");
        }

        [TestMethod]
        public void Test_TicTacToe_4x4_P1Win_Simulated()
        {
            gameboard_4x4 = new TicTacToe(4);
            gameboard_4x4.PlacePiece(0, 1, 1);
            gameboard_4x4.PlacePiece(2, 0, 2);
            gameboard_4x4.PlacePiece(0, 0, 1);
            gameboard_4x4.PlacePiece(2, 1, 2);
            gameboard_4x4.PlacePiece(0, 3, 1);
            gameboard_4x4.PlacePiece(1, 1, 2);
            int result = gameboard_4x4.PlacePiece(0, 2, 1);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test_TicTacToe_4x4_TieGame()
        {
            gameboard_4x4 = new TicTacToe(4);
            gameboard_4x4.PlacePiece(0, 0, 1);
            gameboard_4x4.PlacePiece(0, 1, 2);
            gameboard_4x4.PlacePiece(0, 2, 1);
            gameboard_4x4.PlacePiece(1, 2, 2);
            gameboard_4x4.PlacePiece(1, 0, 1);
            gameboard_4x4.PlacePiece(1, 1, 2);
            gameboard_4x4.PlacePiece(2, 2, 1);
            gameboard_4x4.PlacePiece(2, 0, 2);
            int result = gameboard_4x4.PlacePiece(2, 1, 1);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test_TicTacToe_4x4_P1Win_Diagonal()
        {
            gameboard_4x4 = new TicTacToe(4);
            gameboard_4x4.PlacePiece(0, 0, 1);
            gameboard_4x4.PlacePiece(1, 1, 1);
            gameboard_4x4.PlacePiece(2, 2, 1);
            int result = gameboard_4x4.PlacePiece(3, 3, 1);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test_TicTacToe_6x6_P1Win()
        {
            gameboard_6x6 = new TicTacToe(6);
            gameboard_6x6.PlacePiece(0, 0, 1);
            gameboard_6x6.PlacePiece(0, 1, 1);
            gameboard_6x6.PlacePiece(0, 2, 1);
            gameboard_6x6.PlacePiece(0, 3, 1);
            gameboard_6x6.PlacePiece(0, 4, 1);
            var result = gameboard_6x6.PlacePiece(0, 5, 1);
            Assert.AreEqual(1, result);
            Assert.ThrowsException<InvalidOperationException>(() => gameboard_6x6.PlacePiece(2, 1, 1), "The game has concluded.");
        }

        [TestMethod]
        public void Test_TicTacToe_12x12_P2Win()
        {
            gameboard_12x12 = new TicTacToe(12);
            gameboard_12x12.PlacePiece(0, 0, 2);
            gameboard_12x12.PlacePiece(1, 1, 2);
            gameboard_12x12.PlacePiece(2, 2, 2);
            gameboard_12x12.PlacePiece(3, 3, 2);
            gameboard_12x12.PlacePiece(4, 4, 2);
            gameboard_12x12.PlacePiece(5, 5, 2);
            gameboard_12x12.PlacePiece(6, 6, 2);
            gameboard_12x12.PlacePiece(7, 7, 2);
            gameboard_12x12.PlacePiece(8, 8, 2);
            gameboard_12x12.PlacePiece(9, 9, 2);
            gameboard_12x12.PlacePiece(10, 10, 2);
            var result = gameboard_12x12.PlacePiece(11, 11, 2);
            Assert.AreEqual(2, result);
            Assert.ThrowsException<InvalidOperationException>(() => gameboard_12x12.PlacePiece(2, 1, 1), "The game has concluded.");
        }

        [TestMethod]
        public void Test_TicTacToe_100x100_P1Win()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            gameboard_100x100 = new TicTacToe(100);
            for( int i = 0; i < 99; i++ )
            {
                gameboard_100x100.PlacePiece(i, 0, 1);
            }
            var result = gameboard_100x100.PlacePiece(99, 0, 1);
            watch.Stop();

            Assert.IsTrue(watch.ElapsedMilliseconds <= 1000);
            Assert.AreEqual(1, result);
            Assert.ThrowsException<InvalidOperationException>(() => gameboard_100x100.PlacePiece(2, 1, 1), "The game has concluded.");
        }
    }
}
