using NUnit.Framework;

namespace TicTacToe.Tests
{
	[TestFixture]
	public class HumanPlayerTests
	{
        StubInterface userInterface;
        HumanPlayer humanPlayer;
        Game game;

        [SetUp]
        public void Setup(){
            userInterface = new StubInterface();
            game = TestGameFactory.NewGame();
            humanPlayer = new HumanPlayer(Mark.O, userInterface);
        }

		[Test]
		public void GetsMoveFromUserInterface ()
		{
            userInterface.PrepareUserPositions(0);
            var move = humanPlayer.GetMove (game);
			Assert.AreEqual (Mark.O, move.Mark);
			Assert.AreEqual (0, move.Position);
		}

        [Test]
        public void DoesNotReturnInvalidMove()
        {
            userInterface.PrepareUserPositions(-1, 0);
            humanPlayer.GetMove(game);
            Assert.IsTrue(userInterface.PrintErrorMessageCalled());
        }
	}
}
