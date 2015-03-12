namespace TicTacToe
{
	public class StubPlayer : Player
	{
		int nextMove;

		public void PrepareMove (int nextMove)
		{
			this.nextMove = nextMove;
		}

		public int GetMove ()
		{
			return nextMove;
		}

		public Mark Mark {
			get {
				return Mark.X;
			}
		}
	}
}
