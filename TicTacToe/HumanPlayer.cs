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
            //TODO clean up
            while (true)
            {
                var move = new Move(Mark, userInterface.GetUserPosition());
                if (game.IsMoveValid(move))
                {
                    return move;
                }

                userInterface.PrintErrorMessage();
            }

        }

    }
}
