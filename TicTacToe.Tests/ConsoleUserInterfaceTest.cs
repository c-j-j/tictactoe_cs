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
            Assert.AreEqual(1 - ConsoleUserInterface.INPUT_OFFSET, position);
        }

        [Test]
        public void ConvertsNonIntegerInputToMinusInteger()
        {
            Console.SetIn(new StringReader("a"));
            var position = userInterface.GetUserPosition();
            Assert.AreEqual(0 - ConsoleUserInterface.INPUT_OFFSET, position);
        }

        [Test]
        public void PrintsErrorMessage()
        {
            userInterface.PrintInvalidMoveError();
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
            Assert.That(stringWriter.ToString(), Contains.Substring( "X | 2 | 3"));
            Assert.That(stringWriter.ToString(), Contains.Substring( "4 | O | 6"));
            Assert.That(stringWriter.ToString(), Contains.Substring( "7 | 8 | 9"));
        }

        [Test]
        public void ReturnsOnlyPlayerTypeThatWasProvided()
        {
            Console.SetIn(new StringReader("1"));
            Assert.AreEqual(userInterface.GetPlayerType(Mark.X, new []{"somePlayerType"}), "somePlayerType");
        }

        [Test]
        public void DisplaysAllOptionsToUser()
        {
            var options = new []{"somePlayerType"};
            Console.SetIn(new StringReader("1"));
            userInterface.GetPlayerType(Mark.X, options);
            Assert.That(stringWriter.ToString(),
                    Is.StringContaining(String.Format(ConsoleUserInterface.SELECT_PLAYER_MESSAGE, Mark.X)));
            Assert.That(stringWriter.ToString(), Is.StringContaining(options[0]));
        }

        [Test]
        public void KeepsAskingForInputFromUserUntilValidInputGiven()
        {
            var options = new []{"somePlayerType"};
            Console.SetIn(new StringReader("0\n2\n1"));
            Assert.AreEqual("somePlayerType",userInterface.GetPlayerType(Mark.X, options));
        }
    }
}
