using System;
using System.IO;
using NUnit.Framework;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class ConsoleUserInterfaceTests
    {
        [Test]
        public void GetsUserPositionFromConsole()
        {
            Console.SetIn(new StringReader("1"));
            var position = new ConsoleUserInterface().GetUserPosition();
            Assert.AreEqual(1, position);
        }

        [Test]
        public void PrintsErrorMessageToConsole()
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                new ConsoleUserInterface().PrintErrorMessage();
                Assert.AreEqual(ConsoleUserInterface.ERROR_MESSAGE, stringWriter.ToString());
            }
        }
    }
}
