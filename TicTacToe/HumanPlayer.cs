namespace TicTacToe
{
    public class HumanPlayer : Player
    {
        readonly Display display;
        readonly UserInput userInput;

        public HumanPlayer(Mark mark, Display display, UserInput userInput)
        {
            this.userInput = userInput;
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

        public bool Ready()
        {
            return true;
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
            return userInput.GetUserPosition();
        }

        public class Factory : PlayerFactory
        {
            readonly Display display;
            readonly UserInput userInput;

            public Factory(Display display, UserInput userInput){
                this.userInput = userInput;
                this.display = display;
            }

            public Player Build(Mark playerMark, Mark opponentMark)
            {
                return new HumanPlayer(playerMark, display, userInput);
            }
        }
    }
}
