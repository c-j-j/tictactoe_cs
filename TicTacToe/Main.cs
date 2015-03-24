using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class MainClass
    {
        static void Main()
        {
            var userInterface = new ConsoleUserInterface();
            var playerOptions = new Dictionary<string, PlayerFactory>();
            playerOptions.Add("Human Player", new HumanPlayer.Factory(userInterface));
            playerOptions.Add("Computer Player", new ComputerPlayer.Factory());
            var game = new GameSetup(userInterface, playerOptions).CreateGame();
            new GameRunner(game, userInterface).Run();
        }
    }
}
