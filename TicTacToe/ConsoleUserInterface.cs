using System;

namespace TicTacToe
{
    public class ConsoleUserInterface : UserInterface
    {
        public static readonly string ERROR_MESSAGE = "Error Occurred\n";

        public int GetUserPosition()
        {
            return int.Parse(ReadLineFromUser());
        }

        public void PrintErrorMessage()
        {
            WriteToConsole(ERROR_MESSAGE);
        }

        public void PrintDrawnOutcome()
        {
            throw new NotImplementedException();
        }

        public void PrintWinOutcome(Mark winningMark)
        {
            throw new NotImplementedException();
        }

        public void PrintBoard(TicTacToe.Board board)
        {
            throw new NotImplementedException();
        }

        private string ReadLineFromUser()
        {
            return Console.ReadLine();
        }

        private void WriteToConsole(string message)
        {
            Console.Write(message);
        }

        public void PrintNextPlayer(TicTacToe.Mark nextPlayerMark)
        {
            throw new NotImplementedException();
        }
    }
}
