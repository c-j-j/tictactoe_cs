using System;
using System.IO;
using NUnit.Framework;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class ConsoleUserInterfaceTests
    {
        ConsoleUserInterface userInterface;
        StringWriter stringWriter;

        [SetUp]
        public void Setup()
        {
            userInterface = new ConsoleUserInterface();
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
        }

        [TearDown] public void TearDown()
        {
            stringWriter.Dispose();
        }

        [Test]
        public void GetsUserPositionFromConsoleAndConvertsToZeroBasedIndex()
        {
            Console.SetIn(new StringReader("1"));
            var position = userInterface.GetUserPosition();
            Assert.AreEqual(1 - ConsoleUserInterface.CELL_OFFSET, position);
        }

        [Test]
        public void ConvertsNonIntegerInputToMinusInteger()
        {
            Console.SetIn(new StringReader("a"));
            var position = userInterface.GetUserPosition();
            Assert.AreEqual(0 - ConsoleUserInterface.CELL_OFFSET, position);
        }

        [Test]
        public void PrintsErrorMessage()
        {
            userInterface.PrintErrorMessage();
            Assert.That(stringWriter.ToString(), Is.StringContaining(ConsoleUserInterface.INVALID_MOVE_ERROR));
        }

        [Test]
        public void PrintsDrawnOutcome()
        {
            userInterface.PrintDrawnOutcome();
            Assert.That(stringWriter.ToString(), Is.StringContaining(ConsoleUserInterface.DRAWN_MESSAGE));
        }

        [Test]
        public void PrintsWinOutcome()
        {
            userInterface.PrintWinOutcome(Mark.X);
            Assert.That(stringWriter.ToString(), Is.StringContaining(String.Format(ConsoleUserInterface.WINNER_MESSAGE, Mark.X)));
        }

        [Test]
        public void PrintsNextPlayer()
        {
            userInterface.PrintNextPlayer(Mark.X);
            Assert.That(stringWriter.ToString(), Is.StringContaining(String.Format(ConsoleUserInterface.NEXT_PLAYER_MESSAGE, Mark.X)));
        }

        [Test]
        public void PrintsBoard()
        {
            var board = new Board();
            board.AddMove(new Move(Mark.X, 0));
            board.AddMove(new Move(Mark.O, 4));
            userInterface.PrintBoard(board);
            Assert.That(stringWriter.ToString(), Contains.Substring(String.Format(ConsoleUserInterface.CELL_FORMAT, Mark.X)));
            Assert.That(stringWriter.ToString(), Contains.Substring(String.Format(ConsoleUserInterface.CELL_FORMAT, Mark.O)));
        }
    }
}
