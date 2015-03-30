using System;
using System.Linq;
using NUnit.Framework;
using Negamax;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class ComputerPlayerTests
    {
        ComputerPlayer computerPlayer;
        StubPlayer opponentPlayer;
        Board board;

        [SetUp]
        public void Setup(){
            board = new Board();
            opponentPlayer = new StubPlayer(Mark.O);
            computerPlayer = new ComputerPlayer(Mark.X, Mark.O);
        }

        [Test]
        public void ComputerPlayerAlwaysReady()
        {
            Assert.AreEqual(true, computerPlayer.Ready());
        }

        [Test]
        public void ScoreIsZeroWhenGameEndedInDraw()
        {
            var game = TestGameFactory.DrawnGame();
            var score = computerPlayer.CalculateGameScore(game, Mark.X);
            Assert.AreEqual(score, 0);
        }

        [Test]
        public void ScoreIsNegativeWhenComputerHasLost()
        {
            var game = TestGameFactory.WonGame(Mark.O);
            var score = computerPlayer.CalculateGameScore(game, Mark.X);
            Assert.AreEqual(score, -10);
        }

        [Test]
        public void ScoreIsPositiveWhenComputerHasWon()
        {
            var game = TestGameFactory.WonGame(Mark.X);
            var score = computerPlayer.CalculateGameScore(game, Mark.X);
            Assert.AreEqual(score, 10);
        }

        [Test]
        public void GeneratesAllPossibleGameTypes()
        {
            var game = TestGameFactory.NewGame();
            var list = computerPlayer.GeneratePossibleGameStates(game, Mark.X).ToArray();
            Assert.AreEqual(list.Length, 9);
        }

        [Test]
        public void CalculatesToGoInCornerDuringNewGame()
        {
            var move = computerPlayer.GetMove(TestGameFactory.NewGame());
            var corners = new []{ 0, 2, 6, 8 };
            Assert.That(corners, Contains.Item(move.Position));
        }

        [Test]
        public void BlocksOpponentFromWinning()
        {
            AddMoveToBoard(board, opponentPlayer, 0);
            AddMoveToBoard(board, computerPlayer, 8);
            AddMoveToBoard(board, opponentPlayer, 2);
            AssertNextMoveIs(1);
        }

        [Test]
        public void ForksToGiveMultipleChancesToWin()
        {
            AddMoveToBoard(board, computerPlayer, 0);
            AddMoveToBoard(board, computerPlayer, 4);
            AddMoveToBoard(board, opponentPlayer, 1);
            AddMoveToBoard(board, opponentPlayer, 8);
            AssertNextMoveIs(3);
        }

		[Test]
		public void ForksWhenOpponentGoesInOppositeCorner()
		{
			AddMoveToBoard(board, computerPlayer, 0);
			AddMoveToBoard(board, computerPlayer, 2);
			AddMoveToBoard(board, opponentPlayer, 1);
			AddMoveToBoard(board, opponentPlayer, 8);
			AssertNextMoveIs(6);
		}

        [Test]
        public void ComputerVsComputerEndsInDraw()
        {
            var game = new Game(board, new ComputerPlayer(Mark.X, Mark.O), new ComputerPlayer(Mark.O, Mark.X));
            new GameRunner(game, new StubDisplay()).Run();
            Assert.IsTrue(game.HasBeenDrawn());
        }

        [Test]
        public void FactoryBuildsComputerPlayer()
        {
            var player = new ComputerPlayer.Factory().Build(Mark.X, Mark.O);
            Assert.AreEqual(player.Mark, Mark.X);
        }

        private void AssertNextMoveIs(int expectedMove)
        {
            var game = new Game(board, opponentPlayer, computerPlayer);
            var move = computerPlayer.GetMove(game);
            Assert.AreEqual(expectedMove, move.Position);

        }

        void AddMoveToBoard(Board b, Player player, int position)
        {
            b.AddMove(new Move(player.Mark, position));
        }

    }
}
