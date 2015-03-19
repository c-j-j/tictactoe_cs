using NUnit.Framework;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class ConsoleGameDriverTests
    {

        StubInterface stubInterface;

        [SetUp]
        public void Setup()
        {
            stubInterface = new StubInterface();
        }

        [Test]
        public void PrintsDrawOutcome()
        {
            var game = TestGameFactory.DrawnGame();
            var gameDriver = new GameDriver(game, stubInterface);
            gameDriver.Run();
            Assert.IsTrue(stubInterface.PrintDrawOutcomeCalled());
        }

        [Test]
        public void PrintsWinningOutcome()
        {
            var game = TestGameFactory.WonGame(Mark.X);
            var gameDriver = new GameDriver(game, stubInterface);
            gameDriver.Run();
            Assert.IsTrue(stubInterface.PrintWinOutcomeCalled(Mark.X));
        }

        [Test]
        public void PrintsBoardDuringGameplay()
        {
            var game = TestGameFactory.OneTurnGame();
            var gameDriver = new GameDriver(game, stubInterface);
            gameDriver.Run();
            Assert.IsTrue(stubInterface.PrintBoardCalled());
        }

        [Test]
        public void PrintsNextPlayerToGoDuringGameplay()
        {
            var game = TestGameFactory.OneTurnGame();
            var gameDriver = new GameDriver(game, stubInterface);
            gameDriver.Run();
            Assert.IsTrue(stubInterface.PrintNextPlayerCalled());
        }
    }
}
