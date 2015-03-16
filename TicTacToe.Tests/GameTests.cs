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
            Assert.AreEqual(player1.Mark, board.GetMarkAtPosition(player1.NextMove));
        }

        [Test]
        public void Player2MoveAddedToBoardDuringTurn()
        {
            AddMoveToBoard(Mark.O, 0);
            player2.PrepareMove(1);
            game.PlayTurn();
            Assert.AreEqual(player2.Mark, board.GetMarkAtPosition(player2.NextMove));
        }

        [Test]
        public void GameNotWonWhenBoardIsEmpty()
        {
            Assert.IsFalse(game.HasBeenWon());
        }

        [Test]
        public void GameWonWhenABoardLineIsOccupied()
        {
            AddMoveToBoard(Mark.O, 3);
            AddMoveToBoard(Mark.O, 4);
            AddMoveToBoard(Mark.O, 5);
            Assert.IsTrue(game.HasBeenWon());
        }

        [Test]
        public void GameNotDrawnWhenBoardIsEmpty()
        {
            Assert.IsFalse(game.HasBeenDrawn());
        }

        [Test]
        public void GameDrawnWhenBoardIsFullAndNotWon()
        {
            AddMoveToBoard(Mark.X, 0);
            AddMoveToBoard(Mark.X, 1);
            AddMoveToBoard(Mark.O, 2);
            AddMoveToBoard(Mark.O, 3);
            AddMoveToBoard(Mark.O, 4);
            AddMoveToBoard(Mark.X, 5);
            AddMoveToBoard(Mark.X, 6);
            AddMoveToBoard(Mark.X, 7);
            AddMoveToBoard(Mark.O, 8);
            Assert.IsTrue(game.HasBeenDrawn());
            Assert.IsTrue(game.IsGameOver());
        }

        [Test]
        public void GameHasWinner()
        {
            AddMoveToBoard(Mark.O, 0);
            AddMoveToBoard(Mark.O, 1);
            AddMoveToBoard(Mark.O, 2);
            Assert.AreEqual(game.WinningMark(), Mark.O);
            Assert.IsTrue(game.IsGameOver());
        }

        [Test]
        public void EmptyBoardHasNoWinner()
        {
            Assert.AreEqual(game.WinningMark(), Mark.EMPTY);
        }

        [Test]
        public void HasAvailablePositions()
        {
            AddMoveToBoard(Mark.O, 0);
            Assert.AreEqual(game.GetAvailablePositions(), board.GetAvailablePositions());
        }

        [Test]
        public void CopiesGameWithNewMove()
        {
            Game copiedGame = game.CopyGameWithNewMove(new Move(Mark.X, 0));
            Assert.AreEqual(copiedGame.Board.GetMarkAtPosition(0), Mark.X);
        }

        [Test]
        public void ValidatesMoveWhichIsWithinRangeAndIsCurrentlyEmpty()
        {
            Assert.IsTrue(game.IsMoveValid(new Move(Mark.X, 0)));
        }

        [Test]
        public void InvalidatesMoveWhereItAlreadyExists()
        {
            AddMoveToBoard(Mark.O, 0);
            Assert.IsFalse(game.IsMoveValid(new Move(Mark.X, 0)));
        }

        [Test]
        public void InvalidatesMoveThatIsNotWithinBoardRange()
        {
            Assert.IsFalse(game.IsMoveValid(new Move(Mark.X, -1)));
        }

        [Test]
        public void HasCurrentPlayerMark()
        {
            Assert.AreEqual(game.CurrentPlayerMark, player1.Mark);
        }

        void AddMoveToBoard(Mark mark, int position)
        {
            board.AddMove(new Move(mark, position));
        }
    }
}
