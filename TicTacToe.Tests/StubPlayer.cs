namespace TicTacToe
{
	public class StubPlayer : Player
	{
		int nextMove;

		public void PrepareMove (int nextMove)
		{
			this.nextMove = nextMove;
		}

		public Move GetMove (Game game)
		{
			return new Move(Mark.X, nextMove);
		}

        public Mark Mark{
            get{
                return Mark.X;
            }
        }

        public int NextMove{
            get{
                return nextMove;
            }
        }
	}
}
