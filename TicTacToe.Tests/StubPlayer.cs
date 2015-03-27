namespace TicTacToe
{
    public class StubPlayer : Player
    {
        int nextMove;
        private Mark mark;
        bool isReady;

        public StubPlayer(Mark mark) : this(mark, true)
        {
        }

        public StubPlayer(Mark mark, bool isReady)
        {
            this.isReady = isReady;
            this.mark = mark;
        }

        public StubPlayer() : this(Mark.X, true)
        {
        }

        public bool Ready()
        {
            return isReady;
        }

        public void PrepareMove(int nextMove)
        {
            this.nextMove = nextMove;
        }

        public Move GetMove(Game game)
        {
            return new Move(mark, nextMove);
        }

        public Mark Mark { get { return mark; } }

        public int NextMove { get { return nextMove; } }

        public class Factory : PlayerFactory
        {

            public Player Build(Mark playerMark, Mark opponentMark)
            {
                return new StubPlayer(playerMark);
            }

        }
    }
}
