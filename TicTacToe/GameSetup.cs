using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class GameSetup
    {
        private readonly UserInput userInput;
        private readonly Dictionary<string, PlayerFactory> playerOptions;

        public GameSetup(UserInput userInput, Dictionary<string, PlayerFactory> playerOptions)
        {
            this.playerOptions = playerOptions;
            this.userInput = userInput;
        }

        public Game CreateGame()
        {
            return new Game(new Board(), CreatePlayer(Mark.X, Mark.O), CreatePlayer(Mark.O, Mark.X));
        }

        public Player CreatePlayer(Mark player, Mark opponent)
        {
            return playerOptions[GetPlayerType(player)].Build(player, opponent);
        }

        private string GetPlayerType(Mark player)
        {
            return userInput.GetPlayerType(player, playerOptions.Keys.ToArray());
        }
    }
}
