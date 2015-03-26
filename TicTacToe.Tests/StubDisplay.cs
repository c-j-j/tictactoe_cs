using System.Collections;

namespace TicTacToe.Tests
{
    public class StubDisplay : Display
    {
        private bool printErrorMessageCalled = false;
        private bool printDrawnOutcomeCalled = false;
        private bool printWinOutcomeCalled = false;
        private Mark winningMarkPrinted = Mark.EMPTY;
        private bool printBoardCalled = false;
        private bool printNextPlayerCalled = false;

        public override void PrintMessage(string messsage)
        {

        }

        public override void PrintInvalidMoveError()
        {
            printErrorMessageCalled = true;
        }

        public override void PrintDrawnOutcome()
        {
            printDrawnOutcomeCalled = true;
        }

        public bool PrintDrawOutcomeCalled()
        {
            return printDrawnOutcomeCalled;
        }

        public bool PrintInvalidMoveMessageCalled()
        {
            return printErrorMessageCalled;
        }

        public override void PrintWinOutcome(Mark winningMark)
        {
            winningMarkPrinted = winningMark;
            printWinOutcomeCalled = true;
        }

        public bool PrintWinOutcomeCalled(Mark mark)
        {
            return printWinOutcomeCalled && (mark == winningMarkPrinted);
        }

        public override void PrintBoard(Board board)
        {
            printBoardCalled = true;
        }

        public bool PrintBoardCalled()
        {
            return printBoardCalled;
        }

        public override void PrintNextPlayer(Mark nextPlayerMark)
        {
            printNextPlayerCalled = true;
        }

        public bool PrintNextPlayerCalled()
        {
            return printNextPlayerCalled;
        }

    }
}
