namespace TicTacToe
{
    public class HumanPlayer : Player
    {
        private readonly UserInterface userInterface;

        public HumanPlayer(Mark mark, UserInterface userInterface)
        {
            this.userInterface = userInterface;
            Mark = mark;
        }

        public Mark Mark { get; private set; }

        public Move GetMove(Game game)
        {
            Move move;
            while (!game.IsMoveValid(move = GetMoveFromUser()))
            {
                PrintInvalidMoveError();
            }

            return move;
        }

        private void PrintInvalidMoveError()
        {
            userInterface.PrintInvalidMoveError();
        }

        private Move GetMoveFromUser()
        {
            return new Move(Mark, userInterface.GetUserPosition());
        }

    }
}
