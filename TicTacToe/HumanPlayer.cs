namespace TicTacToe
{
    public class HumanPlayer : Player
    {
        private readonly Display display;

        public HumanPlayer(Mark mark, Display display)
        {
            this.display = display;
            Mark = mark;
        }

        public Mark Mark { get; private set; }

        public Move GetMove(Game game)
        {
            Move move;
            while (!game.IsMoveValid(move = GetMove()))
            {
                PrintInvalidMoveError();
            }

            return move;
        }

        private void PrintInvalidMoveError()
        {
            display.PrintInvalidMoveError();
        }

        private Move GetMove()
        {
            return new Move(Mark, GetPositionFromUser());
        }

        int GetPositionFromUser()
        {
            return display.GetUserPosition();
        }

        public class Factory : PlayerFactory
        {
            private readonly Display display;

            public Factory(Display display){
                this.display = display;
            }

            public Player Build(Mark playerMark, Mark opponentMark)
            {
                return new HumanPlayer(playerMark, display);
            }
        }
    }
}
