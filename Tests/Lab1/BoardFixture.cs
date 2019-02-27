using Model;
using NUnit.Framework;
using System;

namespace Tests.Lab1
{
    [TestFixture]
    public class BoardFixture
    {
        private Board board;

        [SetUp]
        public void SetUp()
        {
            board = Board.Singleton;
        }

        [Test]
        public void BoardClassIsSingleton()
        {
            // Arrange
            var anotherBoard = Board.Singleton;

            // Assert
            Assert.AreSame(board, anotherBoard, "Board objects are different. Board is not a singleton.");
        }

        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void BoardSetUpArrangeBoardInWinStrategy(int size)
        {
            // Arrange
            var expectedPosition = size - 1;

            // Act
            SetUpBoard(size);
            var (x, y) = board.BlankPosition;

            // Assert
            Assert.AreEqual(expectedPosition, x, "Blank box in the board is not the last position.");
            Assert.AreEqual(expectedPosition, y, "Blank box in the board is not the last position.");
        }

        [TestCase(2)]
        [TestCase(6)]
        [TestCase(int.MinValue)]
        public void BoardThrowsExceptionForInvalidSize(int size)
        {
            // Assert
            Assert.Throws<InvalidOperationException>(() => SetUpBoard(size),
                "SetUpBoard method does not throw exception.");
        }

        [TestCase(4, 4)]
        [TestCase(-1, -1)]
        [TestCase(int.MinValue, int.MaxValue)]
        public void BoardWontThrowExceptionForOutOfBoundariesIndexes(int x, int y)
        {
            // Arrange
            var expected = -1;
            SetUpBoard(3);

            // Act
            var actual = board.GetItem(x, y);

            // Assert
            Assert.AreEqual(expected, actual, $"We expect recieve -1. But the result is {actual}");
        }

        private void SetUpBoard(int size)
        {
            board.SetSize(size);
            board.SetWinPosition();
        }
    }
}