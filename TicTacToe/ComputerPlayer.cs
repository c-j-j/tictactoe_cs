namespace TicTacToe
{
	public class ComputerPlayer : Player
	{

		public Move GetMove (Game game)
		{
			return new Move(Mark.X, 0);
		}

	}
}
