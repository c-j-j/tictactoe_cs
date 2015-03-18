using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class MinimaxCalculatorTestulatorTest
    {

        Predicate<int> alwaysTruePredicate = _ => true;
        Func<int, int> echoIntFunction = _ => _;

        [Test]
        public void ScoreOfBestNodeIsCalculatedUsingPassedInFunction()
        {
            const int score = 1;
            Func<int, int> scoreCalculator = _ => score;
            var trackingNode = new TrackingNode<int, string>(0, "someTracker");
            var bestNode = new MinimaxCalculator<int, string>(alwaysTruePredicate, scoreCalculator, null).Negamax(trackingNode);
            Assert.AreEqual(score, bestNode.Score);
        }

        [Test]
        public void ValueOfBestNodeIsTrackerOfTerminalNode()
        {
            const int node = 0;
            const string tracker = "SomeTracker";
            var trackingNode = new TrackingNode<int, string>(node, tracker);
            var bestNode = new MinimaxCalculator<int, string>(alwaysTruePredicate, echoIntFunction, null)
                .Negamax(trackingNode);
            Assert.AreEqual(tracker, bestNode.Value);
        }


        [Test]
        public void BestNodeWillBeTheSingleTerminalChildOfParentNode()
        {
            const int parentNode = 0;
            var parentNodeTracker = new TrackingNode<int, string>(parentNode, "0");
            const int childNode = 1;
            const string childNodeValue = "1";
            var childNodeTracker = new TrackingNode<int, string>(childNode, childNodeValue);
            var childExtractor = ParentToChildExtractorFunction(parentNode, BuildListOfChildren(childNodeTracker));
            var bestNode = new MinimaxCalculator<int, string>(TerminateAtChildNode(parentNode), echoIntFunction, childExtractor)
                .Negamax(parentNodeTracker);
            Assert.AreEqual(bestNode.Value, childNodeValue);
        }

        [Test]
        public void BestNodeWillBeTheChildWithHighestScore()
        {
            const int parentNode = 0;
            var parentNodeTracker = new TrackingNode<int, string>(parentNode, "0");
            const int childNodeB = 2;
            const string childNodeValueB = "2";
            var childExtractor = ParentToChildExtractorFunction(parentNode, BuildListOfChildren(NewTrackingNode(1, "1"), NewTrackingNode(childNodeB, childNodeValueB)));
            var bestNode = new MinimaxCalculator<int, string>(TerminateAtChildNode(parentNode), ScoreCalculatorBasedOnOpponentPerspective(), childExtractor)
                .Negamax(parentNodeTracker);
            Assert.AreEqual(childNodeValueB, bestNode.Value);
        }

        static TrackingNode<int, string> NewTrackingNode(int node, string tracker)
        {
            return new TrackingNode<int, string>(node, tracker);
        }

        static Func<int, int> ScoreCalculatorBasedOnOpponentPerspective()
        {
            return x => -x;
        }

        static Predicate<int> TerminateAtChildNode(int parentNode)
        {
            return x => x != parentNode;
        }

        static Func<int, IEnumerable<TrackingNode<int, string>>> ParentToChildExtractorFunction(int parentNode, IEnumerable<TrackingNode<int, string>> children)
        {
            return x => x == parentNode ? children : Enumerable.Empty<TrackingNode<int, string>>();
        }

        static IList<TrackingNode<int, string>> BuildListOfChildren(params TrackingNode<int, string>[] children)
        {
            return children.ToList();
        }

    }
}
