using System.Collections.Generic;
using NUnit.Framework;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class GameSetupTest
    {
        const string stubPlayer = "StubPlayer";
        Dictionary<string, PlayerFactory> playerOptions;
        StubInput userInput;

        [SetUp]
        public void Setup()
        {
            userInput = new StubInput();
            playerOptions = new Dictionary<string, PlayerFactory>();
            playerOptions.Add(stubPlayer, new StubPlayer.Factory());
        }

        [Test]
        public void BuildsPlayeByCollaboratingWithUserInterface()
        {
            userInput.PreparePlayerTypeToReturn(stubPlayer);
            Game game = new GameSetup(userInput, playerOptions).CreateGame();
            Assert.IsInstanceOf<StubPlayer>(game.Player1);
            Assert.IsInstanceOf<StubPlayer>(game.Player2);
        }

        [Test]
        public void AssignsXAndOToPlayer1And2()
        {
            userInput.PreparePlayerTypeToReturn(stubPlayer);
            Game game = new GameSetup(userInput, playerOptions).CreateGame();
            Assert.AreEqual(game.Player1.Mark, Mark.X);
            Assert.AreEqual(game.Player2.Mark, Mark.O);
        }
    }
}
