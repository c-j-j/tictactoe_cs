using System.Collections.Generic;

namespace TicTacToe
{
    public class MainClass
    {
        static void Main()
        {
            var userInterface = new ConsoleDisplay();
            var userInput = new ConsoleUserInput();
            new GameRunner(CreateGame(userInterface, userInput), userInterface).Run();
        }

        static Game CreateGame(ConsoleDisplay userInterface, ConsoleUserInput userInput)
        {
            var playerOptions = new Dictionary<string, PlayerFactory>
            {
                {
                    "Human Player",
                    new HumanPlayer.Factory(userInterface, userInput)
                },
                {
                    "Computer Player",
                    new ComputerPlayer.Factory()
                }
            };
            return new GameSetup(userInput, playerOptions).CreateGame();
        }

    }
}
