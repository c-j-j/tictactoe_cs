namespace TicTacToe
{
    public class ComputerPlayer : Player
    {
        public Mark Mark
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public Move GetMove (Game game)
        {
            return new Move(Mark.X, 0);
        }

    }
}
