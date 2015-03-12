namespace TicTacToe
{
    public class Game
    {
        private readonly Board board;
        private readonly Player player1;
		private readonly Player player2;

		public Game(Board board, Player player1, Player player2)
        {
            this.player1 = player1;
			this.player2 = player2;
            this.board = board;
        }

		public void PlayTurn()
        {
            board.AddMove(GetCurrentPlayer().Mark, GetCurrentPlayer().GetMove());
        }

		public bool HasBeenWon ()
		{
			board.GetLines ();
			return false;
		}

        private Player GetCurrentPlayer()
        {
			return PlayerOneGoingNext () ? player1 : player2;
        }

		private bool PlayerOneGoingNext()
		{
			return board.GetAvailablePositions ().Count % 2 == 1;
		}
    }
}
