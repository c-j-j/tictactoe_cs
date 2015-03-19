using System;

namespace TicTacToe
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            var board = new Board();
            var userInterface = new ConsoleUserInterface();
            var game = new Game(board, new HumanPlayer(Mark.X, userInterface), new ComputerPlayer(Mark.O, Mark.X));
            new GameDriver(game, userInterface).Run();
        }
    }
}
