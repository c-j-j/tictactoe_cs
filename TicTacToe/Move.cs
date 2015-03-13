namespace TicTacToe
{
	public struct Move
	{
		public readonly Mark mark;
		public readonly int position;

		public Move(Mark mark, int position){
			this.position = position;
			this.mark = mark;
		}
	}

}
