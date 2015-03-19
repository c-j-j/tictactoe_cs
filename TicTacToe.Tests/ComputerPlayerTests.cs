using System;
using System.Linq;
using NUnit.Framework;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class ComputerPlayerTests
    {
        ComputerPlayer computerPlayer;

        [SetUp]
        public void Setup(){
            computerPlayer = new ComputerPlayer(Mark.X, Mark.O);
        }

        [Test]
        public void ScoreIsZeroWhenGameEndedInDraw()
        {
            var game = TestGameFactory.DrawnGame();
            var score = computerPlayer.CalculateScore(game, Mark.X);
            Assert.AreEqual(score, 0);
        }

        [Test]
        public void ScoreIsNegativeWhenComputerHasLost()
        {
            var game = TestGameFactory.WonGame(Mark.O);
            var score = computerPlayer.CalculateScore(game, Mark.X);
            Assert.AreEqual(score, -10);
        }

        [Test]
        public void ScoreIsPositiveWhenComputerHasWon()
        {
            var game = TestGameFactory.WonGame(Mark.X);
            var score = computerPlayer.CalculateScore(game, Mark.X);
            Assert.AreEqual(score, 10);
        }

        [Test]
        public void GeneratesAllPossibleGameTypes()
        {
            var game = TestGameFactory.NewGame();
            var list = computerPlayer.generateChildExtractor(game, Mark.X).ToArray();
            Assert.AreEqual(list.Length, 9);
        }

        [Test]
        public void CalculatesToGoTopCornerDuringNewGame()
        {
            var move = computerPlayer.GetMove(TestGameFactory.NewGame());
            var corners = new []{ 0, 2, 6, 8 };
            Assert.That(corners, Contains.Item(move.Position));
        }

        [Test]
        public void Foo()
        {
            var board = new Board();
            board.AddMove(new Move(Mark.X, 6));
            board.AddMove(new Move (Mark.O, 4));
            board.AddMove(new Move(Mark.X, 0));
			//var cP = new ComputerPlayer (Mark.O, Mark.X);
            //var game = new Game(board, new StubPlayer(Mark.O), cP);
            //var move = cP.GetMove(game);
            //Assert.AreEqual(1, move.Position);
        }

    }
}
