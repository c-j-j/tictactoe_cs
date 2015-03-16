namespace TicTacToe
{
	public class StubPlayer : Player
	{
		int nextMove;
        private Mark mark;

        public StubPlayer(Mark mark)
        {
            this.mark = mark;
        }

        public StubPlayer()
        {
            this.mark = Mark.X;
        }

		public void PrepareMove (int nextMove)
		{
			this.nextMove = nextMove;
		}

		public Move GetMove (Game game)
		{
			return new Move(mark, nextMove);
		}

        public Mark Mark{
            get{
                return mark;
            }
        }

        public int NextMove{
            get{
                return nextMove;
            }
        }
	}
}
