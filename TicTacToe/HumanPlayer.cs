namespace TicTacToe.Tests
{
    public class HumanPlayer : Player
    {
        private Mark mark;
        private readonly UserInterface userInterface;

        public HumanPlayer(Mark mark, UserInterface userInterface)
        {
            this.userInterface = userInterface;
            this.mark = mark;
        }

        public Move GetMove(Game game)
        {
            while (true)
            {
                var move = new Move(mark, userInterface.GetUserPosition());
                if (game.IsMoveValid(move))
                {
                    return move;
                }

                userInterface.PrintErrorMessage();
            }

        }

    }
}
