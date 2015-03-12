using NUnit.Framework;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class GameTests
    {
        StubPlayer player1;
        StubPlayer player2;
        Board board;
        Game game;

        [SetUp]
        public void Setup()
        {
            player1 = new StubPlayer();
            player2 = new StubPlayer();
            board = new Board();
			game = new Game(board, player1, player2);
        }

        [Test]
        public void Player1AddedToEmptyBoardDuringTurn()
        {
            player1.PrepareMove(0);
            game.PlayTurn();
            Assert.AreEqual(player1.Mark, board.GetMarkAtPosition(player1.GetMove()));
        }

        [Test]
        public void Player2MoveAddedToBoardDuringTurn()
        {
			board.AddMove (Mark.O, 0);
            player2.PrepareMove(1);
            game.PlayTurn();
            Assert.AreEqual(player2.Mark, board.GetMarkAtPosition(player2.GetMove()));
        }

		[Test]
		public void GameNotWonWhenBoardIsEmpty()
		{
			Assert.IsFalse (game.HasBeenWon ());
		}

		[Test]
		public void GameWonWhenABoardLineIsOccupied()
		{
			board.AddMove (Mark.O, 0);
			board.AddMove (Mark.O, 1);
			board.AddMove (Mark.O, 2);
			Assert.IsTrue (game.HasBeenWon ());
		}


    }
}
