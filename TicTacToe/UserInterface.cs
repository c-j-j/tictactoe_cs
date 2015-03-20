namespace TicTacToe
{
    public interface UserInterface
    {
        int GetUserPosition();
        void PrintInvalidMoveError();
        void PrintDrawnOutcome();
        void PrintWinOutcome(Mark winningMark);
        void PrintBoard(Board board);
        void PrintNextPlayer(Mark nextPlayerMark);
        string GetPlayerType(Mark mark, string[] options);
    }


}
