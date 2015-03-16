namespace TicTacToe
{
	public interface UserInterface
	{
        int GetUserPosition();
        void PrintErrorMessage();
        void PrintDrawnOutcome();
        void PrintWinOutcome(Mark winningMark);
        void PrintBoard(Board board);
        void PrintNextPlayer(Mark nextPlayerMark);
	}


}

