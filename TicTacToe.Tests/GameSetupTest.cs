using System.Collections.Generic;
using NUnit.Framework;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class GameSetupTest
    {
        StubInterface userInterface;
        const string stubPlayer = "StubPlayer";
        Dictionary<string, PlayerFactory> playerOptions;

        [SetUp]
        public void Setup()
        {
            userInterface = new StubInterface();
            playerOptions = new Dictionary<string, PlayerFactory>();
            playerOptions.Add(stubPlayer, new StubPlayer.Factory());
        }

        [Test]
        public void BuildsPlayeByCollaboratingWithUserInterface()
        {
            userInterface.PreparePlayerTypeToReturn(stubPlayer);
            Game game = new GameSetup(userInterface, playerOptions).CreateGame();
            Assert.IsInstanceOf<StubPlayer>(game.Player1);
            Assert.IsInstanceOf<StubPlayer>(game.Player2);
        }

        [Test]
        public void AssignsXAndOToPlayer1And2()
        {
            userInterface.PreparePlayerTypeToReturn(stubPlayer);
            Game game = new GameSetup(userInterface, playerOptions).CreateGame();
            Assert.AreEqual(game.Player1.Mark, Mark.X);
            Assert.AreEqual(game.Player2.Mark, Mark.O);
        }
    }
}
