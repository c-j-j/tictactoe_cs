using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class NegamaxCalculatorTestulatorTest
    {

        Predicate<int> alwaysTruePredicate = _ => true;
        Func<int, char, int> EchoIntFunction = (i, c) => i;

        const char PLAYER = 'p';
        const char OPPONENT = 'o';

        [Test]
        public void ScoreOfBestNodeIsCalculatedUsingPassedInFunction()
        {
            const int score = 10;
            Func<int, char,  int> scoreCalculator = (i, c) => score;
            var bestNode = new NegamaxCalculator<int, char, string>(alwaysTruePredicate, scoreCalculator, null, PLAYER, OPPONENT)
                .Negamax(new TrackingNode<int, string>(0, "someTracker"));
            Assert.AreEqual(score, bestNode.Score);
        }

        [Test]
        public void ValueOfBestNodeIsTrackerOfTerminalNode()
        {
            const int node = 0;
            const string tracker = "SomeTracker";
            var bestNode = new NegamaxCalculator<int, char, string>(alwaysTruePredicate, EchoIntFunction, null, PLAYER, OPPONENT)
                .Negamax(new TrackingNode<int, string>(node, tracker));
            Assert.AreEqual(tracker, bestNode.Value);
        }

        /* 0("ParentNode") parent node
         * \ 1("A") child node
         * best node value = "A"
         */
        [Test]
        public void BestNodeValueWillBeTheSingleChildOfParentNode()
        {
            const string childNodeValue = "A";
            var bestNode = RunNegamaxWithChild(new TrackingNode<int, string>(1, childNodeValue));
            Assert.AreEqual(bestNode.Value, childNodeValue);
        }

        /* 0("ParentNode") parent node
         * \ 1("A") child node
         * best node score = -1
         */
        [Test]
        public void ScoreOfBestNodeWillBeNegatedScoreOfOnlyChildNode()
        {
            const int childNode = 1;
            var bestNode = RunNegamaxWithChild(new TrackingNode<int, string>(childNode, "A"));
            Assert.AreEqual(bestNode.Score, -childNode);
        }

        /* 0("ParentNode")    parent node
         * \ 1("A"), 2("B")   children nodes
         * best node value = "B"
         */
        [Test]
        public void BestNodeWillBeTheChildWithHighestScore()
        {
            const string childNodeValueB = "B";
            var bestNode = RunNegamaxWithChildren(BuildListOfChildren(NewTrackingNode(1, "A"), NewTrackingNode(2, childNodeValueB)));
            Assert.AreEqual(childNodeValueB, bestNode.Value);
        }

        static NegamaxCalculator<int, char, string>.BestNode RunNegamaxWithChildren(IEnumerable<TrackingNode<int, string>> children)
        {
            const int parentNode = 0;
            var childExtractor = ParentToChildExtractorFunction(parentNode, children);
            var bestNode = new NegamaxCalculator<int, char, string>(TerminateAtChildNode(parentNode), ScoreCalculator(), childExtractor, PLAYER, OPPONENT)
                .Negamax(new TrackingNode<int, string>(parentNode, "0"));
            return bestNode;
        }

        static TrackingNode<int, string> NewTrackingNode(int node, string tracker)
        {
            return new TrackingNode<int, string>(node, tracker);
        }

        static Func<int, char, int> ScoreCalculator()
        {
            return (x, c) => c == OPPONENT ? -x : x;
        }

        static Predicate<int> TerminateAtChildNode(int parentNode)
        {
            return x => x != parentNode;
        }

        static Func<int, char, IEnumerable<TrackingNode<int, string>>> ParentToChildExtractorFunction(int parentNode, IEnumerable<TrackingNode<int, string>> children)
        {
            return (x, c) => x == parentNode ? children : Enumerable.Empty<TrackingNode<int, string>>();
        }

        static IList<TrackingNode<int, string>> BuildListOfChildren(params TrackingNode<int, string>[] children)
        {
            return children.ToList();
        }

        private NegamaxCalculator<int, char, string>.BestNode RunNegamaxWithChild(TrackingNode<int, string> childNodeTracker)
        {
            const int parentNode = 0;
            var childExtractor = ParentToChildExtractorFunction(parentNode, BuildListOfChildren(childNodeTracker));
            var parentNodeTracker = new TrackingNode<int, string>(parentNode, "ParentNodeValue");
            var bestNode = new NegamaxCalculator<int, char, string>(TerminateAtChildNode(parentNode), EchoIntFunction, childExtractor, PLAYER, OPPONENT).Negamax(parentNodeTracker);
            return bestNode;
        }

    }
}
