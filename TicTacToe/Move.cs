namespace TicTacToe
{
	public struct Move
	{
		private readonly Mark mark;
		private readonly int position;

		public Move(Mark mark, int position){
			this.position = position;
			this.mark = mark;
		}

        public int Position{
            get{
                return position;
            }
        }

        public Mark Mark{
            get{
                return mark;
            }
        }
	}

}
