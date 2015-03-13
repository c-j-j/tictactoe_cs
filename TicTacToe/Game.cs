using System;
using System.Collections.Generic;

namespace TicTacToe
{
	public class Game
	{
		private readonly Board board;
		private readonly Player player1;
		private readonly Player player2;

		public Game (Board board, Player player1, Player player2)
		{
			this.player1 = player1;
			this.player2 = player2;
			this.board = board;
		}

		public void PlayTurn ()
		{
			board.AddMove (GetCurrentPlayer ().GetMove ());
		}

		public bool HasBeenWon ()
		{
			foreach (Board.Line line in board.GetLines ()) {
				if (line.ContainSameMark ()) {
					return true;
				}
			}
			return false;
		}

		public Mark WinningMark ()
		{
			foreach (Board.Line line in board.GetLines ()) {
				if (line.ContainSameMark ()) {
					return line.Marks [0];
				}
			}
			return Mark.EMPTY;
		}

		private bool BoardIsFull ()
		{
			return board.GetAvailablePositions ().Count == 0;
		}

		public bool HasBeenDrawn ()
		{
			return BoardIsFull () && !HasBeenWon ();
		}

		public List<int> GetAvailablePositions ()
		{
			return board.GetAvailablePositions ();
		}

		public Game CopyGameWithNewMove (Move move)
		{
			Board boardCopy = board;
			boardCopy.AddMove (move);
			return new Game (boardCopy, player1, player2);
		}

		public Board Board {
			get {
				return board;
			}
		}

		private Player GetCurrentPlayer ()
		{
			return PlayerOneGoingNext () ? player1 : player2;
		}

		private bool PlayerOneGoingNext ()
		{
			return board.GetAvailablePositions ().Count % 2 == 1;
		}
	}
}
