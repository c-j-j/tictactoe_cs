using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class GameSetup
    {
        private readonly UserInterface userInterface;
        private readonly Dictionary<string, PlayerFactory> playerOptions;

        public GameSetup(UserInterface userInterface, Dictionary<string, PlayerFactory> playerOptions)
        {
            this.playerOptions = playerOptions;
            this.userInterface = userInterface;
        }

        public Game CreateGame()
        {
            return new Game(new Board(), CreatePlayer(Mark.X, Mark. O), CreatePlayer(Mark.O, Mark.X));
        }

        public Player CreatePlayer(Mark player, Mark opponent)
        {
           return playerOptions[userInterface.GetPlayerType(player, playerOptions.Keys.ToArray())]
               .Build(player, opponent);
        }
    }
}
