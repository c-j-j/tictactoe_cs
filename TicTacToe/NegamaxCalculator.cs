using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class NegamaxCalculator<N, M, R>
    {
        private readonly Func<N, M, int> scoreCalculator;
        private readonly Predicate<N> terminalNodePredicate;
        private readonly Func<N, M, IEnumerable<TrackingNode<N, R>>> childNodeExtractor;
        private M player;
        private M opponent;

        public NegamaxCalculator(Predicate<N> terminalNodePredicate, Func<N, M, int> scoreCalculator, Func<N, M, IEnumerable<TrackingNode<N, R>>> childNodeExtractor, M player, M opponent)
        {
            this.childNodeExtractor = childNodeExtractor;
            this.terminalNodePredicate = terminalNodePredicate;
            this.scoreCalculator = scoreCalculator;
            this.player = player;
            this.opponent = opponent;
        }

        public BestNode Negamax(TrackingNode<N, R> node)
        {
            return Negamax(node, player);
        }

		public BestNode Negamax(TrackingNode<N, R> node, M currentPlayer)
        {
            if (terminalNodePredicate.Invoke(node.Node))
            {
                return new BestNode(scoreCalculator.Invoke(node.Node, currentPlayer), node.Tracker);
            }

            var bestScore = -1000;
            BestNode bestNode = null;
            foreach (var childNode in childNodeExtractor.Invoke(node.Node, currentPlayer))
            {
				var bestNodeOfChild = Negamax(childNode, swapPlayer(currentPlayer));
                var score = -(bestNodeOfChild.Score);
                if (score > bestScore)
                {
                    bestScore = score;
					bestNode = new BestNode(score, bestNodeOfChild.Value);
                }
            }

            return bestNode;
        }

        private M swapPlayer(M currentPlayer)
        {
            return currentPlayer.Equals(opponent) ? player : opponent;
        }

        public class BestNode
        {
            public BestNode(int score, R tracker)
            {
                Score = score;
                Value = tracker;
            }
            public int Score{ get; set; }
            public R Value { get; set; }
        }

    }
}
