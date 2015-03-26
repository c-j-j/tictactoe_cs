using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class MainClass
    {
        static void Main()
        {
            var userInterface = new ConsoleDisplay();
            var userInput = new ConsoleUserInput();
            //This can be improved, violates OCP still as new factories need to be added
            var playerOptions = new Dictionary<string, PlayerFactory>();
            playerOptions.Add("Human Player", new HumanPlayer.Factory(userInterface, userInput));
            playerOptions.Add("Computer Player", new ComputerPlayer.Factory());
            var game = new GameSetup(userInput, playerOptions).CreateGame();
            new GameRunner(game, userInterface).Run();
        }
    }
}
