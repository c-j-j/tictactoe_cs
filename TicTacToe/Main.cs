using System;

namespace TicTacToe
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            var userInterface = new ConsoleUserInterface();
            Game game = new Game(board, new HumanPlayer(Mark.X, userInterface), new HumanPlayer(Mark.O, userInterface));
            new ConsoleGameDriver(game, userInterface).Run();
        }
    }
}
