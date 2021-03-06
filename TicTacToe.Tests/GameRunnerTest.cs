using NUnit.Framework;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class GameRunnerTests
    {

        StubDisplay stubInterface;

        [SetUp]
        public void Setup()
        {
            stubInterface = new StubDisplay();
        }

        [Test]
        public void PrintsDrawOutcome()
        {
            var game = TestGameFactory.DrawnGame();
            var gameDriver = new GameRunner(game, stubInterface);
            gameDriver.Run();
            Assert.IsTrue(stubInterface.PrintDrawOutcomeCalled());
        }

        [Test]
        public void PrintsWinningOutcome()
        {
            var game = TestGameFactory.WonGame(Mark.X);
            var gameDriver = new GameRunner(game, stubInterface);
            gameDriver.Run();
            Assert.IsTrue(stubInterface.PrintWinOutcomeCalled(Mark.X));
        }

        [Test]
        public void PrintsBoardDuringGameplay()
        {
            var game = TestGameFactory.OneTurnGame();
            var gameDriver = new GameRunner(game, stubInterface);
            gameDriver.Run();
            Assert.IsTrue(stubInterface.PrintBoardCalled());
        }

        [Test]
        public void PrintsOutNextPlayerToGoWhenNextPlayerIsntReady()
        {
            var game = TestGameFactory.GameWhereNextPlayerIsntReady();
            var gameDriver = new GameRunner(game, stubInterface);
            gameDriver.Run();
            Assert.IsTrue(stubInterface.PrintNextPlayerCalled());
        }

        [Test]
        public void PrintsNextPlayerToGoDuringGameplay()
        {
            var game = TestGameFactory.OneTurnGame();
            var gameDriver = new GameRunner(game, stubInterface);
            gameDriver.Run();
            Assert.IsTrue(stubInterface.PrintNextPlayerCalled());
        }
    }
}
