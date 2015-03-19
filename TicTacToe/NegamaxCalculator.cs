using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class NegamaxCalculator<TNode, TPlayer, TData>
    {
        private readonly Func<TNode, TPlayer, int> scoreCalculator;
        private readonly Predicate<TNode> terminalNodePredicate;
        private readonly Func<TNode, TPlayer, IEnumerable<Node<TNode, TData>>> childNodeExtractor;
        private readonly TPlayer player;
        private readonly TPlayer opponent;

        public NegamaxCalculator(Predicate<TNode> terminalNodePredicate,
            Func<TNode, TPlayer, int> scoreCalculator,
            Func<TNode, TPlayer, IEnumerable<Node<TNode, TData>>> childNodeExtractor,
            TPlayer player, TPlayer opponent)
        {
            this.childNodeExtractor = childNodeExtractor;
            this.terminalNodePredicate = terminalNodePredicate;
            this.scoreCalculator = scoreCalculator;
            this.player = player;
            this.opponent = opponent;
        }

        public BestNode Negamax(Node<TNode, TData> node)
        {
            return Negamax(node, player);
        }

        public BestNode Negamax(Node<TNode, TData> node, TPlayer currentPlayer,
                int alpha=-1000, int beta=1000)
        {
            if (NodeIsTerminal(node))
            {
                return new BestNode(ScoreOfNode(node, currentPlayer), node.Data);
            }

            var bestScore = -1000;
            BestNode bestNode = null;
            foreach (var childNode in GetChildren(node, currentPlayer))
            {
                var bestNodeOfChild = Negamax(childNode, SwapPlayer(currentPlayer), -alpha, -beta);
                var score = -(bestNodeOfChild.Score);
                if (score > bestScore)
                {
                    bestScore = score;
                    bestNode = new BestNode(score, bestNodeOfChild.Value);
                }

                if (Math.Max(alpha, score) >= beta){
                    break;
                }
            }

            return bestNode;
        }

        private IEnumerable<Node<TNode,TData>> GetChildren(Node<TNode, TData> node, TPlayer currentPlayer)
        {
            return childNodeExtractor.Invoke(node.Value, currentPlayer);
        }

        private int ScoreOfNode(Node<TNode, TData> node, TPlayer currentPlayer)
        {
            return scoreCalculator.Invoke(node.Value, currentPlayer);
        }

        private bool NodeIsTerminal(Node<TNode, TData> node)
        {
            return terminalNodePredicate.Invoke(node.Value);
        }

        private TPlayer SwapPlayer(TPlayer currentPlayer)
        {
            return currentPlayer.Equals(opponent) ? player : opponent;
        }

        public class BestNode
        {
            public BestNode(int score, TData value)
            {
                Score = score;
                Value = value;
            }
            public int Score{ get; set; }
            public TData Value { get; set; }
        }

    }
}
