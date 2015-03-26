using System.Collections;

namespace TicTacToe.Tests
{
    public class StubInput : UserInput
    {
        private Queue positions;
        string playerType;

        public void PrepareUserPositions(params int[] positions)
        {
            this.positions = new Queue(positions);
        }

        public int GetUserPosition()
        {
            return (int)positions.Dequeue();
        }

        public void PreparePlayerTypeToReturn(string playerType)
        {
            this.playerType = playerType;
        }

        public string GetPlayerType(Mark mark, string[] options)
        {
            return playerType;
        }

    }
}
