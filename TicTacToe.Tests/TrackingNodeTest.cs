
using NUnit.Framework;
namespace TicTacToe
{
    [TestFixture]
    public class TrackingNodeTest
    {
        [Test]
        public void CreatesTrackingChildNode()
        {
            const int node = 0;
            const string tracker = "Tracker";
            var trackingNode = new TrackingNode<int, string>(node, tracker);
            Assert.AreEqual(trackingNode.Node, 0);
            Assert.AreEqual(trackingNode.Tracker, tracker);
        }
    }
}
