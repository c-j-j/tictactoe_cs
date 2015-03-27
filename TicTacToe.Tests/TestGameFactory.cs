namespace TicTacToe
{
    public static class TestGameFactory
    {
        public static Game NewGame()
        {
            return new Game(new Board(), new StubPlayer(), new StubPlayer());
        }

        public static Game GameWhereNextPlayerIsntReady()
        {
            var stubPlayer1 = new StubPlayer(Mark.X, false);
            var stubPlayer2 = new StubPlayer(Mark.O);
            var board = new Board();
            return new Game(board, stubPlayer1, stubPlayer2);
        }

        public static Game OneTurnGame()
        {
            var stubPlayer1 = new StubPlayer(Mark.X);
            var stubPlayer2 = new StubPlayer(Mark.O);
            var board = new Board();
            AddMoveToBoard(stubPlayer1, 0, board);
            AddMoveToBoard(stubPlayer1, 1, board);
            AddMoveToBoard(stubPlayer2, 7, board);
            AddMoveToBoard(stubPlayer2, 8, board);
            stubPlayer1.PrepareMove(2);
            return new Game(board, stubPlayer1, stubPlayer2);
        }

        public static Game DrawnGame()
        {
            var stubPlayer1 = new StubPlayer(Mark.X);
            var stubPlayer2 = new StubPlayer(Mark.O);
            var board = new Board();
            AddMoveToBoard(stubPlayer1, 0, board);
            AddMoveToBoard(stubPlayer1, 1, board);
            AddMoveToBoard(stubPlayer2, 2, board);
            AddMoveToBoard(stubPlayer2, 3, board);
            AddMoveToBoard(stubPlayer2, 4, board);
            AddMoveToBoard(stubPlayer1, 5, board);
            AddMoveToBoard(stubPlayer1, 6, board);
            AddMoveToBoard(stubPlayer1, 7, board);
            AddMoveToBoard(stubPlayer2, 8, board);
            return new Game(board, stubPlayer1, stubPlayer2);
        }

        public static Game WonGame(Mark winningMark)
        {
            var board = new Board();
            var wonPlayer = new StubPlayer(winningMark);
            AddMoveToBoard(wonPlayer, 0, board);
            AddMoveToBoard(wonPlayer, 1, board);
            AddMoveToBoard(wonPlayer, 2, board);
            return new Game(board, wonPlayer, new StubPlayer(Mark.EMPTY));
        }

        private static void AddMoveToBoard(StubPlayer player, int position, Board board)
        {
            board.AddMove(new Move(player.Mark, position));
        }

    }
}
