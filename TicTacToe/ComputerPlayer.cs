using System;
using System.Collections.Generic;
using System.Linq;
using Negamax;

namespace TicTacToe
{
    public class ComputerPlayer : Player
    {
        //TODO remove
        Mark opponentMark;
        const int WON_SCORE = 10;
        const int LOST_SCORE = -10;
        const int DRAWN_SCORE = 0;

        public ComputerPlayer(Mark mark, Mark opponentMark)
        {
            Mark = mark;
            this.opponentMark = opponentMark;
        }

        public Mark Mark { get; private set; }

        public Move GetMove(Game game)
        {
            return new Move(Mark, FindBestPosition(game));
        }

        public bool Ready()
        {
            return true;
        }

        private int FindBestPosition(Game game)
        {
            const int defaultPosition = -1;
            return CreateNegaMaxCalculator().FindBestNode(new Node<Game, int>(game, defaultPosition)).Datum;
        }

        public IEnumerable<Node<Game, int>> GeneratePossibleGameStates(Node<Game, int> node)
        {
           var game = node.State;
            var trackedGames = new List<Node<Game, int>>();
            foreach (var position in game.GetAvailablePositions())
            {
                var newGame = game.CopyGameWithNewMove(new Move(game.CurrentPlayerMark, position));
                trackedGames.Add(new Node<Game, int>(newGame, position));
            }
            return trackedGames;
        }

        public int CalculateGameScore(Node<Game, int> node)
        {
            var game = node.State;
            if (!game.IsGameOver())
            {
                throw new Exception("Calculating Score when it isn't game over");
            }

            if (game.HasBeenDrawn())
            {
                return DRAWN_SCORE;
            }

            var score = MarkHasWon(game, game.CurrentPlayerMark) ? WON_SCORE : LOST_SCORE;
            return score;
        }

        private bool MarkHasWon(Game game, Mark mark)
        {
            return game.WinningMark().Equals(mark);
        }

        private Predicate<Node<Game, int>> GameOverPredicate()
        {
            return g => g.State.IsGameOver();
        }

        private NegamaxCalculator<Node<Game, int>> CreateNegaMaxCalculator()
        {
            return new NegamaxCalculator<Node<Game, int>>(GameOverPredicate(), CalculateGameScore, GeneratePossibleGameStates);
        }

        public class Factory : PlayerFactory
        {
            public Player Build(Mark playerMark, Mark opponentMark)
            {
                return new ComputerPlayer(playerMark, opponentMark);
            }
        }
    }
}
