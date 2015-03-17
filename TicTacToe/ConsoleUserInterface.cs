using System;
using System.Text;

namespace TicTacToe
{
    public class ConsoleUserInterface : UserInterface
    {
        public const string INVALID_MOVE_ERROR = "Invalid Move Given";
        public const string DRAWN_MESSAGE = "Game ended in draw.";
        public const string WINNER_MESSAGE = "{0} has won.";
        public const string NEXT_PLAYER_MESSAGE = "{0}'s turn.";
        public const string CELL_FORMAT = " {0} |";
        public const int CELL_OFFSET = 1;

        public int GetUserPosition()
        {
            int userPosition;
            int.TryParse(ReadLineFromUser(), out userPosition);
            return userPosition - CELL_OFFSET;
        }

        public void PrintInvalidMoveError()
        {
            WriteToConsole(INVALID_MOVE_ERROR);
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
            var counter = CELL_OFFSET;
            foreach (Board.Line row in board.GetRows())
            {
                foreach (Mark mark in row.Marks)
                {
                    boardStringBuilder.Append(FormatCell(mark, counter));
                    counter++;
                }
                boardStringBuilder.AppendLine();
            }

            WriteToConsole(boardStringBuilder.ToString());
        }

        public void PrintNextPlayer(Mark nextPlayerMark)
        {
            WriteToConsole(String.Format(NEXT_PLAYER_MESSAGE, nextPlayerMark));
        }

        private string ReadLineFromUser()
        {
            return Console.ReadLine();
        }

        private string FormatCell(Mark mark, int counter)
        {
            var cell = mark != Mark.EMPTY ? mark.ToString() : counter.ToString();
            return String.Format(CELL_FORMAT, cell);
        }

        private void WriteToConsole(string message)
        {
            Console.WriteLine(message);
        }

    }
}
