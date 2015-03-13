namespace TicTacToe
{
	public class ComputerPlayer : Player
	{

		public Move GetMove ()
		{
			return new Move(Mark.X, 0);
		}

	}
}
