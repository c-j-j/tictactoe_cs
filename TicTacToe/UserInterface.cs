namespace TicTacToe
{
    public abstract class Display
    {

        public const string INVALID_MOVE_ERROR = "Invalid Move Given";
        public const string DRAWN_MESSAGE = "Game ended in draw.";
        public const string WINNER_MESSAGE = "{0} has won.";
        public const string NEXT_PLAYER_MESSAGE = "{0}'s turn.";

        public virtual void PrintInvalidMoveError()
        {
            PrintMessage(INVALID_MOVE_ERROR);
        }

        public virtual void PrintDrawnOutcome()
        {
            PrintMessage(DRAWN_MESSAGE);
        }

        public virtual void PrintWinOutcome(Mark winningMark)
        {
            PrintMessage(string.Format(WINNER_MESSAGE, winningMark));
        }

        public virtual void PrintNextPlayer(Mark nextPlayerMark)
        {
            PrintMessage(string.Format(NEXT_PLAYER_MESSAGE, nextPlayerMark));
        }

        public abstract void PrintMessage(string message);
        public abstract void PrintBoard(Board board);
    }
}
