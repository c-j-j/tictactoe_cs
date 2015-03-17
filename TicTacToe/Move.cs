namespace TicTacToe
{
    public class Move
    {
        public Move(Mark mark, int position)
        {
            Position = position;
            Mark = mark;
        }

        public int Position{ get;  set; }
        public Mark Mark{get; private set; }

    }

}
