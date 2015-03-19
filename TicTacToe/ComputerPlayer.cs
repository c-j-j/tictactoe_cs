using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class ComputerPlayer : Player
    {
        Mark opponentMark;

        public ComputerPlayer(Mark mark, Mark opponentMark)
        {
            Mark = mark;
            this.opponentMark = opponentMark;
        }

        public Mark Mark { get; private set; }

        public Move GetMove(Game game)
        {
            Predicate<Game> gameOverPredicate = g => g.IsGameOver();
            Func<Game, Mark, int> gameScore = (g, m) => CalculateScore(g, m);
            Func<Game, Mark, IEnumerable<TrackingNode<Game, int>>> childExtractor = delegate (Game g1, Mark m1)
            {
                return generateChildExtractor(g1, m1);
            };

            var negamax = new NegamaxCalculator<Game, Mark, int>(gameOverPredicate, gameScore, childExtractor, Mark, opponentMark);
            var bestNode = negamax.Negamax(new TrackingNode<Game, int>(game, -1));
            return new Move(Mark, bestNode.Value);
        }


        public IEnumerable<TrackingNode<Game, int>> generateChildExtractor(Game game, Mark mark)
        {
            List<TrackingNode<Game, int>> trackedGames = new List<TrackingNode<Game, int>>();
            foreach (var position in game.GetAvailablePositions())
            {
                var newGame = game.CopyGameWithNewMove(new Move(mark, position));
                trackedGames.Add(new TrackingNode<Game, int>(newGame, position));
            }
            return trackedGames;
        }

        public int CalculateScore(Game game, Mark mark)
        {
            if (game.HasBeenDrawn())
            {
                return 0;
            }
            else if (game.HasBeenWon()){
                if (game.WinningMark() == mark){
                    return 10;
                }else if(game.WinningMark() == OtherMark(mark)){
                    return -10;
                }else{
                    throw new Exception("Game has been won but mark does not match");
                }
            }
            else
            {
                throw new Exception("Calculating Score when it isn't game over");
            }
        }

        private Mark OtherMark(Mark mark){
            return mark.Equals(Mark.O) ? Mark.X : Mark.O;
        }



    }
}
