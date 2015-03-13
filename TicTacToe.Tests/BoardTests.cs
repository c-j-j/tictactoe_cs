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
			AddMoveToBoard (board, Mark.X, 0);
            Assert.AreEqual(board.GetMarkAtPosition(0), Mark.X);
        }

        [Test]
        public void GetsAllLinesFromBoard()
        {
            for (int i = 0; i < Board.LINE_POSITIONS.Length; i++)
            {
                Board b = new Board();
				AddMoveToBoard (b, Mark.O, Board.LINE_POSITIONS[i][0]);
				AddMoveToBoard (b, Mark.O, Board.LINE_POSITIONS[i][1]);
				AddMoveToBoard (b, Mark.O, Board.LINE_POSITIONS[i][2]);
                Assert.That(b.GetLines(), Contains.Item(new Board.Line(Mark.O, Mark.O, Mark.O)));
            }
        }

        [Test]
        public void GetsAvailablePositions()
        {
			AddMoveToBoard (board, Mark.X, 0);
            List<int> positions = board.GetAvailablePositions();
            Assert.AreEqual(8, positions.Count);
            CollectionAssert.DoesNotContain( positions, 0);
        }

        [Test]
        public void LineIsNotAllEqualWhenTheItContainsEmptyMarks()
        {
            var line = new Board.Line(Mark.EMPTY, Mark.EMPTY, Mark.EMPTY);
            Assert.IsFalse(line.ContainSameMark());
        }

        [Test]
        public void LineIsAllEqualWhenItContainsTheSameElement()
        {
            var line = new Board.Line(Mark.X, Mark.X, Mark.X);
            Assert.IsTrue(line.ContainSameMark());
        }

		void AddMoveToBoard (Board b, Mark mark, int position)
		{
			b.AddMove (new Move (mark, position));
		}
    }
}
