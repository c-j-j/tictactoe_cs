using NUnit.Framework;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class HumanPlayerTests
    {
        StubDisplay display;
        StubInput input;
        HumanPlayer humanPlayer;
        Game game;

        [SetUp]
        public void Setup()
        {
            display = new StubDisplay();
            input = new StubInput();
            game = TestGameFactory.NewGame();
            humanPlayer = new HumanPlayer(Mark.O, display, input);
        }

        [Test]
        public void HumanPlayerAlwaysReady()
        {
            Assert.AreEqual(true, humanPlayer.Ready());
        }

        [Test]
        public void GetsMoveFromUserInterface()
        {
            input.PrepareUserPositions(0);
            var move = humanPlayer.GetMove(game);
            Assert.AreEqual(Mark.O, move.Mark);
            Assert.AreEqual(0, move.Position);
        }

        [Test]
        public void DoesNotReturnInvalidMove()
        {
            input.PrepareUserPositions(-1, 0);
            humanPlayer.GetMove(game);
            Assert.IsTrue(display.PrintInvalidMoveMessageCalled());
        }

        [Test]
        public void FactoryBuildsPlayer()
        {
            Player player = new HumanPlayer.Factory(new StubDisplay(), new StubInput()).Build(Mark.X, Mark.O);
            Assert.AreEqual(player.Mark, Mark.X);
        }
    }
}
