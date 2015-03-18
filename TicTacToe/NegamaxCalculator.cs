using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class MinimaxCalculator<N, R>
    {
        private readonly Func<N, int> scoreCalculator;
        private readonly Predicate<N> terminalPredicate;
        private readonly Func<N, IEnumerable<TrackingNode<N, R>>> childNodeExtractor;

        public MinimaxCalculator(Predicate<N> terminalPredicate, Func<N, int> scoreCalculator, Func<N, IEnumerable<TrackingNode<N, R>>> childNodeExtractor){
            this.childNodeExtractor = childNodeExtractor;
            this.terminalPredicate = terminalPredicate;
            this.scoreCalculator = scoreCalculator;
        }

        public BestNode Negamax(TrackingNode<N, R> node){
            if (terminalPredicate.Invoke(node.Node)){
                return new BestNode(scoreCalculator.Invoke(node.Node), node.Tracker);
            }

            var bestScore = -1000;
            BestNode bestNode = null;
            foreach(var childNode in childNodeExtractor.Invoke(node.Node)){
                var bestNodeOfChild = Negamax(childNode);
                var score = - (bestNodeOfChild.Score);
                if(score > bestScore){
                    bestScore = score;
                    bestNode = new BestNode(score, bestNodeOfChild.Value);
                }
            }
            return bestNode;
        }

        public class BestNode
        {
            public BestNode(int score, R tracker) {
               Score = score;
               Value = tracker;
            }
            public int Score{ get; set; }
            public R Value { get; set; }
        }

    }
}
