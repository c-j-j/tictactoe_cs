using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;

namespace TicTacToe
{
    public class ConsoleUserInterface : UserInterface
    {
        public const string INVALID_MOVE_ERROR = "Invalid Move Given";
        public const string DRAWN_MESSAGE = "Game ended in draw.";
        public const string WINNER_MESSAGE = "{0} has won.";
        public const string NEXT_PLAYER_MESSAGE = "{0}'s turn.";
        public const string SELECT_PLAYER_MESSAGE = "Select player for {0}";
        public const string CELL_FORMAT = " {0} |";
        public const int INPUT_OFFSET = 1;

        public int GetUserPosition()
        {
            int userPosition;
            int.TryParse(ReadLineFromUser(), out userPosition);
            return userPosition - INPUT_OFFSET;
        }

        public string GetPlayerType(Mark mark, string[] playerOptions)
        {
            return playerOptions[GetPlayerTypeFromUser(mark, playerOptions) - INPUT_OFFSET];
        }

        private int GetPlayerTypeFromUser(Mark mark, string[] options)
        {
            int selectedOption = -1;
            while (true)
            {
                WriteToConsole(String.Format(SELECT_PLAYER_MESSAGE, mark));
                WriteOptionsToConsole(options);
                int.TryParse(ReadLineFromUser(), out selectedOption);
                if (IsOptionWithinRange(options, selectedOption))
                {
                    break;
                }
            }
            return selectedOption;
       }

        private bool IsOptionWithinRange(IEnumerable<string> options, int selectedOption)
        {
            return (options.Count() >= selectedOption) && (selectedOption > 0);
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
            var counter = INPUT_OFFSET;

            foreach (Board.Line row in board.GetRows())
            {
                var formattedMarks = row.Marks.Select(mark => CellRepresentation(mark, counter++));
                boardStringBuilder.Append(string.Join(" | ", formattedMarks.ToArray()));
                boardStringBuilder.AppendLine();
            }

            WriteToConsole(boardStringBuilder.ToString());
        }

        public void PrintNextPlayer(Mark nextPlayerMark)
        {
            WriteToConsole(String.Format(NEXT_PLAYER_MESSAGE, nextPlayerMark));
        }

        private void WriteOptionsToConsole(IEnumerable<string> options)
        {
            var index = 1;
            options.ToList().ForEach(o => WriteToConsole(String.Format("{0}: {1}", index++, o)));
        }

        private string ReadLineFromUser()
        {
            return Console.ReadLine();
        }

        private string CellRepresentation(Mark mark, int counter)
        {
            return mark != Mark.EMPTY ? mark.ToString() : counter.ToString();
        }

        private void WriteToConsole(string message)
        {
            Console.WriteLine(message);
        }

    }
}
