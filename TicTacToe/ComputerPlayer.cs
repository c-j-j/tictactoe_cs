using System;
using System.Collections.Generic;
using Negamax;

namespace TicTacToe
{
    public class ComputerPlayer : Player
    {
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
            return CreateNegaMaxCalculator().Negamax(new Node<Game, int>(game, defaultPosition)).Node.Datum;
        }

        public IEnumerable<Node<Game, int>> GeneratePossibleGameStates(Game game, Mark mark)
        {
            var trackedGames = new List<Node<Game, int>>();
            foreach (var position in game.GetAvailablePositions())
            {
                var newGame = game.CopyGameWithNewMove(new Move(mark, position));
                trackedGames.Add(new Node<Game, int>(newGame, position));
            }
            return trackedGames;
        }

        public int CalculateGameScore(Game game, Mark mark)
        {
            if (!game.IsGameOver())
            {
                throw new Exception("Calculating Score when it isn't game over");
            }

            if (game.HasBeenDrawn())
            {
                return DRAWN_SCORE;
            }
            return MarkHasWon(game, mark) ? WON_SCORE : LOST_SCORE;
        }

        private bool MarkHasWon(Game game, Mark mark)
        {
            return game.WinningMark().Equals(mark);
        }

        private Predicate<Game> GameOverPredicate()
        {
            return g => g.IsGameOver();
        }

        private NegamaxCalculator<Game, Mark, int> CreateNegaMaxCalculator()
        {
            return new NegamaxCalculator<Game, Mark, int>(GameOverPredicate(), 
                    CalculateGameScore, GeneratePossibleGameStates, Mark, opponentMark);
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
