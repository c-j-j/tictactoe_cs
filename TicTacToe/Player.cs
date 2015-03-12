namespace TicTacToe
{
	public interface Player
	{
		int GetMove ();

		Mark Mark {
			get;
		}
	}
}
