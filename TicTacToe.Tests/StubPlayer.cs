namespace TicTacToe
{
	public class StubPlayer : Player
	{
		int nextMove;

		public void PrepareMove (int nextMove)
		{
			this.nextMove = nextMove;
		}

		public Move GetMove ()
		{
			return new Move(Mark.X, nextMove);
		}
	}
}
