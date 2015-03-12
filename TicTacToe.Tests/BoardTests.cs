using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class BoardTests
    {
        private Board board;

        [SetUp]
        public void Setup()
        {
            board = new Board();
        }

        [Test]
        public void EmptyBoardContainsEmptyValues()
        {
          Assert.AreEqual(board.GetMarkAtPosition(0), Mark.EMPTY);
        }

        [Test]
        public void AddsMoveToBoard()
        {
            board.AddMove(Mark.X, 0);
            Assert.AreEqual(board.GetMarkAtPosition(0), Mark.X);
        }

        [Test]
        public void GetsAllLinesFromBoard()
        {
            for (int i = 0; i < Board.LINE_POSITIONS.Length; i++)
            {
                Board b = new Board();
                b.AddMove(Mark.O, Board.LINE_POSITIONS[i][0]);
                b.AddMove(Mark.O, Board.LINE_POSITIONS[i][1]);
                b.AddMove(Mark.O, Board.LINE_POSITIONS[i][2]);
                Assert.That(b.GetLines(), Contains.Item(new Board.Line(Mark.O, Mark.O, Mark.O)));
            }
        }

        [Test]
        public void GetsAvailablePositions()
        {
            board.AddMove(Mark.X, 0);
            List<int> positions = board.GetAvailablePositions();
            Assert.AreEqual(8, positions.Count);
            CollectionAssert.DoesNotContain( positions, 0);
        }
    }
}
