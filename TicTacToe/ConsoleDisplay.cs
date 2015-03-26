using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;

namespace TicTacToe
{
    public class ConsoleDisplay : Display
    {
        public const string CELL_FORMAT = " {0} |";
        //TODO do not like the subtle duplication between here and userInput
        public const int INPUT_OFFSET = 1;

        public override void PrintMessage(string message)
        {
           WriteToConsole(message);
        }

        public override void PrintBoard(Board board)
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

        private void WriteOptionsToConsole(IEnumerable<string> options)
        {
            var index = 1;
            options.ToList().ForEach(o => WriteToConsole(String.Format("{0}: {1}", index++, o)));
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
