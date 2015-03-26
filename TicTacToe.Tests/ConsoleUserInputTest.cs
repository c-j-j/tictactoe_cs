
using System;
using System.IO;
using NUnit.Framework;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class ConsoleUserInputTests
    {
        ConsoleUserInput userInput;
        StringWriter stringWriter;

        [SetUp]
        public void Setup()
        {
            userInput = new ConsoleUserInput();
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
        }

        [TearDown]
        public void TearDown()
        {
            stringWriter.Dispose();
        }

        [Test]
        public void GetsUserPositionFromConsoleAndConvertsToZeroBasedIndex()
        {
            Console.SetIn(new StringReader("1"));
            var position = userInput.GetUserPosition();
            Assert.AreEqual(1 - ConsoleDisplay.INPUT_OFFSET, position);
        }

        [Test]
        public void ConvertsNonIntegerInputToMinusInteger()
        {
            Console.SetIn(new StringReader("a"));
            var position = userInput.GetUserPosition();
            Assert.AreEqual(0 - ConsoleDisplay.INPUT_OFFSET, position);
        }

        [Test]
        public void ReturnsOnlyPlayerTypeThatWasProvided()
        {
            Console.SetIn(new StringReader("1"));
            Assert.AreEqual(userInput.GetPlayerType(Mark.X, new []{ "somePlayerType" }), "somePlayerType");
        }

        [Test]
        public void DisplaysAllOptionsToUser()
        {
            var options = new []{ "somePlayerType" };
            Console.SetIn(new StringReader("1"));
            userInput.GetPlayerType(Mark.X, options);
            Assert.That(stringWriter.ToString(),
                Is.StringContaining(String.Format(ConsoleDisplay.SELECT_PLAYER_MESSAGE, Mark.X)));
            Assert.That(stringWriter.ToString(), Is.StringContaining(options[0]));
        }

        [Test]
        public void KeepsAskingForInputFromUserUntilValidInputGiven()
        {
            var options = new []{ "somePlayerType" };
            Console.SetIn(new StringReader("0\n2\n1"));
            Assert.AreEqual("somePlayerType", userInput.GetPlayerType(Mark.X, options));
        }
    }
}
