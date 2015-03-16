using System.Collections;

namespace TicTacToe.Tests
{
    public class StubInterface : UserInterface
    {
        private Queue positions;
        private bool printErrorMessageCalled = false;
        private bool printDrawnOutcomeCalled = false;
        private bool printWinOutcomeCalled = false;
        private Mark winningMarkPrinted = Mark.EMPTY;
        private bool printBoardCalled = false;
        private bool printNextPlayerCalled = false;

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

        public void PrintDrawnOutcome()
        {
            printDrawnOutcomeCalled = true;
        }

        public bool PrintDrawOutcomeCalled()
        {
            return printDrawnOutcomeCalled;
        }

        public bool PrintErrorMessageCalled()
        {
            return printErrorMessageCalled;
        }

        public void PrintWinOutcome(Mark winningMark)
        {
            winningMarkPrinted = winningMark;
            printWinOutcomeCalled = true;
        }

        public bool PrintWinOutcomeCalled(Mark mark)
        {
            return printWinOutcomeCalled && (mark == winningMarkPrinted);
        }

        public void PrintBoard(Board board)
        {
            printBoardCalled = true;
        }

        public bool PrintBoardCalled(){
            return printBoardCalled;
        }

        public void PrintNextPlayer(Mark nextPlayerMark)
        {
            printNextPlayerCalled = true;
        }

        public bool PrintNextPlayerCalled(){
            return printNextPlayerCalled;
        }
    }
}
