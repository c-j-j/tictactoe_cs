using System;
using System.IO;
using NUnit.Framework;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class ConsoleDisplayTests
    {
        ConsoleDisplay display;
        StringWriter stringWriter;

        [SetUp]
        public void Setup()
        {
            display = new ConsoleDisplay();
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
        }

        [TearDown] public void TearDown()
        {
            stringWriter.Dispose();
        }

        [Test]
        public void PrintsErrorMessage()
        {
            display.PrintInvalidMoveError();
            Assert.That(stringWriter.ToString(), Is.StringContaining(ConsoleDisplay.INVALID_MOVE_ERROR));
        }

        [Test]
        public void PrintsDrawnOutcome()
        {
            display.PrintDrawnOutcome();
            Assert.That(stringWriter.ToString(), Is.StringContaining(ConsoleDisplay.DRAWN_MESSAGE));
        }

        [Test]
        public void PrintsWinOutcome()
        {
            display.PrintWinOutcome(Mark.X);
            Assert.That(stringWriter.ToString(), Is.StringContaining(String.Format(ConsoleDisplay.WINNER_MESSAGE, Mark.X)));
        }

        [Test]
        public void PrintsNextPlayer()
        {
            display.PrintNextPlayer(Mark.X);
            Assert.That(stringWriter.ToString(), Is.StringContaining(String.Format(ConsoleDisplay.NEXT_PLAYER_MESSAGE, Mark.X)));
        }

        [Test]
        public void PrintsBoard()
        {
            var board = new Board();
            board.AddMove(new Move(Mark.X, 0));
            board.AddMove(new Move(Mark.O, 4));
            display.PrintBoard(board);
            Assert.That(stringWriter.ToString(), Contains.Substring( "X | 2 | 3"));
            Assert.That(stringWriter.ToString(), Contains.Substring( "4 | O | 6"));
            Assert.That(stringWriter.ToString(), Contains.Substring( "7 | 8 | 9"));
        }
    }
}
