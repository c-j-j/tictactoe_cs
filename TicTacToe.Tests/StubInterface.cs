using System.Collections;

namespace TicTacToe.Tests
{
	public class StubInterface : UserInterface
	{
		Queue positions;
        bool printErrorMessageCalled = false;

		public void PrepareUserPositions (params int[] positions)
		{
			this.positions = new Queue(positions);
		}

		public int GetUserPosition ()
		{
			return (int)positions.Dequeue();
		}

        public void PrintErrorMessage()
        {
            printErrorMessageCalled = true;
        }

        public bool PrintErrorMessageCalled()
        {
            return printErrorMessageCalled;
        }
	}
}
