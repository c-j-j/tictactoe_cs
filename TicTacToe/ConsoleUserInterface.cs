using System;
using System.Text;

namespace TicTacToe
{
    public class ConsoleUserInterface : UserInterface
    {
        public const string ERROR_MESSAGE = "Error Occurred\n";
        public const string DRAWN_MESSAGE = "Game ended in draw.\n";
        public const string WINNER_MESSAGE = "{0} has won.\n";
        public const string NEXT_PLAYER_MESSAGE = "{0}'s turn.\n";
        public const string CELL_FORMAT = "{0} |";

        public int GetUserPosition()
        {
            return int.Parse(ReadLineFromUser()) - 1;
        }

        public void PrintErrorMessage()
        {
            WriteToConsole(ERROR_MESSAGE);
        }

        public void PrintDrawnOutcome()
        {
            WriteToConsole(DRAWN_MESSAGE);
        }

        public void PrintWinOutcome(Mark winningMark)
        {
            WriteToConsole(String.Format(WINNER_MESSAGE, winningMark));
        }

        public void PrintBoard(Board board)
        {
            var boardStringBuilder = new StringBuilder();
            var counter = 1;
            foreach(Board.Line row in board.GetRows()){
                foreach(Mark mark in row.Marks){
                    boardStringBuilder.Append(FormatCell(mark, counter));
                    counter++;
                }
                boardStringBuilder.AppendLine();
            }

            WriteToConsole(boardStringBuilder.ToString());
        }

        string FormatCell(Mark mark, int counter)
        {
            var cell =  mark != Mark.EMPTY ? mark.ToString() : counter.ToString();
            return String.Format(CELL_FORMAT, cell);
        }

        public void PrintNextPlayer(Mark nextPlayerMark)
        {
            WriteToConsole(String.Format(NEXT_PLAYER_MESSAGE, nextPlayerMark));
        }

        private string ReadLineFromUser()
        {
            return Console.ReadLine();
        }

        private void WriteToConsole(string message)
        {
            Console.Write(message);
        }

    }
}
