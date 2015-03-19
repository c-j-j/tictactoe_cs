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
            var game = TestGameFactory.WonGame(new StubPlayer(Mark.O));
            var score = computerPlayer.CalculateScore(game, Mark.X);
            Assert.AreEqual(score, -10);
        }

        [Test]
        public void ScoreIsPositiveWhenComputerHasWon()
        {
            var game = TestGameFactory.WonGame(new StubPlayer(Mark.X));
            var score = computerPlayer.CalculateScore(game, Mark.X);
            Assert.AreEqual(score, 10);
        }

        [Test]
        public void GeneratesAllPossibleGameTypes()
        {
            var game = TestGameFactory.NewGame();
            var list = computerPlayer.generateChildExtractor(game, Mark.X).ToArray();
            Assert.AreEqual(list.Length, 9);
            Assert.AreEqual(list[0].Value.GetAvailablePositions().Count(), 8);
        }

        [Test]
        public void CalculatesToGoTopCornerDuringNewGame()
        {
            var move = computerPlayer.GetMove(TestGameFactory.NewGame());
            Assert.AreEqual(move.Position, 8);
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

        [Test]
        public void Bar()
        {
        }
    }
}
