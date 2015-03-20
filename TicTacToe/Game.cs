using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {
        private readonly Board board;
        public readonly Player Player1;
        public readonly Player Player2;

        public Game(Board board, Player player1, Player player2)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            this.board = board;
        }

        public void PlayTurn()
        {
            board.AddMove(GetCurrentPlayer().GetMove(this));
        }

        public bool IsMoveValid(Move move)
        {
            return IsPositionWithinRange(move) && IsPositionEmpty(move);
        }

        public bool IsGameOver()
        {
            return HasBeenWon() || HasBeenDrawn();
        }

        public bool HasBeenWon()
        {
            return board.GetLines().Any(l => l.ContainSameMark());
        }

        //TODO not happy with this, seems like it could be neater
        public Mark WinningMark()
        {
            var winningLine =  board.GetLines().FirstOrDefault(l => l.ContainSameMark());
            return winningLine != null ? winningLine.Marks.First() : Mark.EMPTY;
        }

        public Mark CurrentPlayerMark { get { return GetCurrentPlayer().Mark; } }

        private bool BoardIsFull()
        {
            return board.GetAvailablePositions().Count() == 0;
        }

        public bool HasBeenDrawn()
        {
            return BoardIsFull() && !HasBeenWon();
        }

        public IEnumerable<int> GetAvailablePositions()
        {
            return board.GetAvailablePositions();
        }

        public Game CopyGameWithNewMove(Move move)
        {
            Board boardCopy = board.Copy();
            boardCopy.AddMove(move);
            return new Game(boardCopy, Player1, Player2);
        }

        public Board Board { get { return board; } }

        private Player GetCurrentPlayer()
        {
            return PlayerOneGoingNext() ? Player1 : Player2;
        }

        private bool IsPositionEmpty(Move move)
        {
            return board.GetMarkAtPosition(move.Position) == Mark.EMPTY;
        }

        private bool PlayerOneGoingNext()
        {
            return board.GetAvailablePositions().Count() % 2 == 1;
        }

        private bool IsPositionWithinRange(Move move)
        {
            return board.IsPositionInRange(move.Position);
        }

    }
}
