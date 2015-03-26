using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class ConsoleUserInput : UserInput
    {
        public const int INPUT_OFFSET = 1;
        public const string SELECT_PLAYER_MESSAGE = "Select player for {0}";

        public int GetUserPosition()
        {
            int userPosition;
            int.TryParse(ReadLineFromUser(), out userPosition);
            return userPosition - INPUT_OFFSET;
        }

        private string ReadLineFromUser()
        {
            return Console.ReadLine();
        }

        public string GetPlayerType(TicTacToe.Mark mark, string[] playerOptions)
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

        private void WriteOptionsToConsole(IEnumerable<string> options)
        {
            var index = 1;
            options.ToList().ForEach(o => WriteToConsole(String.Format("{0}: {1}", index++, o)));
        }

        private void WriteToConsole(string message)
        {
            Console.WriteLine(message);
        }
    }
}
